#pragma checksum "E:\Thabis Documents\Projects\NETCore5\improweb2022_02\Views\Shared\Components\Banner\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "018ff882afff03e0c416742830a9ec8bfb14009e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_Banner_Index), @"mvc.1.0.view", @"/Views/Shared/Components/Banner/Index.cshtml")]
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
#line 2 "E:\Thabis Documents\Projects\NETCore5\improweb2022_02\Views\_ViewImports.cshtml"
using improweb2022_02.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"018ff882afff03e0c416742830a9ec8bfb14009e", @"/Views/Shared/Components/Banner/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a829fd9fd4a7d7b282679c9221c2e7d0c09dbf94", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_Banner_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("d-block w-100"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("..."), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "E:\Thabis Documents\Projects\NETCore5\improweb2022_02\Views\Shared\Components\Banner\Index.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<div id=\"carouselExampleSlidesOnly\" class=\"carousel slide carousel-fade\" data-bs-ride=\"carousel\">\r\n    <div class=\"carousel-inner border_\">\r\n");
#nullable restore
#line 8 "E:\Thabis Documents\Projects\NETCore5\improweb2022_02\Views\Shared\Components\Banner\Index.cshtml"
           
            var index = 0;
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "E:\Thabis Documents\Projects\NETCore5\improweb2022_02\Views\Shared\Components\Banner\Index.cshtml"
         foreach (var banner in Model)
        {   
            var slideActive = "";
            if(index == 0){
                slideActive = "active";
            }        

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div");
            BeginWriteAttribute("class", " class=\"", 422, "\"", 456, 2);
            WriteAttributeValue("", 430, "carousel-item", 430, 13, true);
#nullable restore
#line 17 "E:\Thabis Documents\Projects\NETCore5\improweb2022_02\Views\Shared\Components\Banner\Index.cshtml"
WriteAttributeValue(" ", 443, slideActive, 444, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "018ff882afff03e0c416742830a9ec8bfb14009e5363", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 486, "~/Bannersx/", 486, 11, true);
#nullable restore
#line 18 "E:\Thabis Documents\Projects\NETCore5\improweb2022_02\Views\Shared\Components\Banner\Index.cshtml"
AddHtmlAttributeValue("", 497, banner.Photo, 497, 13, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </div>\r\n");
#nullable restore
#line 20 "E:\Thabis Documents\Projects\NETCore5\improweb2022_02\Views\Shared\Components\Banner\Index.cshtml"
            index++;
        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    </div>
    <button class=""carousel-control-prev"" type=""button"" data-bs-target=""#carouselExampleControls"" data-bs-slide=""prev"">
            <span class=""carousel-control-prev-icon"" aria-hidden=""true""></span>
            <span class=""visually-hidden"">Previous</span>
        </button>
    <button class=""carousel-control-next"" type=""button"" data-bs-target=""#carouselExampleControls"" data-bs-slide=""next"">
            <span class=""carousel-control-next-icon"" aria-hidden=""true""></span>
            <span class=""visually-hidden"">Next</span>
        </button>
</div>  

");
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
