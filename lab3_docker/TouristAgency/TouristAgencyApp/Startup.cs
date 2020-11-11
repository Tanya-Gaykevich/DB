using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;
using Microsoft.EntityFrameworkCore;
using System.Text;
using Microsoft.Extensions.Caching.Memory;
using System.Net;
using TouristAgencyApp.Session;

namespace TouristAgencyApp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //Подключаем базу данных к сервисам
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            string connectionString = config.GetConnectionString("DefaultConnection");
            services.AddDbContext<TouristAgencyContext>(options => options.UseSqlServer(connectionString));
            //Добавление кеширования
            services.AddMemoryCache();
            services.AddDistributedMemoryCache();
            //Добавление сессий
            services.AddSession();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, TouristAgencyContext dbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseStaticFiles();
            app.UseSession();
            app.UseCachingMiddleware();

            app.Map("/info", Info);
            app.Map("/services", Services);
            app.Map("/searchform", SearchForm);


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {   
                    StringBuilder htmlBuilder = new StringBuilder();
                    htmlBuilder.Append("<a href=\"/info\"><h2>Info</h2></a>");
                    htmlBuilder.Append("<a href=\"/services\"><h2>Services</h2></a>");
                    htmlBuilder.Append("<a href=\"/searchform\"><h2>SearchForm</h2></a>");
                    await context.Response.WriteAsync(htmlBuilder.ToString());

                });
            });
        }

        public void Info(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                StringBuilder htmlBuilder = new StringBuilder();
                htmlBuilder.Append("<a href=\"/\"<h2>Back</h2></a></br>");
                htmlBuilder.Append(context.Request.Headers["User-Agent"]);
                await context.Response.WriteAsync(htmlBuilder.ToString());
            });
        }

        public void Services(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                StringBuilder htmlBuilder = new StringBuilder();
                htmlBuilder.Append("<a href=\"/\"<h2>Back</h2></a></br>");
                IEnumerable<Service> services = (IEnumerable<Service>)context.RequestServices.GetService<IMemoryCache>().Get("services");
                htmlBuilder.Append(MakeServicesHtmlTableFromEnumerable(services));
                await context.Response.WriteAsync(htmlBuilder.ToString());
            });
        }

        public void SearchForm(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                string client, seviceMaxCost;
                GetFieldValuesFromCookies(context,
                    out client,
                    out seviceMaxCost);
                StringBuilder htmlBuilder = new StringBuilder();
                htmlBuilder.Append("<a href=\"/\"<h2>Back</h2></a></br>");
                htmlBuilder.Append("<form action=\"/searchform\">" +
                                    "<h3>Select table</h3>" +
                                    "<select name=\"tables\">" +
                                        "<option>Services</option>" +
                                        "<option>Clients</option>" +
                                    "</select>" +
                                     "<h3>Enter part of a name of client</h3>" +
                                    $"<input name=\"clientInput\" value=\"{client}\">" +
                                    "<h3>Enter max cost of services</h3>" +
                                    $"<input name=\"serviceMaxCostInput\" value=\"{seviceMaxCost}\">" +
                                    "<br><br>" +
                                    "<button type='submit'>Confirm</button>" +
                                "</form>");
                if (context.Request.Query["clientInput"] != "" && context.Request.Query["tables"] == "Clients")
                {
                    var clients = context.Session.Get<List<Client>>("clients" + context.Request.Query["clientInput"]) ??
                        context.RequestServices.GetService<TouristAgencyContext>().Clients
                        .Where(client => client.Name.Contains(context.Request.Query["clientInput"]))
                        .Take(50)
                        .ToList();
                    htmlBuilder.Append(MakeClientsTableFromEnumerable(clients));
                    context.Session.Set("clients" + context.Request.Query["clientInput"], clients);
                }
                else if (context.Request.Query["serviceMaxCostInput"] != "" && context.Request.Query["tables"] == "Services")
                {
                    var services = context.Session.Get<List<Service>>("services" + context.Request.Query["serviceMaxCostInput"]) ??
                        context.RequestServices.GetService<TouristAgencyContext>().Services
                        .Where(service => service.Cost < decimal.Parse(context.Request.Query["serviceMaxCostInput"]))
                        .Take(50)
                        .ToList();
                    htmlBuilder.Append(MakeServicesHtmlTableFromEnumerable(services));
                    context.Session.Set("services" + context.Request.Query["serviceMaxCostInput"], services);
                }
                await context.Response.WriteAsync(htmlBuilder.ToString());
            });
        }

        private static void GetFieldValuesFromCookies(HttpContext context,
            out string client,
            out string serviceMaxCost)
        {
            client = context.Request.Query["clientInput"];
            serviceMaxCost = context.Request.Query["serviceMaxCostInput"];
            if (client != null)
            {
                context.Response.Cookies.Append("client", client);
            }
            else if (context.Request.Cookies["client"] != null)
            {
                client = context.Request.Cookies["client"];
            }
            if (serviceMaxCost != null)
            {
                context.Response.Cookies.Append("serviceMaxCost", serviceMaxCost);
            }
            else if (context.Request.Cookies["serviceMaxCost"] != null)
            {
                serviceMaxCost = context.Request.Cookies["serviceMaxCost"];
            }
        }



        private string MakeServicesHtmlTableFromEnumerable(IEnumerable<Service> services)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("<H1>Services Table</H1>" +
                            "<TABLE BORDER=1>");
            builder.Append("<TD>Id</TD>");
            builder.Append("<TD>Name</TD>");
            builder.Append("<TD>Description</TD>");
            builder.Append("<TD>Cost</TD>");
           
            foreach (var service in services)
            {
                builder.Append("<TR>");
                builder.Append("<TD>" + service.Id + "</TD>");
                builder.Append("<TD>" + service.Name + "</TD>");
                builder.Append("<TD>" + service.Description + "</TD>");
                builder.Append("<TD>" + service.Cost + "</TD>");
                builder.Append("</TR>");
            }
            builder.Append("</TABLE>");
            return builder.ToString();
        }

        private string MakeClientsTableFromEnumerable(IEnumerable<Client> clients)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("<H1>Clients Table</H1>" +
                            "<TABLE BORDER=1>");
            builder.Append("<TD>Id</TD>");
            builder.Append("<TD>Surname</TD>");
            builder.Append("<TD>Name</TD>");
            builder.Append("<TD>Patronymic</TD>");
            builder.Append("<TD>Birthday</TD>");
            builder.Append("<TD>Gender</TD>");
            builder.Append("<TD>Address</TD>");
            builder.Append("<TD>Phone</TD>");
            builder.Append("<TD>PassportData</TD>");
          
            foreach (var client in clients)
            {
                builder.Append("<TR>");
                builder.Append("<TD>" + client.Id + "</TD>");
                builder.Append("<TD>" + client.Surname + "</TD>");
                builder.Append("<TD>" + client.Name + "</TD>");
                builder.Append("<TD>" + client.Patronymic + "</TD>");
                builder.Append("<TD>" + client.Birthday + "</TD>");
                builder.Append("<TD>" + client.Gender + "</TD>");
                builder.Append("<TD>" + client.Address+ "</TD>");
                builder.Append("<TD>" + client.Phone + "</TD>");
                builder.Append("<TD>" + client.PassportData + "</TD>");
                
               
                builder.Append("</TR>");
            }
            builder.Append("</TABLE>");
            return builder.ToString();
        }

    }
}
