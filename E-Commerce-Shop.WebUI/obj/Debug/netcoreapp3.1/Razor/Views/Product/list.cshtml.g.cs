#pragma checksum "C:\Users\Lenovo\Documents\GitHub\E-Commerce-Shop\E-Commerce-Shop.WebUI\Views\Product\list.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5ae6321887bf78c34d0b97b1baaab161997dec19"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Product_list), @"mvc.1.0.view", @"/Views/Product/list.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5ae6321887bf78c34d0b97b1baaab161997dec19", @"/Views/Product/list.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4bdff6f63a64d5920e034a4053c2b7377de08e50", @"/Views/_ViewImports.cshtml")]
    public class Views_Product_list : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ProductViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Lenovo\Documents\GitHub\E-Commerce-Shop\E-Commerce-Shop.WebUI\Views\Product\list.cshtml"
  
    var products = @Model.Products;

#line default
#line hidden
#nullable disable
            DefineSection("Categories", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 6 "C:\Users\Lenovo\Documents\GitHub\E-Commerce-Shop\E-Commerce-Shop.WebUI\Views\Product\list.cshtml"
Write(await Component.InvokeAsync("Categories"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n");
            }
            );
            WriteLiteral("<div class=\"row\">\r\n");
#nullable restore
#line 9 "C:\Users\Lenovo\Documents\GitHub\E-Commerce-Shop\E-Commerce-Shop.WebUI\Views\Product\list.cshtml"
     if (!products.Any())
    {
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\Lenovo\Documents\GitHub\E-Commerce-Shop\E-Commerce-Shop.WebUI\Views\Product\list.cshtml"
   Write(await Html.PartialAsync("_noProduct"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\Lenovo\Documents\GitHub\E-Commerce-Shop\E-Commerce-Shop.WebUI\Views\Product\list.cshtml"
                                              
    }
    else
    {
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "C:\Users\Lenovo\Documents\GitHub\E-Commerce-Shop\E-Commerce-Shop.WebUI\Views\Product\list.cshtml"
         foreach (var product in products)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"col-12 col-md-6 col-xl-4 mb-2 \">\r\n                ");
#nullable restore
#line 18 "C:\Users\Lenovo\Documents\GitHub\E-Commerce-Shop\E-Commerce-Shop.WebUI\Views\Product\list.cshtml"
           Write(await Html.PartialAsync("_product",product));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n");
#nullable restore
#line 20 "C:\Users\Lenovo\Documents\GitHub\E-Commerce-Shop\E-Commerce-Shop.WebUI\Views\Product\list.cshtml"
        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 20 "C:\Users\Lenovo\Documents\GitHub\E-Commerce-Shop\E-Commerce-Shop.WebUI\Views\Product\list.cshtml"
         
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ProductViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
