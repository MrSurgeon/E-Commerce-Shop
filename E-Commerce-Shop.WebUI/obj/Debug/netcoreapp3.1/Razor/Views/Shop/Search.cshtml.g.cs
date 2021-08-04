#pragma checksum "C:\Users\Tarık\Documents\GitHub\E-Commerce-Shop\E-Commerce-Shop.WebUI\Views\Shop\Search.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "be55e76d2efabfbfc94b09e380e274e12614dcdd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shop_Search), @"mvc.1.0.view", @"/Views/Shop/Search.cshtml")]
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
#line 2 "C:\Users\Tarık\Documents\GitHub\E-Commerce-Shop\E-Commerce-Shop.WebUI\Views\_ViewImports.cshtml"
using E_Commerce_Shop.Entity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Tarık\Documents\GitHub\E-Commerce-Shop\E-Commerce-Shop.WebUI\Views\_ViewImports.cshtml"
using E_Commerce_Shop.WebUI.Helpers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Tarık\Documents\GitHub\E-Commerce-Shop\E-Commerce-Shop.WebUI\Views\_ViewImports.cshtml"
using E_Commerce_Shop.WebUI.ViewModels.Admin;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Tarık\Documents\GitHub\E-Commerce-Shop\E-Commerce-Shop.WebUI\Views\_ViewImports.cshtml"
using E_Commerce_Shop.WebUI.ViewModels.Account;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Tarık\Documents\GitHub\E-Commerce-Shop\E-Commerce-Shop.WebUI\Views\_ViewImports.cshtml"
using E_Commerce_Shop.WebUI.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\Tarık\Documents\GitHub\E-Commerce-Shop\E-Commerce-Shop.WebUI\Views\_ViewImports.cshtml"
using Newtonsoft.Json;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"be55e76d2efabfbfc94b09e380e274e12614dcdd", @"/Views/Shop/Search.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5a2f07a3ad5ba05a70e7f2c89e38cb32506a08ce", @"/Views/_ViewImports.cshtml")]
    public class Views_Shop_Search : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SearchViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Tarık\Documents\GitHub\E-Commerce-Shop\E-Commerce-Shop.WebUI\Views\Shop\Search.cshtml"
  
    var products = @Model.Products;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"row\">\r\n    <div class=\"col-md-3\">\r\n        ");
#nullable restore
#line 8 "C:\Users\Tarık\Documents\GitHub\E-Commerce-Shop\E-Commerce-Shop.WebUI\Views\Shop\Search.cshtml"
   Write(await Component.InvokeAsync("Categories"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n    <div class=\"col-md-9\">\r\n        <div class=\"row\">\r\n");
#nullable restore
#line 12 "C:\Users\Tarık\Documents\GitHub\E-Commerce-Shop\E-Commerce-Shop.WebUI\Views\Shop\Search.cshtml"
             foreach (var product in products)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"col-12 col-md-6 col-xl-4 mb-2 \">\r\n                    ");
#nullable restore
#line 15 "C:\Users\Tarık\Documents\GitHub\E-Commerce-Shop\E-Commerce-Shop.WebUI\Views\Shop\Search.cshtml"
               Write(await Html.PartialAsync("_product",product));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n");
#nullable restore
#line 17 "C:\Users\Tarık\Documents\GitHub\E-Commerce-Shop\E-Commerce-Shop.WebUI\Views\Shop\Search.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SearchViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
