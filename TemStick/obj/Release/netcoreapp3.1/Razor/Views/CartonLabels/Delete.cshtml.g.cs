#pragma checksum "C:\Users\vogia\Documents\GitHub\ShippingMark\ShippingMark\Views\CartonLabels\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "71123e2e037cd2bb6a33289f8132d525b6232d89"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_CartonLabels_Delete), @"mvc.1.0.view", @"/Views/CartonLabels/Delete.cshtml")]
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
#line 1 "C:\Users\vogia\Documents\GitHub\ShippingMark\ShippingMark\Views\_ViewImports.cshtml"
using ShippingMark;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\vogia\Documents\GitHub\ShippingMark\ShippingMark\Views\_ViewImports.cshtml"
using ShippingMark.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"71123e2e037cd2bb6a33289f8132d525b6232d89", @"/Views/CartonLabels/Delete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"da9a6fbe37700c0c0938e15edc6861f7fe6bb675", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_CartonLabels_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ShippingMark.Models.CartonLabel>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\vogia\Documents\GitHub\ShippingMark\ShippingMark\Views\CartonLabels\Delete.cshtml"
  
    ViewData["Title"] = "Delete";
    var names = (List<string>)ViewData["Names"];
    var values = (List<int>)ViewData["Values"]; 

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Are you sure you want to delete this?</h1>\r\n\r\n\r\n<div class=\"transition_container\">\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class=\"col-sm-4\">\r\n            ");
#nullable restore
#line 16 "C:\Users\vogia\Documents\GitHub\ShippingMark\ShippingMark\Views\CartonLabels\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.CartonNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-8\">\r\n            ");
#nullable restore
#line 19 "C:\Users\vogia\Documents\GitHub\ShippingMark\ShippingMark\Views\CartonLabels\Delete.cshtml"
       Write(Html.DisplayFor(model => model.CartonNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-4\">\r\n            ");
#nullable restore
#line 22 "C:\Users\vogia\Documents\GitHub\ShippingMark\ShippingMark\Views\CartonLabels\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.BuyerCartonNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-8\">\r\n            ");
#nullable restore
#line 25 "C:\Users\vogia\Documents\GitHub\ShippingMark\ShippingMark\Views\CartonLabels\Delete.cshtml"
       Write(Html.DisplayFor(model => model.BuyerCartonNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-4\">\r\n            ");
#nullable restore
#line 28 "C:\Users\vogia\Documents\GitHub\ShippingMark\ShippingMark\Views\CartonLabels\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.StylePPJ));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-8\">\r\n            ");
#nullable restore
#line 31 "C:\Users\vogia\Documents\GitHub\ShippingMark\ShippingMark\Views\CartonLabels\Delete.cshtml"
       Write(Html.DisplayFor(model => model.StylePPJ));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-4\">\r\n            ");
#nullable restore
#line 34 "C:\Users\vogia\Documents\GitHub\ShippingMark\ShippingMark\Views\CartonLabels\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Brand));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-8\">\r\n            ");
#nullable restore
#line 37 "C:\Users\vogia\Documents\GitHub\ShippingMark\ShippingMark\Views\CartonLabels\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Brand));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-4\">\r\n            ");
#nullable restore
#line 40 "C:\Users\vogia\Documents\GitHub\ShippingMark\ShippingMark\Views\CartonLabels\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-8\">\r\n            ");
#nullable restore
#line 43 "C:\Users\vogia\Documents\GitHub\ShippingMark\ShippingMark\Views\CartonLabels\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-4\">\r\n            ");
#nullable restore
#line 46 "C:\Users\vogia\Documents\GitHub\ShippingMark\ShippingMark\Views\CartonLabels\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Fab));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-8\">\r\n            ");
#nullable restore
#line 49 "C:\Users\vogia\Documents\GitHub\ShippingMark\ShippingMark\Views\CartonLabels\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Fab));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-4\">\r\n            ");
#nullable restore
#line 52 "C:\Users\vogia\Documents\GitHub\ShippingMark\ShippingMark\Views\CartonLabels\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.ColorName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-8\">\r\n            ");
#nullable restore
#line 55 "C:\Users\vogia\Documents\GitHub\ShippingMark\ShippingMark\Views\CartonLabels\Delete.cshtml"
       Write(Html.DisplayFor(model => model.ColorName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-4\">\r\n            Sizes\r\n        </dt>\r\n        <dd class=\"col-sm-8\">\r\n");
            WriteLiteral("            <table class=\"table table-striped table-bordered table-responsive\">\r\n                <tr>\r\n");
#nullable restore
#line 65 "C:\Users\vogia\Documents\GitHub\ShippingMark\ShippingMark\Views\CartonLabels\Delete.cshtml"
                     for (int i = 0; i < values.Count(); i++)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <th>");
#nullable restore
#line 67 "C:\Users\vogia\Documents\GitHub\ShippingMark\ShippingMark\Views\CartonLabels\Delete.cshtml"
                       Write(names.ElementAt(i));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n");
#nullable restore
#line 68 "C:\Users\vogia\Documents\GitHub\ShippingMark\ShippingMark\Views\CartonLabels\Delete.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </tr>\r\n                <tr>\r\n");
#nullable restore
#line 71 "C:\Users\vogia\Documents\GitHub\ShippingMark\ShippingMark\Views\CartonLabels\Delete.cshtml"
                     for (int i = 0; i < values.Count(); i++)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <td>");
#nullable restore
#line 73 "C:\Users\vogia\Documents\GitHub\ShippingMark\ShippingMark\Views\CartonLabels\Delete.cshtml"
                       Write(values.ElementAt(i));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 74 "C:\Users\vogia\Documents\GitHub\ShippingMark\ShippingMark\Views\CartonLabels\Delete.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </tr>\r\n            </table>\r\n        </dd>\r\n        <dt class=\"col-sm-4\">\r\n            ");
#nullable restore
#line 79 "C:\Users\vogia\Documents\GitHub\ShippingMark\ShippingMark\Views\CartonLabels\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.TotalQuantity));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-8\">\r\n            ");
#nullable restore
#line 82 "C:\Users\vogia\Documents\GitHub\ShippingMark\ShippingMark\Views\CartonLabels\Delete.cshtml"
       Write(Html.DisplayFor(model => model.TotalQuantity));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-4\">\r\n            ");
#nullable restore
#line 85 "C:\Users\vogia\Documents\GitHub\ShippingMark\ShippingMark\Views\CartonLabels\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.CartonQuantity));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-8\">\r\n            ");
#nullable restore
#line 88 "C:\Users\vogia\Documents\GitHub\ShippingMark\ShippingMark\Views\CartonLabels\Delete.cshtml"
       Write(Html.DisplayFor(model => model.CartonQuantity));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-4\">\r\n            ");
#nullable restore
#line 91 "C:\Users\vogia\Documents\GitHub\ShippingMark\ShippingMark\Views\CartonLabels\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.TotalPieces));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-8\">\r\n            ");
#nullable restore
#line 94 "C:\Users\vogia\Documents\GitHub\ShippingMark\ShippingMark\Views\CartonLabels\Delete.cshtml"
       Write(Html.DisplayFor(model => model.TotalPieces));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-4\">\r\n            ");
#nullable restore
#line 97 "C:\Users\vogia\Documents\GitHub\ShippingMark\ShippingMark\Views\CartonLabels\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.TotalNetWeight));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-8\">\r\n            ");
#nullable restore
#line 100 "C:\Users\vogia\Documents\GitHub\ShippingMark\ShippingMark\Views\CartonLabels\Delete.cshtml"
       Write(Html.DisplayFor(model => model.TotalNetWeight));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-4\">\r\n            ");
#nullable restore
#line 103 "C:\Users\vogia\Documents\GitHub\ShippingMark\ShippingMark\Views\CartonLabels\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.TotalGrossWeight));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-8\">\r\n            ");
#nullable restore
#line 106 "C:\Users\vogia\Documents\GitHub\ShippingMark\ShippingMark\Views\CartonLabels\Delete.cshtml"
       Write(Html.DisplayFor(model => model.TotalGrossWeight));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-4\">\r\n            ");
#nullable restore
#line 109 "C:\Users\vogia\Documents\GitHub\ShippingMark\ShippingMark\Views\CartonLabels\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Dimension));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-8\">\r\n            ");
#nullable restore
#line 112 "C:\Users\vogia\Documents\GitHub\ShippingMark\ShippingMark\Views\CartonLabels\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Dimension));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n    \r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "71123e2e037cd2bb6a33289f8132d525b6232d8915645", async() => {
                WriteLiteral("\r\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "71123e2e037cd2bb6a33289f8132d525b6232d8915912", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 117 "C:\Users\vogia\Documents\GitHub\ShippingMark\ShippingMark\Views\CartonLabels\Delete.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.ID);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n        <input type=\"submit\" value=\"Delete\" class=\"btn btn-danger\" /> |\r\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "71123e2e037cd2bb6a33289f8132d525b6232d8917711", async() => {
                    WriteLiteral("Back to List");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ShippingMark.Models.CartonLabel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591