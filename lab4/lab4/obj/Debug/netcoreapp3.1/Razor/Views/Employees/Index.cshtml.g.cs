#pragma checksum "/Users/tatyanagaykevich/Documents/THIRD COURSE/БД/lab4/lab4/lab4/Views/Employees/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3412db91b71c2b427796e1d3781f67fe24ab9314"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Employees_Index), @"mvc.1.0.view", @"/Views/Employees/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "/Users/tatyanagaykevich/Documents/THIRD COURSE/БД/lab4/lab4/lab4/Views/_ViewImports.cshtml"
using lab4;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/tatyanagaykevich/Documents/THIRD COURSE/БД/lab4/lab4/lab4/Views/_ViewImports.cshtml"
using lab4.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3412db91b71c2b427796e1d3781f67fe24ab9314", @"/Views/Employees/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a7dc22d90fc18e209c5502e81f0db6668f40c5c7", @"/Views/_ViewImports.cshtml")]
    public class Views_Employees_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<lab4.Employee>>
    {
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "/Users/tatyanagaykevich/Documents/THIRD COURSE/БД/lab4/lab4/lab4/Views/Employees/Index.cshtml"
  
    ViewData["title"] = "Employee";

#line default
#line hidden
#nullable disable
            WriteLiteral("<!DOCTYPE html>\n\n<html>\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3412db91b71c2b427796e1d3781f67fe24ab93143446", async() => {
                WriteLiteral("\n    <title>A LIST OF EMPLOYEES</title>\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3412db91b71c2b427796e1d3781f67fe24ab93144434", async() => {
                WriteLiteral("\n    <h3 align=\"center\">Employees:</h3>\n    <table align=\"left\" border=\"1\">\n        <tr>\n            <td>Surmane</td>\n            <td>Name</td>\n            <td>Patronymic</td>\n            <td>Birthday</td>\n            <td>Position name</td>\n        </tr>\n");
#nullable restore
#line 21 "/Users/tatyanagaykevich/Documents/THIRD COURSE/БД/lab4/lab4/lab4/Views/Employees/Index.cshtml"
         foreach (var employee in Model)
        {

#line default
#line hidden
#nullable disable
                WriteLiteral("            <tr>\n                <td>");
#nullable restore
#line 24 "/Users/tatyanagaykevich/Documents/THIRD COURSE/БД/lab4/lab4/lab4/Views/Employees/Index.cshtml"
               Write(employee.Surname);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\n                <td>");
#nullable restore
#line 25 "/Users/tatyanagaykevich/Documents/THIRD COURSE/БД/lab4/lab4/lab4/Views/Employees/Index.cshtml"
               Write(employee.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\n                <td>");
#nullable restore
#line 26 "/Users/tatyanagaykevich/Documents/THIRD COURSE/БД/lab4/lab4/lab4/Views/Employees/Index.cshtml"
               Write(employee.Patronymic);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\n                <td>");
#nullable restore
#line 27 "/Users/tatyanagaykevich/Documents/THIRD COURSE/БД/lab4/lab4/lab4/Views/Employees/Index.cshtml"
               Write(employee.Birthday.ToShortDateString());

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\n                <td>");
#nullable restore
#line 28 "/Users/tatyanagaykevich/Documents/THIRD COURSE/БД/lab4/lab4/lab4/Views/Employees/Index.cshtml"
               Write(employee.Position.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\n            </tr>\n");
#nullable restore
#line 30 "/Users/tatyanagaykevich/Documents/THIRD COURSE/БД/lab4/lab4/lab4/Views/Employees/Index.cshtml"
        }

#line default
#line hidden
#nullable disable
                WriteLiteral("    </table>\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n</html>\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<lab4.Employee>> Html { get; private set; }
    }
}
#pragma warning restore 1591