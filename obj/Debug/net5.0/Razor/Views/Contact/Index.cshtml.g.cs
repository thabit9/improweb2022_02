#pragma checksum "E:\Thabis Documents\Projects\NETCore5\improweb2022_02\Views\Contact\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "77a54511d41d82c34671366ced977e1abea21dbd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Contact_Index), @"mvc.1.0.view", @"/Views/Contact/Index.cshtml")]
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
#line 4 "E:\Thabis Documents\Projects\NETCore5\improweb2022_02\Views\Contact\Index.cshtml"
using improweb2022_02.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "E:\Thabis Documents\Projects\NETCore5\improweb2022_02\Views\Contact\Index.cshtml"
using Microsoft.AspNetCore.Http.Extensions;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"77a54511d41d82c34671366ced977e1abea21dbd", @"/Views/Contact/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a829fd9fd4a7d7b282679c9221c2e7d0c09dbf94", @"/Views/_ViewImports.cshtml")]
    public class Views_Contact_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("title", new global::Microsoft.AspNetCore.Html.HtmlString("Top"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("itemprop", new global::Microsoft.AspNetCore.Html.HtmlString("item"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("/frontend/en/contactus"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("contact-form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("novalidate", new global::Microsoft.AspNetCore.Html.HtmlString("novalidate"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 1 "E:\Thabis Documents\Projects\NETCore5\improweb2022_02\Views\Contact\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div id=""content-wrapper"">
    <section id=""content"" class=""container"">
        <div class=""row"">
            <!-- #region BreadCrump -->
            <div class=""breadcrumb-container d-none d-md-flex flex-wrap align-items-center mb-4 border_"">
                <ol class=""breadcrumb mb-0 border_""");
            BeginWriteAttribute("itemscope", " itemscope=\"", 424, "\"", 436, 0);
            EndWriteAttribute();
            WriteLiteral(" itemtype=\"http://schema.org/BreadcrumbList\">\r\n                    <li class=\"breadcrumb-item\" itemprop=\"itemListElement\"");
            BeginWriteAttribute("itemscope", " itemscope=\"", 558, "\"", 570, 0);
            EndWriteAttribute();
            WriteLiteral(" itemtype=\"http://schema.org/ListItem\">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "77a54511d41d82c34671366ced977e1abea21dbd7241", async() => {
                WriteLiteral("\r\n                            <meta itemprop=\"name\" content=\"Home page\" />\r\n                            <meta itemprop=\"position\" content=\"1\" />\r\n                            <i class=\"fa fa-home\"></i>\r\n                        ");
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
            WriteLiteral(@"
                    </li>
                </ol>
                <div class=""breadcrumb-item active border_"">
                    <span>Contact Us</span>
                </div>
            </div>
            <!-- #endregion -->
        </div>
        <div id=""content-body"" class=""row"">
            <div id=""content-center"" class=""col-lg-12 border_"">
                <div class=""page contact-page border_"">
                    <div class=""page-title border_"">
                        <h1 class=""h2"">Contact Us</h1>
                    </div>
                    <div class=""topic-html-content-body lead my-3 html-editor-content"" id=""ph-topic-body-4"">
                        <table border=""0"" cellpadding=""0"" cellspacing=""0"" style=""width: 100%;"">
                            <tbody>
                                <tr>
                                <td style=""width: 36px;""><i class=""fa fa-fw fa-home""></i>
                                </td>
                                <td style=""width: 1445p");
            WriteLiteral("x;\">\r\n");
#nullable restore
#line 40 "E:\Thabis Documents\Projects\NETCore5\improweb2022_02\Views\Contact\Index.cshtml"
                                     if(ViewBag.Organisations.OrgStreet1 != null){
                                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 41 "E:\Thabis Documents\Projects\NETCore5\improweb2022_02\Views\Contact\Index.cshtml"
                                   Write(ViewBag.Organisations.OrgStreet1);

#line default
#line hidden
#nullable disable
            WriteLiteral("<span>,</span>   \r\n");
#nullable restore
#line 42 "E:\Thabis Documents\Projects\NETCore5\improweb2022_02\Views\Contact\Index.cshtml"
                                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 43 "E:\Thabis Documents\Projects\NETCore5\improweb2022_02\Views\Contact\Index.cshtml"
                                     if(ViewBag.Organisations.OrgStreet2 != null){
                                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 44 "E:\Thabis Documents\Projects\NETCore5\improweb2022_02\Views\Contact\Index.cshtml"
                                   Write(ViewBag.Organisations.OrgStreet2);

#line default
#line hidden
#nullable disable
            WriteLiteral("<span>,</span>   \r\n");
#nullable restore
#line 45 "E:\Thabis Documents\Projects\NETCore5\improweb2022_02\Views\Contact\Index.cshtml"
                                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 46 "E:\Thabis Documents\Projects\NETCore5\improweb2022_02\Views\Contact\Index.cshtml"
                                     if(ViewBag.Organisations.OrgStreet3 != null){
                                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 47 "E:\Thabis Documents\Projects\NETCore5\improweb2022_02\Views\Contact\Index.cshtml"
                                   Write(ViewBag.Organisations.OrgStreet3);

#line default
#line hidden
#nullable disable
            WriteLiteral("<span>,</span> \r\n");
#nullable restore
#line 48 "E:\Thabis Documents\Projects\NETCore5\improweb2022_02\Views\Contact\Index.cshtml"
                                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 49 "E:\Thabis Documents\Projects\NETCore5\improweb2022_02\Views\Contact\Index.cshtml"
                                     if(ViewBag.Organisations.OrgStreet4 != null){
                                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 50 "E:\Thabis Documents\Projects\NETCore5\improweb2022_02\Views\Contact\Index.cshtml"
                                   Write(ViewBag.Organisations.OrgStreet4);

#line default
#line hidden
#nullable disable
            WriteLiteral("<span>,</span>   \r\n");
#nullable restore
#line 51 "E:\Thabis Documents\Projects\NETCore5\improweb2022_02\Views\Contact\Index.cshtml"
                                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 52 "E:\Thabis Documents\Projects\NETCore5\improweb2022_02\Views\Contact\Index.cshtml"
                                     if(ViewBag.Organisations.OrgStreet5 != null){
                                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 53 "E:\Thabis Documents\Projects\NETCore5\improweb2022_02\Views\Contact\Index.cshtml"
                                   Write(ViewBag.Organisations.OrgStreet5);

#line default
#line hidden
#nullable disable
#nullable restore
#line 53 "E:\Thabis Documents\Projects\NETCore5\improweb2022_02\Views\Contact\Index.cshtml"
                                                                         
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                </td>
                                </tr>
                                <tr>
                                <td style=""width: 36px;""><i class=""fa fa-fw fa-phone""></i>
                                </td>
                                <td style=""width: 1445px;"">Phone: ");
#nullable restore
#line 60 "E:\Thabis Documents\Projects\NETCore5\improweb2022_02\Views\Contact\Index.cshtml"
                                                             Write(ViewBag.Organisations.OrgTel1);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                </td>
                                </tr>
                                <tr>
                                <td style=""width: 36px;""><i class=""fa fa-fw fa-fax""></i>
                                </td>
                                <td style=""width: 1445px;"">Fax: ");
#nullable restore
#line 66 "E:\Thabis Documents\Projects\NETCore5\improweb2022_02\Views\Contact\Index.cshtml"
                                                           Write(ViewBag.Organisations.OrgFax);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                </td>
                                </tr>
                                <tr>
                                <td style=""width: 36px;""><i class=""fa fa-fw fa-globe""></i>
                                </td>
                                <td style=""width: 1445px;"">Website: www.esquireshop.com
                                </td>
                                </tr>
                                <tr>
                                <td style=""width: 36px;""><i class=""fa fa-fw fa-envelope""></i>
                                </td>
                                <td style=""width: 1445px;"">Email: info@esquire.co.za
                                </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                    <div class=""page-body"">
                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "77a54511d41d82c34671366ced977e1abea21dbd16209", async() => {
                WriteLiteral(@"
                        <div class=""form-group row"">
                            <label class=""col-sm-3 col-form-label"" for=""FullName"">Your name</label>
                            <div class=""col-sm-9"">
                                <input class=""form-control"" id=""FullName"" name=""FullName"" placeholder=""Optional"" type=""text""");
                BeginWriteAttribute("value", " value=\"", 5058, "\"", 5066, 0);
                EndWriteAttribute();
                WriteLiteral(@">
                                <span class=""field-validation-valid"" data-valmsg-for=""FullName"" data-valmsg-replace=""true""></span>
                            </div>
                        </div>
                        <div class=""form-group row"">
                            <label class=""col-sm-3 col-form-label required"" for=""Email"">Your email</label>
                            <div class=""col-sm-9"">
                                <input class=""form-control"" data-val=""true"" data-val-email=""'Your email' is not a valid email address."" data-val-required="""" id=""Email"" name=""Email"" type=""email""");
                BeginWriteAttribute("value", " value=\"", 5677, "\"", 5685, 0);
                EndWriteAttribute();
                WriteLiteral(@">
                                <span class=""field-validation-valid"" data-valmsg-for=""Email"" data-valmsg-replace=""true""></span>
                            </div>
                        </div>
                        <div class=""form-group row"">
                            <label class=""col-sm-3 col-form-label required"" for=""Enquiry"">Enquiry</label>
                            <div class=""col-sm-9"">
                                <textarea class=""form-control"" cols=""20"" data-val=""true"" data-val-required="""" id=""Enquiry"" name=""Enquiry"" placeholder=""Enter your enquiry"" rows=""6""></textarea>
                                <span class=""field-validation-valid"" data-valmsg-for=""Enquiry"" data-valmsg-replace=""true""></span>
                            </div>
                        </div>
                        <div class=""form-group row"">
                            <div class=""col col-sm-auto offset-sm-3 text-muted"">
                                * Input elements with asterisk are required and hav");
                WriteLiteral(@"e to be filled out.
                            </div>
                        </div>
                        <div class=""row justify-content-end"">
                            <div class=""col-sm-9"">
                                <div class=""form-group row gdpr-consent "">
                                    <div class=""col form-control-plaintext"">
                                        <div class=""form-check"">
                                            <input class=""form-check-input gdpr-consent-check"" id=""gdpr-consent-716956774"" name=""GdprConsent"" type=""checkbox"" value=""true""><input name=""GdprConsent"" type=""hidden"" value=""false"">
                                            <label class=""form-check-label"" for=""gdpr-consent-716956774"">
                                                Yes I've read the <a href=""/frontend/en/privacyinfo"">privacy terms</a> and agree that my data given by me can be stored electronically. My data will thereby only be used to process my inquiry.
                        ");
                WriteLiteral(@"                    </label>
                                        </div>
                                        <span class=""field-validation-valid"" data-valmsg-for=""GdprConsent"" data-valmsg-replace=""true""></span>
                                    </div>
                                </div>	
					        </div>
				        </div>
				        <div class=""form-group row"">
                            <div class=""col col-sm-auto offset-sm-3"">
                                <button type=""submit"" name=""send-email"" class=""btn btn-primary btn-lg btn-block"">
                                    Submit
                                </button>
                            </div>
				        </div>
                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </section>\r\n</div>");
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
