#pragma checksum "E:\Thabis Documents\Projects\NETCore5\improweb2022_02\Views\Cart\Payment.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a33f18b4d4b0e4c1d5ebc83058c12ac9e9dde715"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Cart_Payment), @"mvc.1.0.view", @"/Views/Cart/Payment.cshtml")]
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
#line 5 "E:\Thabis Documents\Projects\NETCore5\improweb2022_02\Views\Cart\Payment.cshtml"
using improweb2022_02.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "E:\Thabis Documents\Projects\NETCore5\improweb2022_02\Views\Cart\Payment.cshtml"
using Microsoft.AspNetCore.Http.Extensions;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a33f18b4d4b0e4c1d5ebc83058c12ac9e9dde715", @"/Views/Cart/Payment.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a829fd9fd4a7d7b282679c9221c2e7d0c09dbf94", @"/Views/_ViewImports.cshtml")]
    public class Views_Cart_Payment : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<improweb2022_02.ViewModels.CountryViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("title", new global::Microsoft.AspNetCore.Html.HtmlString("Top"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("itemprop", new global::Microsoft.AspNetCore.Html.HtmlString("item"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "cart", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("title", new global::Microsoft.AspNetCore.Html.HtmlString("Cart"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "BillingAddress", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("costep-link"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Shipping", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-secondary btn-lg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("/frontend/en/checkout/shippingmethod"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_11 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "E:\Thabis Documents\Projects\NETCore5\improweb2022_02\Views\Cart\Payment.cshtml"
  
    ViewData["Title"] = "Shopping Cart";
    Layout = "~/Views/Shared/_UserLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div id=\"content\" class=\"container\">\r\n    <div class=\"row\">\r\n        <!-- #region BreadCrump -->\r\n        <div class=\"breadcrumb-container d-none d-md-flex flex-wrap align-items-center mb-4 border_\">\r\n            <ol class=\"breadcrumb mb-0 border_\"");
            BeginWriteAttribute("itemscope", " itemscope=\"", 480, "\"", 492, 0);
            EndWriteAttribute();
            WriteLiteral(" itemtype=\"http://schema.org/BreadcrumbList\">\r\n                <li class=\"breadcrumb-item\" itemprop=\"itemListElement\"");
            BeginWriteAttribute("itemscope", " itemscope=\"", 610, "\"", 622, 0);
            EndWriteAttribute();
            WriteLiteral(" itemtype=\"http://schema.org/ListItem\">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a33f18b4d4b0e4c1d5ebc83058c12ac9e9dde7158554", async() => {
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
            BeginWriteAttribute("itemscope", " itemscope=\"", 1065, "\"", 1077, 0);
            EndWriteAttribute();
            WriteLiteral(" itemtype=\"http://schema.org/ListItem\">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a33f18b4d4b0e4c1d5ebc83058c12ac9e9dde71510617", async() => {
                WriteLiteral("\r\n                        <meta itemprop=\"position\" content=\"2\"><span itemprop=\"name\" dir=\"auto\">Cart Items</span>\r\n                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </li>\r\n                <li class=\"breadcrumb-item\" itemprop=\"itemListElement\"");
            BeginWriteAttribute("itemscope", " itemscope=\"", 1447, "\"", 1459, 0);
            EndWriteAttribute();
            WriteLiteral(" itemtype=\"http://schema.org/ListItem\">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a33f18b4d4b0e4c1d5ebc83058c12ac9e9dde71512601", async() => {
                WriteLiteral("\r\n                        <meta itemprop=\"position\" content=\"2\"><span itemprop=\"name\" dir=\"auto\">Address</span>\r\n                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
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
                <span>Payment</span>
            </div>
        </div>
        <!-- #endregion -->
    </div>
    <div id=""content-body"" class=""row"">
        <!-- #region Product Detail -->
        <div id=""content-center"" class=""col-lg-12 border_"">
            <div class=""costeps row no-gutters"">
                <div class=""col-2 costep visited border_"" data-step=""cart"">
                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a33f18b4d4b0e4c1d5ebc83058c12ac9e9dde71514788", async() => {
                WriteLiteral("\r\n                        <i class=\"costep-icon\"></i>\r\n                        <span class=\"costep-label\">Cart</span>\r\n                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </div>\r\n                <div class=\"col-2 costep visited border_\" data-step=\"address\">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a33f18b4d4b0e4c1d5ebc83058c12ac9e9dde71516508", async() => {
                WriteLiteral("\r\n                        <i class=\"costep-icon\"></i>\r\n                        <span class=\"costep-label\">Address</span>\r\n                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </div>\r\n                <div class=\"col-2 costep visited border_\" data-step=\"shipping\">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a33f18b4d4b0e4c1d5ebc83058c12ac9e9dde71518232", async() => {
                WriteLiteral("\r\n                        <i class=\"costep-icon\"></i>\r\n                        <span class=\"costep-label\">Shipping</span>\r\n                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_8.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                </div>
                <div class=""col-2 costep active border_"" data-step=""payment"">
                    <a class=""costep-link"" href=""javascript:void(0)"">
                        <i class=""costep-icon""></i>
                        <span class=""costep-label"">Payment</span>
                    </a>
                </div>
                <div class=""col-2 costep inactive border_"" data-step=""confirm"">
                    <a class=""costep-link"" href=""javascript:void(0)"">
                        <i class=""costep-icon""></i>
                        <span class=""costep-label"">Confirm</span>
                    </a>
                </div>
                <div class=""col-2 costep inactive border_"" data-step=""complete"">
                    <a class=""costep-link"" href=""javascript:void(0)"">
                        <i class=""costep-icon""></i>
                        <span class=""costep-label"">Complete</span>
                    </a>
                </div>
            </div>
        </di");
            WriteLiteral(@"v>

        <div id=""content-center"" class=""col-lg-12 border_"">
            <div class=""page shopping-cart-page"">
                <div class=""page-title border_"">
                    <h1 class=""h3"">Select payment method</h1>
                </div>
                <div class=""page-body checkout-data"">
                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a33f18b4d4b0e4c1d5ebc83058c12ac9e9dde71521255", async() => {
                WriteLiteral(@"				
                        <ul class=""list-group opt-list payment-methods"">
                            <li class=""list-group-item opt-list-item payment-method-item active"">
                                <div class=""opt-data"">
                                    <div class=""form-check opt-control option-name radio"">
                                        <input id=""paymentmethod_0"" type=""radio"" name=""paymentmethod"" data-has-info=""true"" data-lazy-info=""false"" class=""opt-radio form-check-input"" value=""Payments.Prepayment"" checked=""checked"">
                                        <label class=""form-check-label"" for=""paymentmethod_0"">
                                            <span class=""opt-name"">Prepayment</span>
                                        </label>
                                    </div>    
                                </div>
                                <div class=""opt-info payment-method-info"" data-system-name=""Payments.Prepayment"">
                                 ");
                WriteLiteral(@"   <div class=""text-muted"">
                                        Once your order is placed, you will be contacted by our staff to confirm the order.
                                    </div>
                                </div>
                            </li>
                            <li class=""list-group-item opt-list-item payment-method-item"">
                                <div class=""opt-data"">
                                    <div class=""form-check opt-control option-name radio"">
                                        <input id=""paymentmethod_1"" type=""radio"" name=""paymentmethod"" data-has-info=""true"" data-lazy-info=""false"" class=""opt-radio form-check-input"" value=""Payments.PayInStore"">
                                        <label class=""form-check-label"" for=""paymentmethod_1"">
                                            <span class=""opt-name"">Pay in store</span>
                                        </label>
                                    </div>  
                    ");
                WriteLiteral(@"            </div>
                                <div class=""opt-info payment-method-info"" data-system-name=""Payments.PayInStore"">
                                    <div class=""text-muted"">
                                        Reserve items at your local store, and pay in store when you pick up your order.
                                    </div>
                                </div>
                            </li>
                            <li class=""list-group-item opt-list-item payment-method-item"">
                                <div class=""opt-data"">
                                    <div class=""form-check opt-control option-name radio"">
                                        <input id=""paymentmethod_2"" type=""radio"" name=""paymentmethod"" data-has-info=""true"" data-lazy-info=""true"" class=""opt-radio form-check-input"" value=""Payments.Manual"">
                                        <label class=""form-check-label"" for=""paymentmethod_2"">
                                            ");
                WriteLiteral(@"<span class=""opt-name"">Credit card (manual)</span>
                                        </label>
                                    </div>         
                                </div>
                            </li>
                            <li class=""list-group-item opt-list-item payment-method-item"">
                                <div class=""opt-data"">
                                    <div class=""form-check opt-control option-name radio"">
                                        <input id=""paymentmethod_3"" type=""radio"" name=""paymentmethod"" data-has-info=""true"" data-lazy-info=""false"" class=""opt-radio form-check-input"" value=""Payments.CashOnDelivery"">
                                        <label class=""form-check-label"" for=""paymentmethod_3"">
                                            <span class=""opt-name"">Cash on delivery</span>
                                        </label>
                                    </div>                               
                          ");
                WriteLiteral(@"      </div>
                                <div class=""opt-info payment-method-info"" data-system-name=""Payments.CashOnDelivery"">
                                    <div class=""text-muted"">
                                        Once your order is placed, you will be contacted by our staff to confirm the order.
                                    </div>
                                </div>
                            </li>
                        </ul>
                        <div class=""buttons"">
                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a33f18b4d4b0e4c1d5ebc83058c12ac9e9dde71526424", async() => {
                    WriteLiteral("\r\n                                <i class=\"fa fa-angle-left\"></i>\r\n                                <span>Back</span>\r\n                            ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_6.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"    
                            <input type=""submit"" name=""nextstep"" id=""nextstep"" class=""d-none"">
                            <button class=""btn btn-warning btn-lg shipping-method-next-step-button"" onclick=""$('#nextstep').trigger('click');return false;"">
                                <span>Next</span>
                                <i class=""fa fa-angle-right""></i>
                            </button>
                        </div>
                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_10);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_11.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_11);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("    \r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<improweb2022_02.ViewModels.CountryViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591