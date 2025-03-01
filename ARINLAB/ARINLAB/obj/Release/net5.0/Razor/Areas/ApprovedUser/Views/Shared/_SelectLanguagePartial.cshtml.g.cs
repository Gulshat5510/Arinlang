#pragma checksum "D:\Work\ARINLAB\ARINLAB\ARINLAB\Areas\ApprovedUser\Views\Shared\_SelectLanguagePartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e8c72b049b6356df182263fcc356c0a8c4d37c4c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_ApprovedUser_Views_Shared__SelectLanguagePartial), @"mvc.1.0.view", @"/Areas/ApprovedUser/Views/Shared/_SelectLanguagePartial.cshtml")]
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
#line 2 "D:\Work\ARINLAB\ARINLAB\ARINLAB\Areas\ApprovedUser\Views\_ViewImports.cshtml"
using ARINLAB;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Work\ARINLAB\ARINLAB\ARINLAB\Areas\ApprovedUser\Views\_ViewImports.cshtml"
using System.Globalization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "D:\Work\ARINLAB\ARINLAB\ARINLAB\Areas\ApprovedUser\Views\Shared\_SelectLanguagePartial.cshtml"
using Microsoft.AspNetCore.Builder;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Work\ARINLAB\ARINLAB\ARINLAB\Areas\ApprovedUser\Views\Shared\_SelectLanguagePartial.cshtml"
using Microsoft.AspNetCore.Localization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Work\ARINLAB\ARINLAB\ARINLAB\Areas\ApprovedUser\Views\Shared\_SelectLanguagePartial.cshtml"
using Microsoft.AspNetCore.Mvc.Localization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Work\ARINLAB\ARINLAB\ARINLAB\Areas\ApprovedUser\Views\Shared\_SelectLanguagePartial.cshtml"
using Microsoft.Extensions.Options;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e8c72b049b6356df182263fcc356c0a8c4d37c4c", @"/Areas/ApprovedUser/Views/Shared/_SelectLanguagePartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5944270c8b5d9816cf52d026e4a62ac0184f904f", @"/Areas/ApprovedUser/Views/_ViewImports.cshtml")]
    public class Areas_ApprovedUser_Views_Shared__SelectLanguagePartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "SetLanguage", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("py-1 hover:text-white"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 7 "D:\Work\ARINLAB\ARINLAB\ARINLAB\Areas\ApprovedUser\Views\Shared\_SelectLanguagePartial.cshtml"
  
    // получаем сервис IRequestCultureFeature
    var requestCulture = Context.Features.Get<IRequestCultureFeature>();
    // получаем список поддерживаемых культур
    var cultureItems = LocOptions.Value.SupportedUICultures.Where(p => p.Name != requestCulture.RequestCulture.Culture.Name)
        .Select(c => new SelectListItem { Value = c.Name, Text = c.NativeName.Substring(0, 1).ToUpper() + c.NativeName.Substring(1) })
        .ToList();

    List<SelectListItem> lngListItem = new List<SelectListItem>();
    foreach (var c in cultureItems)
    {
        if (c.Text == "Türkmen dili")
        {
            c.Text = "Türkmen";
        }
        lngListItem.Add(c);
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 26 "D:\Work\ARINLAB\ARINLAB\ARINLAB\Areas\ApprovedUser\Views\Shared\_SelectLanguagePartial.cshtml"
     if (requestCulture.RequestCulture.UICulture.NativeName == "Türkmen dili")
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <span class=\"hover:text-white\"> Türkmen </span>\r\n");
#nullable restore
#line 29 "D:\Work\ARINLAB\ARINLAB\ARINLAB\Areas\ApprovedUser\Views\Shared\_SelectLanguagePartial.cshtml"
    }
    else
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <span class=\"hover:text-white\"> ");
#nullable restore
#line 32 "D:\Work\ARINLAB\ARINLAB\ARINLAB\Areas\ApprovedUser\Views\Shared\_SelectLanguagePartial.cshtml"
                                    Write(requestCulture.RequestCulture.UICulture.NativeName.Substring(0, 1).ToUpper() + requestCulture.RequestCulture.UICulture.NativeName.Substring(1));

#line default
#line hidden
#nullable disable
            WriteLiteral(" </span>\r\n");
#nullable restore
#line 33 "D:\Work\ARINLAB\ARINLAB\ARINLAB\Areas\ApprovedUser\Views\Shared\_SelectLanguagePartial.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    \r\n\r\n\r\n<li class=\"adomx-dropdown position-relative col-auto\">\r\n    <a class=\"toggle\" href=\"#\"><img class=\"lang-flag\" src=\"assets/images/flags/flag-1.jpg\"");
            BeginWriteAttribute("alt", " alt=\"", 1484, "\"", 1490, 0);
            EndWriteAttribute();
            WriteLiteral("><i class=\"zmdi zmdi-caret-down drop-arrow\"></i></a>\r\n\r\n    <!-- Dropdown -->\r\n    <ul class=\"adomx-dropdown-menu dropdown-menu-language\">\r\n        <li>\r\n");
#nullable restore
#line 44 "D:\Work\ARINLAB\ARINLAB\ARINLAB\Areas\ApprovedUser\Views\Shared\_SelectLanguagePartial.cshtml"
             foreach (var lng in lngListItem)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e8c72b049b6356df182263fcc356c0a8c4d37c4c8248", async() => {
                WriteLiteral("<img src=\"assets/images/flags/flag-1.jpg\"");
                BeginWriteAttribute("alt", " alt=\"", 1972, "\"", 1978, 0);
                EndWriteAttribute();
                WriteLiteral(">");
#nullable restore
#line 48 "D:\Work\ARINLAB\ARINLAB\ARINLAB\Areas\ApprovedUser\Views\Shared\_SelectLanguagePartial.cshtml"
                                                                                              Write(lng.Text);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-returnUrl", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 47 "D:\Work\ARINLAB\ARINLAB\ARINLAB\Areas\ApprovedUser\Views\Shared\_SelectLanguagePartial.cshtml"
                            WriteLiteral(Context.Request.Path);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["returnUrl"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-returnUrl", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["returnUrl"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 47 "D:\Work\ARINLAB\ARINLAB\ARINLAB\Areas\ApprovedUser\Views\Shared\_SelectLanguagePartial.cshtml"
                                                                      WriteLiteral(lng.Value);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["culture"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-culture", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["culture"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 49 "D:\Work\ARINLAB\ARINLAB\ARINLAB\Areas\ApprovedUser\Views\Shared\_SelectLanguagePartial.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </li>\r\n        \r\n    </ul>\r\n\r\n</li>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IOptions<RequestLocalizationOptions> LocOptions { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IViewLocalizer Localizer { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IHtmlLocalizer<SharedResource> SharedLocalizer { get; private set; }
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
