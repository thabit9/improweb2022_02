#pragma checksum "E:\Thabis Documents\Projects\NETCore5\improweb2022_02\Views\Shared\Components\CartRight\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7d4db8b433000231f6f10085e2ff5987cdf8f595"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_CartRight_Index), @"mvc.1.0.view", @"/Views/Shared/Components/CartRight/Index.cshtml")]
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
#line 4 "E:\Thabis Documents\Projects\NETCore5\improweb2022_02\Views\Shared\Components\CartRight\Index.cshtml"
using improweb2022_02.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "E:\Thabis Documents\Projects\NETCore5\improweb2022_02\Views\Shared\Components\CartRight\Index.cshtml"
using Microsoft.AspNetCore.Http.Extensions;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7d4db8b433000231f6f10085e2ff5987cdf8f595", @"/Views/Shared/Components/CartRight/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a829fd9fd4a7d7b282679c9221c2e7d0c09dbf94", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_CartRight_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "wishlist", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "addwishlist", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-secondary btn-sm btn-icon ajax-cart-link"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("title", new global::Microsoft.AspNetCore.Html.HtmlString("Move to wishlist"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("nofollow"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-type", new global::Microsoft.AspNetCore.Html.HtmlString("cart"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-action", new global::Microsoft.AspNetCore.Html.HtmlString("addfromcart"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-secondary btn-to-danger btn-sm btn-icon remove ajax-cart-link"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("title", new global::Microsoft.AspNetCore.Html.HtmlString("Remove"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "cart", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "remove", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_11 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-action", new global::Microsoft.AspNetCore.Html.HtmlString("remove"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_12 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_13 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success btn-flat btn-flat-light btn-block btn-action border_"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 1 "E:\Thabis Documents\Projects\NETCore5\improweb2022_02\Views\Shared\Components\CartRight\Index.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<!--aside class=""offcanvas offcanvas-end"" tabindex=""-1"" id=""offcanvasRight"" aria-labelledby=""offcanvasRightLabel""-->
<aside id=""offcanvas-cart"" class=""offcanvas offcanvas-lg offcanvas-overlay offcanvas-right offcanvas-shadow"" data-lg=""true"" data-blocker=""true"" data-overlay=""true"">
<div class=""offcanvas-content"">
    <div class=""offcanvas-cart-header offcanvas-tabs"">
        <ul class=""nav nav-tabs nav-tabs-line row no-gutters"" role=""tablist"">
            <li class=""nav-item col border_"">
                <a id=""cart-tab"" class=""nav-link active show loaded"" data-toggle=""tab"" href=""#occ-cart"" role=""tab"" data-url=""/shoppingcart/offcanvasshoppingcart"" aria-selected=""true"">
                    <span class=""title"">Shopping Cart</span>
                    <span class=""badge badge-pill label-cart-amount badge-warning"" data-bind-to=""CartItemsCount""");
            BeginWriteAttribute("style", " style=\"", 964, "\"", 972, 0);
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 15 "E:\Thabis Documents\Projects\NETCore5\improweb2022_02\Views\Shared\Components\CartRight\Index.cshtml"
                                                                                                                     Write(ViewBag.countItems);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                </a>
            </li>
            <li class=""nav-item col border_"">
                <a id=""wishlist-tab"" class=""nav-link"" data-toggle=""tab"" href=""#occ-wishlist"" role=""tab"" data-url=""/shoppingcart/offcanvaswishlist"">
                    <span class=""title"">Wishlist</span>
                    <span class=""badge badge-pill label-cart-amount badge-warning"" data-bind-to=""WishlistItemsCount"" style=""display:none"">0</span>
                </a>
            </li>
            <li class=""nav-item col border_"">
                <a id=""compare-tab"" class=""nav-link"" data-toggle=""tab"" href=""#occ-compare"" role=""tab"" data-url=""/catalog/offcanvascompare"">
                    <span class=""title"">Compare</span>
                    <span class=""badge badge-pill label-cart-amount badge-warning"" data-bind-to=""CompareItemsCount"" style=""display:none"">0</span>
                </a>
            </li>
        </ul>
    </div>
    <div class=""offcanvas-cart-content border_"">
        <div class=""tab");
            WriteLiteral(@"-content"">
            <div class=""tab-pane fade active show"" id=""occ-cart"" role=""tabpanel"">
                <div class=""offcanvas-cart-body offcanvas-scrollable"">
                    <div class=""alert alert-success alert-dismissible rounded-0 fade show border_"" role=""alert"">
                        <button type=""button"" class=""close border_"" data-dismiss=""alert"" aria-label=""Close"">
                            <span aria-hidden=""true"">×</span>
                        </button>
                        <span class=""border_"">
                            The product has been successfully added to your cart
                        </span>
                    </div>
                    <div class=""alert alert-danger alert-dismissible rounded-0 fade hide border_"" role=""alert"">
                        <button type=""button"" class=""close border_"" data-dismiss=""alert"" aria-label=""Close"">
                            <span aria-hidden=""true"">×</span>
                        </button>
                       ");
            WriteLiteral(" <span class=\"border_\">\r\n                            The product could not be added to your cart!\r\n                        </span>\r\n                    </div>\r\n\r\n\r\n                    <div class=\"offcanvas-cart-items\">\r\n");
#nullable restore
#line 55 "E:\Thabis Documents\Projects\NETCore5\improweb2022_02\Views\Shared\Components\CartRight\Index.cshtml"
                     if (ViewBag.cart != null)
                    {   var i = 1;
                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 57 "E:\Thabis Documents\Projects\NETCore5\improweb2022_02\Views\Shared\Components\CartRight\Index.cshtml"
                         foreach (var productInfo in ViewBag.cart)
                        {
                            var photoName = "~/products/NoPic.jpg";
                            if(productInfo.Photo.ToString().Length > 4){
                                try{
                                    int iSplit = productInfo.Photo.ToString().LastIndexOf("/");
                                    if (iSplit > 0){
                                        string url = productInfo.Photo.ToString().Substring(0, iSplit + 1);
                                        string file = productInfo.Photo.ToString().Substring(iSplit + 1, productInfo.Photo.ToString().Length - iSplit - 1);
                                        photoName = url + "Big_" + file;
                                    }
                                }catch(Exception){
                                    throw "There is a error in GetBigProductImage the url is: " + productInfo.Photo.ToString();
                                }
                            }else{
                                photoName = "/products/NoPic.jpg";
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                            <div class=""offcanvas-cart-item"">
                                <div class=""row sm-gutters"">
                                    <div class=""col col-alpha"">
                                        <a class=""img-center-container border_"" href=""/transocean-chronograph""");
            BeginWriteAttribute("title", " title=\"", 4802, "\"", 4891, 4);
            WriteAttributeValue("", 4810, "Show", 4810, 4, true);
            WriteAttributeValue(" ", 4814, "details", 4815, 8, true);
            WriteAttributeValue(" ", 4822, "for", 4823, 4, true);
#nullable restore
#line 77 "E:\Thabis Documents\Projects\NETCore5\improweb2022_02\Views\Shared\Components\CartRight\Index.cshtml"
WriteAttributeValue(" ", 4826, Html.Encode(productInfo.Description.ToString()).Substring(0,50), 4827, 64, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                            <img");
            BeginWriteAttribute("alt", " alt=\"", 4943, "\"", 5024, 3);
            WriteAttributeValue("", 4949, "Picture", 4949, 7, true);
            WriteAttributeValue(" ", 4956, "of", 4957, 3, true);
#nullable restore
#line 78 "E:\Thabis Documents\Projects\NETCore5\improweb2022_02\Views\Shared\Components\CartRight\Index.cshtml"
WriteAttributeValue(" ", 4959, Html.Encode(productInfo.Description.ToString()).Substring(0,50), 4960, 64, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("src", " src=\"", 5025, "\"", 5050, 2);
#nullable restore
#line 78 "E:\Thabis Documents\Projects\NETCore5\improweb2022_02\Views\Shared\Components\CartRight\Index.cshtml"
WriteAttributeValue("", 5031, photoName, 5031, 10, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 5041, "?size=256", 5041, 9, true);
            EndWriteAttribute();
            BeginWriteAttribute("title", " title=\"", 5051, "\"", 5140, 4);
            WriteAttributeValue("", 5059, "Show", 5059, 4, true);
            WriteAttributeValue(" ", 5063, "details", 5064, 8, true);
            WriteAttributeValue(" ", 5071, "for", 5072, 4, true);
#nullable restore
#line 78 "E:\Thabis Documents\Projects\NETCore5\improweb2022_02\Views\Shared\Components\CartRight\Index.cshtml"
WriteAttributeValue(" ", 5075, Html.Encode(productInfo.Description.ToString()).Substring(0,50), 5076, 64, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">
                                        </a>
                                    </div>
                                    <div class=""col col-data"">
                                        <a class=""name font-weight-medium border_"" href=""/transocean-chronograph""");
            BeginWriteAttribute("title", " title=\"", 5411, "\"", 5483, 1);
#nullable restore
#line 82 "E:\Thabis Documents\Projects\NETCore5\improweb2022_02\Views\Shared\Components\CartRight\Index.cshtml"
WriteAttributeValue("", 5419, Html.Encode(productInfo.Description.ToString()).Substring(0,50), 5419, 64, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 82 "E:\Thabis Documents\Projects\NETCore5\improweb2022_02\Views\Shared\Components\CartRight\Index.cshtml"
                                                                                                                                                                                      Write(Html.Encode(productInfo.Description.ToString()).Substring(0,50));

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                                        <div class=\"short-desc text-muted claimedRight reduceDesc_ border_\">\r\n                                            ");
#nullable restore
#line 84 "E:\Thabis Documents\Projects\NETCore5\improweb2022_02\Views\Shared\Components\CartRight\Index.cshtml"
                                       Write(productInfo.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                        </div>
                                    </div>
                                </div>
                                <div class=""row sm-gutters flex-wrap align-items-center mt-2"">
                                    <div class=""col col-alpha"">
                                        <div class=""qty-input"">
                                            <div class=""input-group bootstrap-touchspin border_"">
");
#nullable restore
#line 92 "E:\Thabis Documents\Projects\NETCore5\improweb2022_02\Views\Shared\Components\CartRight\Index.cshtml"
                                                  var buttonMinus = "bootstrap-touchspin-down"+ i; 

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <span class=\"input-group-btn border_\">\r\n                                                    <button");
            BeginWriteAttribute("class", " class=\"", 6441, "\"", 6479, 3);
            WriteAttributeValue("", 6449, "btn", 6449, 3, true);
            WriteAttributeValue(" ", 6452, "btn-secondary", 6453, 14, true);
#nullable restore
#line 94 "E:\Thabis Documents\Projects\NETCore5\improweb2022_02\Views\Shared\Components\CartRight\Index.cshtml"
WriteAttributeValue(" ", 6466, buttonMinus, 6467, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" type=\"button\"");
            BeginWriteAttribute("onclick", " onclick=\"", 6494, "\"", 6513, 3);
            WriteAttributeValue("", 6504, "subst(", 6504, 6, true);
#nullable restore
#line 94 "E:\Thabis Documents\Projects\NETCore5\improweb2022_02\Views\Shared\Components\CartRight\Index.cshtml"
WriteAttributeValue("", 6510, i, 6510, 2, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 6512, ")", 6512, 1, true);
            EndWriteAttribute();
            WriteLiteral("><i class=\"fa fa-minus\"></i></button>\r\n                                                </span>\r\n                                                <span class=\"input-group-addon bootstrap-touchspin-prefix\" style=\"display: none;\"></span>\r\n");
#nullable restore
#line 97 "E:\Thabis Documents\Projects\NETCore5\improweb2022_02\Views\Shared\Components\CartRight\Index.cshtml"
                                                  var numberInput = "itemquantity"+ i; 

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                                <input class=""form-control"" data-max=""10000"" data-min=""1"" data-postfix="""" data-sci-id=""1"" data-step=""1"" data-type=""cart"" data-update-url=""/shoppingcart/updatecartitem"" data-val=""true"" data-val-number=""The field 'EnteredQuantity' must be a number.""");
            BeginWriteAttribute("id", " id=\"", 7134, "\"", 7151, 1);
#nullable restore
#line 98 "E:\Thabis Documents\Projects\NETCore5\improweb2022_02\Views\Shared\Components\CartRight\Index.cshtml"
WriteAttributeValue("", 7139, numberInput, 7139, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" name=\"quantity\" type=\"text\"");
            BeginWriteAttribute("value", " value=\"", 7180, "\"", 7209, 1);
#nullable restore
#line 98 "E:\Thabis Documents\Projects\NETCore5\improweb2022_02\Views\Shared\Components\CartRight\Index.cshtml"
WriteAttributeValue("", 7188, productInfo.Quantity, 7188, 21, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"display: block;\">\r\n                                                <span class=\"input-group-addon bootstrap-touchspin-postfix\" style=\"display: none;\"></span>\r\n");
#nullable restore
#line 100 "E:\Thabis Documents\Projects\NETCore5\improweb2022_02\Views\Shared\Components\CartRight\Index.cshtml"
                                                  var buttonAdd = "bootstrap-touchspin-up"+ i; 

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <span class=\"input-group-btn border_\">\r\n                                                    <button");
            BeginWriteAttribute("class", " class=\"", 7622, "\"", 7658, 3);
            WriteAttributeValue("", 7630, "btn", 7630, 3, true);
            WriteAttributeValue(" ", 7633, "btn-secondary", 7634, 14, true);
#nullable restore
#line 102 "E:\Thabis Documents\Projects\NETCore5\improweb2022_02\Views\Shared\Components\CartRight\Index.cshtml"
WriteAttributeValue(" ", 7647, buttonAdd, 7648, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" type=\"button\"");
            BeginWriteAttribute("onclick", " onclick=\"", 7673, "\"", 7690, 3);
            WriteAttributeValue("", 7683, "add(", 7683, 4, true);
#nullable restore
#line 102 "E:\Thabis Documents\Projects\NETCore5\improweb2022_02\Views\Shared\Components\CartRight\Index.cshtml"
WriteAttributeValue("", 7687, i, 7687, 2, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 7689, ")", 7689, 1, true);
            EndWriteAttribute();
            WriteLiteral(@"><i class=""fa fa-plus""></i></button>
                                                </span>
                                            </div>
                                        </div>
                                    </div>
                                    <div class=""col"">
                                        <span class=""price unit-price border_"">
                                            R");
#nullable restore
#line 109 "E:\Thabis Documents\Projects\NETCore5\improweb2022_02\Views\Shared\Components\CartRight\Index.cshtml"
                                         Write(productInfo.PurchasePrice * productInfo.Quantity);

#line default
#line hidden
#nullable disable
            WriteLiteral(" Inc VAT\r\n                                        </span>\r\n                                    </div>\r\n                                    <div class=\"col ml-auto text-nowrap border_\">\r\n                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7d4db8b433000231f6f10085e2ff5987cdf8f59524555", async() => {
                WriteLiteral("\r\n                                            <i class=\"fal fa-heart\"></i>\r\n                                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 113 "E:\Thabis Documents\Projects\NETCore5\improweb2022_02\Views\Shared\Components\CartRight\Index.cshtml"
                                                                                                WriteLiteral(productInfo.ProdID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 113 "E:\Thabis Documents\Projects\NETCore5\improweb2022_02\Views\Shared\Components\CartRight\Index.cshtml"
                                                                                                                                         WriteLiteral(Context.Request.GetEncodedUrl());

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["redirect"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-redirect", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["redirect"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 113 "E:\Thabis Documents\Projects\NETCore5\improweb2022_02\Views\Shared\Components\CartRight\Index.cshtml"
                                                                                                                                                                                                                                                                                              Write(Html.Encode(productInfo.Description.ToString()).Substring(0,50));

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("data-name", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7d4db8b433000231f6f10085e2ff5987cdf8f59529288", async() => {
                WriteLiteral("\r\n                                            <i class=\"fal fa-trash-alt\"></i>\r\n                                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_9.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_9);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_10.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_10);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 116 "E:\Thabis Documents\Projects\NETCore5\improweb2022_02\Views\Shared\Components\CartRight\Index.cshtml"
                                                                                                                                                                                    WriteLiteral(productInfo.ProdID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 116 "E:\Thabis Documents\Projects\NETCore5\improweb2022_02\Views\Shared\Components\CartRight\Index.cshtml"
                                                                                                                                                                                                                           Write(Html.Encode(productInfo.Description.ToString()).Substring(0,50));

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("data-name", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_11);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                    </div>\r\n                                </div>\r\n                            </div>\r\n");
#nullable restore
#line 122 "E:\Thabis Documents\Projects\NETCore5\improweb2022_02\Views\Shared\Components\CartRight\Index.cshtml"

                            i++;
                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 124 "E:\Thabis Documents\Projects\NETCore5\improweb2022_02\Views\Shared\Components\CartRight\Index.cshtml"
                         
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    </div>
                </div>
                <div class=""offcanvas-cart-footer border_"">
                    <div class=""offcanvas-cart-footer-row"">
                        <div class=""offcanvas-cart-footer-col mr-3"">
                            <div>
                                <div class=""sub-total-caption border_"">
                                    Subtotal:
                                </div>
                                <div class=""sub-total price border_"">
                                    R ");
#nullable restore
#line 136 "E:\Thabis Documents\Projects\NETCore5\improweb2022_02\Views\Shared\Components\CartRight\Index.cshtml"
                                 Write(ViewBag.Total);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" Inc VAT
                                </div>
                            </div>
                        </div>
                        <div class=""offcanvas-cart-footer-col row sm-gutters d-flex flex-wrap"">
                            <div class=""col"">
                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7d4db8b433000231f6f10085e2ff5987cdf8f59534827", async() => {
                WriteLiteral("\r\n                                    Go to cart\r\n                                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_9.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_9);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_12.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_12);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_13);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                            </div>
                            <div class=""col border_"">
                                <a class=""btn btn-clear btn-block btn-action border_"" href=""/login?checkoutAsGuest=True&amp;returnUrl=%2Fcart"">
                                    <i class=""fa fa-check""></i>
                                    <span>Checkout</span>
                                </a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class=""tab-pane fade"" id=""occ-wishlist"" role=""tabpanel""></div>
                <div class=""tab-pane fade"" id=""occ-compare"" role=""tabpanel""></div>
                    <div class=""throbber small white"" style=""visibility: visible; display: none; opacity: 0;"">
                        <div class=""throbber-flex""><div>
                            <div class=""throbber-content hide""></div>
                                <div class=""spinner active"">
                ");
            WriteLiteral(@"                    <svg style=""width:50px; height:50px"" viewBox=""0 0 64 64""><circle class=""circle"" cx=""32"" cy=""32"" r=""29"" fill=""none"" stroke-width=""3""></circle></svg>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</aside>

<script>
    function add(i) {
        //let form = document.getElementById(""cartform"");
        var a = $(""#itemquantity""+ i ).val();
        a++;
        if (a && a >= 1) {
            $("".bootstrap-touchspin-down""+ i ).removeAttr(""disabled"");
        }
        $(""#itemquantity""+ i ).val(a);
        $( ""#cartform"" ).delay(60000).submit();
    };
    function subst(i) {
        //let form = document.getElementById(""cartform"");
        var b = $(""#itemquantity""+ i).val();
        // this is wrong part
        if (b && b >= 1) {
            b--;
            $(""#itemquantity""+ i ).val(b);
            $( ""#cartfo");
            WriteLiteral("rm\" ).delay(60000).submit();\r\n        }\r\n        else {\r\n            $(\".bootstrap-touchspin-down\"+ i ).attr(\"disabled\", \"disabled\");\r\n        }\r\n    };\r\n</script>");
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
