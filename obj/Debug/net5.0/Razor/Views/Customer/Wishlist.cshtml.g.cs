#pragma checksum "E:\Thabis Documents\Projects\NETCore5\improweb2022_02\Views\Customer\Wishlist.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "23de4cf963f19e58fe60ccb1aeb26df320db4666"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Customer_Wishlist), @"mvc.1.0.view", @"/Views/Customer/Wishlist.cshtml")]
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
#line 1 "E:\Thabis Documents\Projects\NETCore5\improweb2022_02\Views\_ViewImports.cshtml"
using improweb2022_02;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "E:\Thabis Documents\Projects\NETCore5\improweb2022_02\Views\Customer\Wishlist.cshtml"
using improweb2022_02.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"23de4cf963f19e58fe60ccb1aeb26df320db4666", @"/Views/Customer/Wishlist.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a829fd9fd4a7d7b282679c9221c2e7d0c09dbf94", @"/Views/_ViewImports.cshtml")]
    public class Views_Customer_Wishlist : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("title", new global::Microsoft.AspNetCore.Html.HtmlString("Top"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("itemprop", new global::Microsoft.AspNetCore.Html.HtmlString("item"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "customer", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "dashboard", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("title", new global::Microsoft.AspNetCore.Html.HtmlString("Dashboard"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "product", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "E:\Thabis Documents\Projects\NETCore5\improweb2022_02\Views\Customer\Wishlist.cshtml"
  
    ViewData["Title"] = "Cart";
    Layout = "~/Views/Shared/_UserLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div id=\"content\" class=\"container\">\r\n    <div class=\"row\">\r\n        <!-- #region BreadCrump -->\r\n        <div class=\"breadcrumb-container d-none d-md-flex flex-wrap align-items-center mb-4 border_\">\r\n            <ol class=\"breadcrumb mb-0 border_\"");
            BeginWriteAttribute("itemscope", " itemscope=\"", 373, "\"", 385, 0);
            EndWriteAttribute();
            WriteLiteral(" itemtype=\"http://schema.org/BreadcrumbList\">\r\n                <li class=\"breadcrumb-item\" itemprop=\"itemListElement\"");
            BeginWriteAttribute("itemscope", " itemscope=\"", 503, "\"", 515, 0);
            EndWriteAttribute();
            WriteLiteral(" itemtype=\"http://schema.org/ListItem\">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "23de4cf963f19e58fe60ccb1aeb26df320db46666977", async() => {
                WriteLiteral("\r\n                        <meta itemprop=\"name\" content=\"Home page\" />\r\n                        <meta itemprop=\"position\" content=\"1\" />\r\n                        <i class=\"fa fa-home\"></i>\r\n                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </li>\r\n                <li class=\"breadcrumb-item\" itemprop=\"itemListElement\"");
            BeginWriteAttribute("itemscope", " itemscope=\"", 958, "\"", 970, 0);
            EndWriteAttribute();
            WriteLiteral(" itemtype=\"http://schema.org/ListItem\">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "23de4cf963f19e58fe60ccb1aeb26df320db46669038", async() => {
                WriteLiteral("\r\n                        <meta itemprop=\"position\" content=\"2\"><span itemprop=\"name\" dir=\"auto\">Dashboard</span>\r\n                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                </li>
            </ol>
            <div class=""breadcrumb-item active border_"">
                <span>WishList</span>
            </div>
        </div>
        <!-- #endregion -->
    </div>
    <div id=""content-body"" class=""row"">
        ");
#nullable restore
#line 32 "E:\Thabis Documents\Projects\NETCore5\improweb2022_02\Views\Customer\Wishlist.cshtml"
   Write(await Component.InvokeAsync("DashboardSideBar"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
        <!-- #endregion -->
        <!-- #region Content Center -->
        <div id=""content-center"" class=""col-lg-9"">
            <div class=""page category-page"">
                <div class=""page-title"">
                    <p class=""border_"">
                        WISHLIST ITEMS
                    </p>
                </div>
                <div class=""page-body"">
");
#nullable restore
#line 43 "E:\Thabis Documents\Projects\NETCore5\improweb2022_02\Views\Customer\Wishlist.cshtml"
                     if (ViewBag.wishlists.Count > 0){

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    <table id=""CategoryTable"" class=""table table-bordered table-striped"">
                        <thead>
                            <tr>
                                <th>WishlistID</th>
                                <th>Creation Date</th>
                                <th>Customer</th>
                                <th>Product</th>
                                <th>Description</th>
                                <th>Price(When Added)</th>
                                <th>Stock</th>
                                <th>Organisation Branch</th>
                                <th>Action</th>
                            </tr>
                        </thead>
                        <tbody>
");
#nullable restore
#line 59 "E:\Thabis Documents\Projects\NETCore5\improweb2022_02\Views\Customer\Wishlist.cshtml"
                                 foreach (var item in ViewBag.wishlists)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <tr>\r\n                                        <td>");
#nullable restore
#line 62 "E:\Thabis Documents\Projects\NETCore5\improweb2022_02\Views\Customer\Wishlist.cshtml"
                                       Write(item.WishID);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 63 "E:\Thabis Documents\Projects\NETCore5\improweb2022_02\Views\Customer\Wishlist.cshtml"
                                       Write(item.CreationDate.ToString("MM/dd/yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 64 "E:\Thabis Documents\Projects\NETCore5\improweb2022_02\Views\Customer\Wishlist.cshtml"
                                       Write(item.Customer.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 64 "E:\Thabis Documents\Projects\NETCore5\improweb2022_02\Views\Customer\Wishlist.cshtml"
                                                                Write(item.Customer.Surname);

#line default
#line hidden
#nullable disable
            WriteLiteral(" (");
#nullable restore
#line 64 "E:\Thabis Documents\Projects\NETCore5\improweb2022_02\Views\Customer\Wishlist.cshtml"
                                                                                        Write(item.Customer.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral(")</td>\r\n                                        <td>");
#nullable restore
#line 65 "E:\Thabis Documents\Projects\NETCore5\improweb2022_02\Views\Customer\Wishlist.cshtml"
                                       Write(item.Product.ProductCode);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 66 "E:\Thabis Documents\Projects\NETCore5\improweb2022_02\Views\Customer\Wishlist.cshtml"
                                       Write(item.Product.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>\r\n                                            ");
#nullable restore
#line 68 "E:\Thabis Documents\Projects\NETCore5\improweb2022_02\Views\Customer\Wishlist.cshtml"
                                       Write(item.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral(" (When added to wishlist)<br>\r\n                                            ");
#nullable restore
#line 69 "E:\Thabis Documents\Projects\NETCore5\improweb2022_02\Views\Customer\Wishlist.cshtml"
                                       Write(item.Product.PurchasePrice);

#line default
#line hidden
#nullable disable
            WriteLiteral(" (Now)\r\n                                        </td>\r\n                                        <td>");
#nullable restore
#line 71 "E:\Thabis Documents\Projects\NETCore5\improweb2022_02\Views\Customer\Wishlist.cshtml"
                                       Write(item.Stock);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 72 "E:\Thabis Documents\Projects\NETCore5\improweb2022_02\Views\Customer\Wishlist.cshtml"
                                       Write(item.OrgBranchID);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>\r\n                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "23de4cf963f19e58fe60ccb1aeb26df320db466616680", async() => {
                WriteLiteral("Product Details");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_8.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 74 "E:\Thabis Documents\Projects\NETCore5\improweb2022_02\Views\Customer\Wishlist.cshtml"
                                                                                               WriteLiteral(item.ProdID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                        </td>\r\n                                    </tr> \r\n");
#nullable restore
#line 77 "E:\Thabis Documents\Projects\NETCore5\improweb2022_02\Views\Customer\Wishlist.cshtml"
                                
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                        </tbody>
                        <tfoot>
                            <tr>
                                <th>WishlistID</th>
                                <th>Creation Date</th>
                                <th>Customer</th>
                                <th>Product</th>
                                <th>Description</th>
                                <th>Price(When Added)</th>
                                <th>Stock</th>
                                <th>Organisation Branch</th>
                                <th>Action</th>
                            </tr>
                        </tfoot>
                    </table>
");
#nullable restore
#line 95 "E:\Thabis Documents\Projects\NETCore5\improweb2022_02\Views\Customer\Wishlist.cshtml"
                    }else{

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"product-list-container\">\r\n                        WISHLIST IS EMPTY!\r\n                    </div>\r\n");
#nullable restore
#line 99 "E:\Thabis Documents\Projects\NETCore5\improweb2022_02\Views\Customer\Wishlist.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
