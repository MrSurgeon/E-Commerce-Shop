#pragma checksum "C:\Users\Tarık\Documents\GitHub\E-Commerce-Shop\E-Commerce-Shop.WebUI\Views\AdminRole\RoleEdit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "960dea927f04c4143831edef21e64ebb1316f181"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_AdminRole_RoleEdit), @"mvc.1.0.view", @"/Views/AdminRole/RoleEdit.cshtml")]
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
#nullable restore
#line 8 "C:\Users\Tarık\Documents\GitHub\E-Commerce-Shop\E-Commerce-Shop.WebUI\Views\_ViewImports.cshtml"
using E_Commerce_Shop.WebUI.Extensions;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\Tarık\Documents\GitHub\E-Commerce-Shop\E-Commerce-Shop.WebUI\Views\_ViewImports.cshtml"
using E_Commerce_Shop.WebUI.ViewModels.AdminRole;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\Tarık\Documents\GitHub\E-Commerce-Shop\E-Commerce-Shop.WebUI\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\Tarık\Documents\GitHub\E-Commerce-Shop\E-Commerce-Shop.WebUI\Views\_ViewImports.cshtml"
using E_Commerce_Shop.WebUI.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\Tarık\Documents\GitHub\E-Commerce-Shop\E-Commerce-Shop.WebUI\Views\_ViewImports.cshtml"
using E_Commerce_Shop.WebUI.ViewModels.AdminUser;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"960dea927f04c4143831edef21e64ebb1316f181", @"/Views/AdminRole/RoleEdit.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"37dcafc82d4333c6edceaac04713bbae2e59c65e", @"/Views/_ViewImports.cshtml")]
    public class Views_AdminRole_RoleEdit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<RoleEditViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "AdminRole", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "RoleEdit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "POST", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<h1>Role Edit </h1>\r\n<hr>\r\n<div class=\"row\">\r\n    <div class=\"col-md-12\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "960dea927f04c4143831edef21e64ebb1316f1816803", async() => {
                WriteLiteral("\r\n            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("div", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "960dea927f04c4143831edef21e64ebb1316f1817073", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper);
#nullable restore
#line 7 "C:\Users\Tarık\Documents\GitHub\E-Commerce-Shop\E-Commerce-Shop.WebUI\Views\AdminRole\RoleEdit.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary = global::Microsoft.AspNetCore.Mvc.Rendering.ValidationSummary.All;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-summary", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n            <input type=\"hidden\" name=\"RoleName\"");
                BeginWriteAttribute("value", " value=\"", 302, "\"", 325, 1);
#nullable restore
#line 8 "C:\Users\Tarık\Documents\GitHub\E-Commerce-Shop\E-Commerce-Shop.WebUI\Views\AdminRole\RoleEdit.cshtml"
WriteAttributeValue("", 310, Model.RoleName, 310, 15, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n            <input type=\"hidden\" name=\"RoleId\"");
                BeginWriteAttribute("value", " value=\"", 375, "\"", 396, 1);
#nullable restore
#line 9 "C:\Users\Tarık\Documents\GitHub\E-Commerce-Shop\E-Commerce-Shop.WebUI\Views\AdminRole\RoleEdit.cshtml"
WriteAttributeValue("", 383, Model.RoleId, 383, 13, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n            <h6 class=\"bg-info text-white p-1\">Add to ");
#nullable restore
#line 10 "C:\Users\Tarık\Documents\GitHub\E-Commerce-Shop\E-Commerce-Shop.WebUI\Views\AdminRole\RoleEdit.cshtml"
                                                 Write(Model.RoleName);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h6>\r\n            <table class=\"table table-bordered table-sm\">\r\n");
#nullable restore
#line 12 "C:\Users\Tarık\Documents\GitHub\E-Commerce-Shop\E-Commerce-Shop.WebUI\Views\AdminRole\RoleEdit.cshtml"
                 if (!Model.NonMembers.Any())
                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <tr>\r\n                        <td colspan=\"2\">Bütün kullanıcılar bu role ait !</td>\r\n                    </tr>\r\n");
#nullable restore
#line 17 "C:\Users\Tarık\Documents\GitHub\E-Commerce-Shop\E-Commerce-Shop.WebUI\Views\AdminRole\RoleEdit.cshtml"
                }
                else
                {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 20 "C:\Users\Tarık\Documents\GitHub\E-Commerce-Shop\E-Commerce-Shop.WebUI\Views\AdminRole\RoleEdit.cshtml"
                     foreach (var user in Model.NonMembers)
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <tr>\r\n                            <td>");
#nullable restore
#line 23 "C:\Users\Tarık\Documents\GitHub\E-Commerce-Shop\E-Commerce-Shop.WebUI\Views\AdminRole\RoleEdit.cshtml"
                           Write(user.UserName);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                            <td style=\"width: 150px;\">\r\n                                <input type=\"checkbox\" name=\"IdsToAdd\"");
                BeginWriteAttribute("value", " value=\"", 1086, "\"", 1102, 1);
#nullable restore
#line 25 "C:\Users\Tarık\Documents\GitHub\E-Commerce-Shop\E-Commerce-Shop.WebUI\Views\AdminRole\RoleEdit.cshtml"
WriteAttributeValue("", 1094, user.Id, 1094, 8, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n                            </td>\r\n                        </tr>\r\n");
#nullable restore
#line 28 "C:\Users\Tarık\Documents\GitHub\E-Commerce-Shop\E-Commerce-Shop.WebUI\Views\AdminRole\RoleEdit.cshtml"
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 28 "C:\Users\Tarık\Documents\GitHub\E-Commerce-Shop\E-Commerce-Shop.WebUI\Views\AdminRole\RoleEdit.cshtml"
                     
                }

#line default
#line hidden
#nullable disable
                WriteLiteral("            </table>\r\n            <hr>\r\n            <h6 class=\"bg-info text-white p-1\">Remove from ");
#nullable restore
#line 32 "C:\Users\Tarık\Documents\GitHub\E-Commerce-Shop\E-Commerce-Shop.WebUI\Views\AdminRole\RoleEdit.cshtml"
                                                      Write(Model.RoleName);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h6>\r\n            <table class=\"table table-bordered table-sm\">\r\n");
#nullable restore
#line 34 "C:\Users\Tarık\Documents\GitHub\E-Commerce-Shop\E-Commerce-Shop.WebUI\Views\AdminRole\RoleEdit.cshtml"
                 if (!Model.Members.Any())
                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <tr>\r\n                        <td colspan=\"2\">Bu rolden çıkarılabilecek kullanıcı bulunamadı!</td>\r\n                    </tr>\r\n");
#nullable restore
#line 39 "C:\Users\Tarık\Documents\GitHub\E-Commerce-Shop\E-Commerce-Shop.WebUI\Views\AdminRole\RoleEdit.cshtml"
                }
                else
                {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 42 "C:\Users\Tarık\Documents\GitHub\E-Commerce-Shop\E-Commerce-Shop.WebUI\Views\AdminRole\RoleEdit.cshtml"
                     foreach (var user in Model.Members)
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <tr>\r\n                            <td>");
#nullable restore
#line 45 "C:\Users\Tarık\Documents\GitHub\E-Commerce-Shop\E-Commerce-Shop.WebUI\Views\AdminRole\RoleEdit.cshtml"
                           Write(user.UserName);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                            <td style=\"width: 150px;\">\r\n                                <input type=\"checkbox\" name=\"IdsToDelete\"");
                BeginWriteAttribute("value", " value=\"", 1957, "\"", 1973, 1);
#nullable restore
#line 47 "C:\Users\Tarık\Documents\GitHub\E-Commerce-Shop\E-Commerce-Shop.WebUI\Views\AdminRole\RoleEdit.cshtml"
WriteAttributeValue("", 1965, user.Id, 1965, 8, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n                            </td>\r\n                        </tr>\r\n");
#nullable restore
#line 50 "C:\Users\Tarık\Documents\GitHub\E-Commerce-Shop\E-Commerce-Shop.WebUI\Views\AdminRole\RoleEdit.cshtml"
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 50 "C:\Users\Tarık\Documents\GitHub\E-Commerce-Shop\E-Commerce-Shop.WebUI\Views\AdminRole\RoleEdit.cshtml"
                     
                }

#line default
#line hidden
#nullable disable
                WriteLiteral("            </table>\r\n            <div class=\"form-group\">\r\n                <button type=\"submit\" class=\"btn btn-primary\">Save Changes</button>\r\n            </div>\r\n        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<RoleEditViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591