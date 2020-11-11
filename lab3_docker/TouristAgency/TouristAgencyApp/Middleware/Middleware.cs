using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;

namespace TouristAgencyApp
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class CachingMiddleware
    {
        private readonly RequestDelegate _next;

        public CachingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext, IMemoryCache cache, TouristAgencyContext dbContext)
        {
            var services = dbContext.Services.Take(20).ToList();
            if (services != null)
            {
                cache.Set("services", services,
                    new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromSeconds(2 * 2 + 240)));
            }
            var clients = dbContext.Clients.Take(20).ToList();
            if (clients != null)
            {
                cache.Set("customers", clients,
                    new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromSeconds(2 * 2 + 240)));
            }
            
            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class CachingMiddlewareExtensions
    {
        public static IApplicationBuilder UseCachingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CachingMiddleware>();
        }
    }

   
}


