#pragma checksum "C:\Users\vogia\Documents\GitHub\ShippingMark\ShippingMark\Views\Shared\_PagingNavBar.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "d51722fdb985700a4324a6f3e7c0073049a2197c425db811aa60532a309b04ab"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__PagingNavBar), @"mvc.1.0.view", @"/Views/Shared/_PagingNavBar.cshtml")]
namespace AspNetCore
{
    #line default
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using global::Microsoft.AspNetCore.Mvc;
    using global::Microsoft.AspNetCore.Mvc.Rendering;
    using global::Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\vogia\Documents\GitHub\ShippingMark\ShippingMark\Views\_ViewImports.cshtml"
using ShippingMark

#nullable disable
    ;
#nullable restore
#line 2 "C:\Users\vogia\Documents\GitHub\ShippingMark\ShippingMark\Views\_ViewImports.cshtml"
using ShippingMark.Models

#line default
#line hidden
#nullable disable
    ;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"d51722fdb985700a4324a6f3e7c0073049a2197c425db811aa60532a309b04ab", @"/Views/Shared/_PagingNavBar.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"531549698ccb11ef1ede3ebdc5393c8a69d1742c1fba3e3c2c204c181cc0f055", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Shared__PagingNavBar : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_PageSizeModal", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "d51722fdb985700a4324a6f3e7c0073049a2197c425db811aa60532a309b04ab3559", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\vogia\Documents\GitHub\ShippingMark\ShippingMark\Views\Shared\_PagingNavBar.cshtml"
  
    if (Model.TotalPages == 1)
    {

#line default
#line hidden
#nullable disable

            WriteLiteral(@"        <ul class=""pagination justify-content-center"" style=""margin:20px 0"">
            <li class=""page-item"">
                <button type=""button"" title=""Click to change page size."" data-toggle=""modal"" data-target=""#pageSizeModal"" class=""btn btn-primary"">
                    Page ");
            Write(
#nullable restore
#line 8 "C:\Users\vogia\Documents\GitHub\ShippingMark\ShippingMark\Views\Shared\_PagingNavBar.cshtml"
                          Model.PageIndex

#line default
#line hidden
#nullable disable
            );
            WriteLiteral(" of ");
            Write(
#nullable restore
#line 8 "C:\Users\vogia\Documents\GitHub\ShippingMark\ShippingMark\Views\Shared\_PagingNavBar.cshtml"
                                              Model.TotalPages

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\r\n                </button>\r\n            </li>\r\n        </ul>\r\n");
#nullable restore
#line 12 "C:\Users\vogia\Documents\GitHub\ShippingMark\ShippingMark\Views\Shared\_PagingNavBar.cshtml"
    }
    else
    {
        var jumpAmount = (Model.TotalPages > 25) ? 10 : 5;
        var prevDisabled = !Model.HasPreviousPage ? "disabled='disabled'" : "";
        var nextDisabled = !Model.HasNextPage ? "disabled='disabled'" : "";
        var stepBack = (Model.PageIndex <= jumpAmount) ? 1 : Model.PageIndex - jumpAmount;
        var stepForward = (Model.PageIndex + jumpAmount > Model.TotalPages) ? Model.TotalPages : Model.PageIndex + jumpAmount;

#line default
#line hidden
#nullable disable

            WriteLiteral("        <ul class=\"pagination justify-content-center\" style=\"margin:20px 0\">\r\n            <li class=\"page-item\">\r\n                <button type=\"submit\" name=\"page\" value=\"1\" ");
            Write(
#nullable restore
#line 22 "C:\Users\vogia\Documents\GitHub\ShippingMark\ShippingMark\Views\Shared\_PagingNavBar.cshtml"
                                                             prevDisabled

#line default
#line hidden
#nullable disable
            );
            WriteLiteral(" class=\"btn page-link\">\r\n                    <span aria-hidden=\"true\">&lArr;</span>&nbsp;First\r\n                </button>\r\n            </li>\r\n            <li class=\"page-item d-none d-md-inline\">\r\n                <button type=\"submit\" name=\"page\"");
            BeginWriteAttribute("value", " value=\"", 1360, "\"", 1379, 1);
            WriteAttributeValue("", 1368, 
#nullable restore
#line 27 "C:\Users\vogia\Documents\GitHub\ShippingMark\ShippingMark\Views\Shared\_PagingNavBar.cshtml"
                                                           stepBack

#line default
#line hidden
#nullable disable
            , 1368, 11, false);
            EndWriteAttribute();
            WriteLiteral(" ");
            Write(
#nullable restore
#line 27 "C:\Users\vogia\Documents\GitHub\ShippingMark\ShippingMark\Views\Shared\_PagingNavBar.cshtml"
                                                                       prevDisabled

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\r\n                        data-toggle=\"tooltip\" title=\"Jump Back ");
            Write(
#nullable restore
#line 28 "C:\Users\vogia\Documents\GitHub\ShippingMark\ShippingMark\Views\Shared\_PagingNavBar.cshtml"
                                                                 Model.PageIndex - stepBack

#line default
#line hidden
#nullable disable
            );
            WriteLiteral(" Pages\" class=\"btn page-link\">\r\n                    <span aria-hidden=\"true\">&lArr;</span>\r\n                </button>\r\n            </li>\r\n            <li class=\"page-item\">\r\n                <button type=\"submit\" name=\"page\" ");
            Write(
#nullable restore
#line 33 "C:\Users\vogia\Documents\GitHub\ShippingMark\ShippingMark\Views\Shared\_PagingNavBar.cshtml"
                                                   prevDisabled

#line default
#line hidden
#nullable disable
            );
            WriteLiteral(" value=\"");
            Write(
#nullable restore
#line 33 "C:\Users\vogia\Documents\GitHub\ShippingMark\ShippingMark\Views\Shared\_PagingNavBar.cshtml"
                                                                         Model.PageIndex - 1

#line default
#line hidden
#nullable disable
            );
            WriteLiteral(@""" class=""btn page-link"">
                    &nbsp;<span aria-hidden=""true"">&larr;</span>&nbsp;<span class=""d-none d-md-inline"">Previous</span>
                </button>
            </li>
            <li class=""page-item"">
                <button type=""button"" title=""Click to change page size."" data-toggle=""modal"" data-target=""#pageSizeModal"" class=""btn btn-primary"">
                    <span class=""d-none d-md-inline"">Pg. </span>");
            Write(
#nullable restore
#line 39 "C:\Users\vogia\Documents\GitHub\ShippingMark\ShippingMark\Views\Shared\_PagingNavBar.cshtml"
                                                                 Model.PageIndex

#line default
#line hidden
#nullable disable
            );
            WriteLiteral(" of ");
            Write(
#nullable restore
#line 39 "C:\Users\vogia\Documents\GitHub\ShippingMark\ShippingMark\Views\Shared\_PagingNavBar.cshtml"
                                                                                     Model.TotalPages

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\r\n                </button>\r\n            </li>\r\n            <li class=\"page-item\">\r\n                <button type=\"submit\" name=\"page\" ");
            Write(
#nullable restore
#line 43 "C:\Users\vogia\Documents\GitHub\ShippingMark\ShippingMark\Views\Shared\_PagingNavBar.cshtml"
                                                   nextDisabled

#line default
#line hidden
#nullable disable
            );
            WriteLiteral(" value=\"");
            Write(
#nullable restore
#line 43 "C:\Users\vogia\Documents\GitHub\ShippingMark\ShippingMark\Views\Shared\_PagingNavBar.cshtml"
                                                                         Model.PageIndex + 1

#line default
#line hidden
#nullable disable
            );
            WriteLiteral(@""" class=""btn page-link"">
                    <span class=""d-none d-md-inline"">Next</span>&nbsp;<span aria-hidden=""true"">&rarr;</span>&nbsp;
                </button>
            </li>
            <li class=""page-item d-none d-md-inline"">
                <button type=""submit"" name=""page"" ");
            Write(
#nullable restore
#line 48 "C:\Users\vogia\Documents\GitHub\ShippingMark\ShippingMark\Views\Shared\_PagingNavBar.cshtml"
                                                   nextDisabled

#line default
#line hidden
#nullable disable
            );
            WriteLiteral(" value=\"");
            Write(
#nullable restore
#line 48 "C:\Users\vogia\Documents\GitHub\ShippingMark\ShippingMark\Views\Shared\_PagingNavBar.cshtml"
                                                                         stepForward

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\" title=\"Jump Forward ");
            Write(
#nullable restore
#line 48 "C:\Users\vogia\Documents\GitHub\ShippingMark\ShippingMark\Views\Shared\_PagingNavBar.cshtml"
                                                                                                             stepForward - Model.PageIndex

#line default
#line hidden
#nullable disable
            );
            WriteLiteral(" Pages\" class=\"btn page-link\">\r\n                    <span aria-hidden=\"true\">&rArr;</span>\r\n                </button>\r\n            </li>\r\n            <li class=\"page-item\">\r\n                <button type=\"submit\" name=\"page\" ");
            Write(
#nullable restore
#line 53 "C:\Users\vogia\Documents\GitHub\ShippingMark\ShippingMark\Views\Shared\_PagingNavBar.cshtml"
                                                   nextDisabled

#line default
#line hidden
#nullable disable
            );
            WriteLiteral(" value=\"");
            Write(
#nullable restore
#line 53 "C:\Users\vogia\Documents\GitHub\ShippingMark\ShippingMark\Views\Shared\_PagingNavBar.cshtml"
                                                                         Model.TotalPages

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\" class=\"btn page-link\">\r\n                    Last&nbsp;<span aria-hidden=\"true\">&rArr;</span>\r\n                </button>\r\n            </li>\r\n        </ul>\r\n");
#nullable restore
#line 58 "C:\Users\vogia\Documents\GitHub\ShippingMark\ShippingMark\Views\Shared\_PagingNavBar.cshtml"
    }

#line default
#line hidden
#nullable disable

        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
