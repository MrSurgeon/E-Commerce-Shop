#pragma checksum "C:\Users\Lenovo\Documents\GitHub\E-Commerce-Shop\E-Commerce-Shop.WebUI\Views\Home\index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b9c66f660d44b630e32b6be09fc2dfc91dad000e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_index), @"mvc.1.0.view", @"/Views/Home/index.cshtml")]
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
#line 1 "C:\Users\Lenovo\Documents\GitHub\E-Commerce-Shop\E-Commerce-Shop.WebUI\Views\_ViewImports.cshtml"
using E_Commerce_Shop.Entity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Lenovo\Documents\GitHub\E-Commerce-Shop\E-Commerce-Shop.WebUI\Views\_ViewImports.cshtml"
using E_Commerce_Shop.WebUI.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b9c66f660d44b630e32b6be09fc2dfc91dad000e", @"/Views/Home/index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4bdff6f63a64d5920e034a4053c2b7377de08e50", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ProductListViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Lenovo\Documents\GitHub\E-Commerce-Shop\E-Commerce-Shop.WebUI\Views\Home\index.cshtml"
  
    var products = @Model.Products;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"row\">\r\n    <div class=\"col-md-3\">\r\n        ");
#nullable restore
#line 8 "C:\Users\Lenovo\Documents\GitHub\E-Commerce-Shop\E-Commerce-Shop.WebUI\Views\Home\index.cshtml"
   Write(await Component.InvokeAsync("Categories"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n    <div class=\"col-md-9\">\r\n        <div class=\"row\">\r\n");
#nullable restore
#line 12 "C:\Users\Lenovo\Documents\GitHub\E-Commerce-Shop\E-Commerce-Shop.WebUI\Views\Home\index.cshtml"
             foreach (var product in products)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"col-12 col-md-6 col-xl-4 mb-2 \">\r\n                    ");
#nullable restore
#line 15 "C:\Users\Lenovo\Documents\GitHub\E-Commerce-Shop\E-Commerce-Shop.WebUI\Views\Home\index.cshtml"
               Write(await Html.PartialAsync("_product",product));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n");
#nullable restore
#line 17 "C:\Users\Lenovo\Documents\GitHub\E-Commerce-Shop\E-Commerce-Shop.WebUI\Views\Home\index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n    </div>\r\n</div>\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
<script src=""https://cdn.jsdelivr.net/npm/popper.js@1.16.1/dist/umd/popper.min.js""
    integrity=""sha384-9/reFTGAW83EW2RDu2S0VKaIzap3H66lZH81PoYlFhbGU+6BZp6G7niu735Sk7lN""
    crossorigin=""anonymous""></script>
<script src=""https://cdn.jsdelivr.net/npm/bootstrap@4.6.0/dist/js/bootstrap.min.js""
    integrity=""sha384-+YQ4JLhjyBLPDQt//I+STsc9iw4uQqACwlvpslubQzn4u2UU2UFM80nGisd026JF""
    crossorigin=""anonymous""></script>
<link rel=""stylesheet"" href=""https://use.fontawesome.com/releases/v5.4.1/css/all.css"">
");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ProductListViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
