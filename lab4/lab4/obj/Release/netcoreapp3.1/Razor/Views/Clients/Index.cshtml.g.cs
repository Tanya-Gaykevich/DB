#pragma checksum "/Users/tatyanagaykevich/Documents/THIRD COURSE/БД/lab4/lab4/lab4/Views/Clients/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d77f1fe3bad24b38e7001cbbbb6d78dd405539d4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Clients_Index), @"mvc.1.0.view", @"/Views/Clients/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d77f1fe3bad24b38e7001cbbbb6d78dd405539d4", @"/Views/Clients/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a7dc22d90fc18e209c5502e81f0db6668f40c5c7", @"/Views/_ViewImports.cshtml")]
    public class Views_Clients_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<lab4.Client>>
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
#line 2 "/Users/tatyanagaykevich/Documents/THIRD COURSE/БД/lab4/lab4/lab4/Views/Clients/Index.cshtml"
  
    ViewData["title"] = "Clients";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<!DOCTYPE html>\n\n<html>\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d77f1fe3bad24b38e7001cbbbb6d78dd405539d43433", async() => {
                WriteLiteral("\n    <title>A LIST OF CLIENTS</title>\n");
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d77f1fe3bad24b38e7001cbbbb6d78dd405539d44419", async() => {
                WriteLiteral(@"
    <h3>Clients:</h3>
    <table align=""center"" border=""1"">
        <tr>
            <td>Surname</td>
            <td>Name</td>
            <td>Patronymic</td>
            <td>Birthday</td>
            <td>Gender</td>
            <td>Address</td>
            <td>Phone</td>
            <td>PassportData</td>
        </tr>
");
#nullable restore
#line 25 "/Users/tatyanagaykevich/Documents/THIRD COURSE/БД/lab4/lab4/lab4/Views/Clients/Index.cshtml"
         foreach (var client in Model)
        {

#line default
#line hidden
#nullable disable
                WriteLiteral("            <tr>\n                <td>");
#nullable restore
#line 28 "/Users/tatyanagaykevich/Documents/THIRD COURSE/БД/lab4/lab4/lab4/Views/Clients/Index.cshtml"
               Write(client.Surname);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\n                <td>");
#nullable restore
#line 29 "/Users/tatyanagaykevich/Documents/THIRD COURSE/БД/lab4/lab4/lab4/Views/Clients/Index.cshtml"
               Write(client.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\n                <td>");
#nullable restore
#line 30 "/Users/tatyanagaykevich/Documents/THIRD COURSE/БД/lab4/lab4/lab4/Views/Clients/Index.cshtml"
               Write(client.Patronymic);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\n                <td>");
#nullable restore
#line 31 "/Users/tatyanagaykevich/Documents/THIRD COURSE/БД/lab4/lab4/lab4/Views/Clients/Index.cshtml"
               Write(client.Birthday.ToShortDateString());

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\n                <td>");
#nullable restore
#line 32 "/Users/tatyanagaykevich/Documents/THIRD COURSE/БД/lab4/lab4/lab4/Views/Clients/Index.cshtml"
               Write(client.Gender);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\n                <td>");
#nullable restore
#line 33 "/Users/tatyanagaykevich/Documents/THIRD COURSE/БД/lab4/lab4/lab4/Views/Clients/Index.cshtml"
               Write(client.Address);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\n                <td>");
#nullable restore
#line 34 "/Users/tatyanagaykevich/Documents/THIRD COURSE/БД/lab4/lab4/lab4/Views/Clients/Index.cshtml"
               Write(client.Phone);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\n                <td>");
#nullable restore
#line 35 "/Users/tatyanagaykevich/Documents/THIRD COURSE/БД/lab4/lab4/lab4/Views/Clients/Index.cshtml"
               Write(client.PassportData);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\n            </tr>\n");
#nullable restore
#line 37 "/Users/tatyanagaykevich/Documents/THIRD COURSE/БД/lab4/lab4/lab4/Views/Clients/Index.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<lab4.Client>> Html { get; private set; }
    }
}
#pragma warning restore 1591
