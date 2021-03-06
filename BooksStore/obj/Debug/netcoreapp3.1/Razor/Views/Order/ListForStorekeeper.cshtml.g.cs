#pragma checksum "C:\Users\Mikita.Fesko\Desktop\testTeamCity\BooksStore\Views\Order\ListForStorekeeper.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5c2b03c1bb2436b8e855154a17cdd8596ac1dd11"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Order_ListForStorekeeper), @"mvc.1.0.view", @"/Views/Order/ListForStorekeeper.cshtml")]
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
#line 1 "C:\Users\Mikita.Fesko\Desktop\testTeamCity\BooksStore\Views\_ViewImports.cshtml"
using BookStore.Models.Classes;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Mikita.Fesko\Desktop\testTeamCity\BooksStore\Views\_ViewImports.cshtml"
using BookStore.Models.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Mikita.Fesko\Desktop\testTeamCity\BooksStore\Views\_ViewImports.cshtml"
using BookStore.Infrastructure;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5c2b03c1bb2436b8e855154a17cdd8596ac1dd11", @"/Views/Order/ListForStorekeeper.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"835dea27a82a9e901441fdaa20e9e615f897b685", @"/Views/_ViewImports.cshtml")]
    public class Views_Order_ListForStorekeeper : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Order>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "MarkAdopted", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "MarkRejected", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Mikita.Fesko\Desktop\testTeamCity\BooksStore\Views\Order\ListForStorekeeper.cshtml"
  
    ViewBag.Title = "Orders";
    Layout = "_AdminLayout";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 8 "C:\Users\Mikita.Fesko\Desktop\testTeamCity\BooksStore\Views\Order\ListForStorekeeper.cshtml"
 if (Model.Any())
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <table class=\"table table-bordered table-striped\">\r\n        <tr><th>Name</th><th colspan=\"3\">Details</th><th>Status</th><th></th><th></th></tr>\r\n");
#nullable restore
#line 12 "C:\Users\Mikita.Fesko\Desktop\testTeamCity\BooksStore\Views\Order\ListForStorekeeper.cshtml"
         foreach (var order in Model)
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Users\Mikita.Fesko\Desktop\testTeamCity\BooksStore\Views\Order\ListForStorekeeper.cshtml"
             if (order.Status == OrderStatus.InProcess || order.Status == OrderStatus.ReturnRequest)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>");
#nullable restore
#line 17 "C:\Users\Mikita.Fesko\Desktop\testTeamCity\BooksStore\Views\Order\ListForStorekeeper.cshtml"
                   Write(order.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>Product</td>\r\n                    <th>Quantity</th>\r\n                    <th>Quantity on Stock</th>\r\n                    <th>");
#nullable restore
#line 21 "C:\Users\Mikita.Fesko\Desktop\testTeamCity\BooksStore\Views\Order\ListForStorekeeper.cshtml"
                   Write(order.Status);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                    <td>\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5c2b03c1bb2436b8e855154a17cdd8596ac1dd116390", async() => {
                WriteLiteral("\r\n                            <input type=\"hidden\" name=\"orderId\"");
                BeginWriteAttribute("value", " value=\"", 830, "\"", 852, 1);
#nullable restore
#line 24 "C:\Users\Mikita.Fesko\Desktop\testTeamCity\BooksStore\Views\Order\ListForStorekeeper.cshtml"
WriteAttributeValue("", 838, order.OrderId, 838, 14, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                            <button type=\"submit\" class=\"btn btn-sm btn-info\">Adopt</button>\r\n                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5c2b03c1bb2436b8e855154a17cdd8596ac1dd118687", async() => {
                WriteLiteral("\r\n                            <input type=\"hidden\" name=\"orderId\"");
                BeginWriteAttribute("value", " value=\"", 1173, "\"", 1195, 1);
#nullable restore
#line 30 "C:\Users\Mikita.Fesko\Desktop\testTeamCity\BooksStore\Views\Order\ListForStorekeeper.cshtml"
WriteAttributeValue("", 1181, order.OrderId, 1181, 14, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                            <button type=\"submit\" class=\"btn btn-sm btn-danger\">Reject</button>\r\n                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 35 "C:\Users\Mikita.Fesko\Desktop\testTeamCity\BooksStore\Views\Order\ListForStorekeeper.cshtml"
                 foreach (var line in order.Lines)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td></td>\r\n                        <td>");
#nullable restore
#line 39 "C:\Users\Mikita.Fesko\Desktop\testTeamCity\BooksStore\Views\Order\ListForStorekeeper.cshtml"
                       Write(line.Book.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 40 "C:\Users\Mikita.Fesko\Desktop\testTeamCity\BooksStore\Views\Order\ListForStorekeeper.cshtml"
                       Write(line.Quantity);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 41 "C:\Users\Mikita.Fesko\Desktop\testTeamCity\BooksStore\Views\Order\ListForStorekeeper.cshtml"
                       Write(line.Book.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    </tr>\r\n");
#nullable restore
#line 43 "C:\Users\Mikita.Fesko\Desktop\testTeamCity\BooksStore\Views\Order\ListForStorekeeper.cshtml"
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 43 "C:\Users\Mikita.Fesko\Desktop\testTeamCity\BooksStore\Views\Order\ListForStorekeeper.cshtml"
                 
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 44 "C:\Users\Mikita.Fesko\Desktop\testTeamCity\BooksStore\Views\Order\ListForStorekeeper.cshtml"
             

        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </table>\r\n");
#nullable restore
#line 48 "C:\Users\Mikita.Fesko\Desktop\testTeamCity\BooksStore\Views\Order\ListForStorekeeper.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"text-center\">No Unshipped Orders</div>\r\n");
#nullable restore
#line 52 "C:\Users\Mikita.Fesko\Desktop\testTeamCity\BooksStore\Views\Order\ListForStorekeeper.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Order>> Html { get; private set; }
    }
}
#pragma warning restore 1591
