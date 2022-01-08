#pragma checksum "C:\Users\Stefan\source\repos\PanSport\PanSport\Views\Cart\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ce0fd94738858f02a508568ba6f7321fa744795e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Cart_Index), @"mvc.1.0.view", @"/Views/Cart/Index.cshtml")]
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
#line 1 "C:\Users\Stefan\source\repos\PanSport\PanSport\Views\_ViewImports.cshtml"
using PanSport;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Stefan\source\repos\PanSport\PanSport\Views\_ViewImports.cshtml"
using PanSport.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ce0fd94738858f02a508568ba6f7321fa744795e", @"/Views/Cart/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1f7f47428d581f0e87b386d0d167146375111cc1", @"/Views/_ViewImports.cshtml")]
    public class Views_Cart_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<CartItem>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Categories", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-light text-lg-center cursot-pointer mb-1 text-dark font-weight-bold my-5"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn-lg btn-success text-decoration-none"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "CheckOut", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "C:\Users\Stefan\source\repos\PanSport\PanSport\Views\Cart\Index.cshtml"
  
    ViewData["Title"] = "Korpa";
    double cartTotal = 0;



#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"bg-dark rounded border border-light\">\r\n\r\n    <div id=\"mainCartItems\" class=\"mt-2\">\r\n\r\n");
#nullable restore
#line 13 "C:\Users\Stefan\source\repos\PanSport\PanSport\Views\Cart\Index.cshtml"
         if (Model.Count() > 0)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"overflow-hidden p-3\">\r\n");
#nullable restore
#line 16 "C:\Users\Stefan\source\repos\PanSport\PanSport\Views\Cart\Index.cshtml"
                 foreach (var cartItem in Model)
                {


#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"row bg-info align-items-center mb-1 rounded text-center text-light\">\r\n                        <div class=\"col-1 p-1\">\r\n                            <a");
            BeginWriteAttribute("href", " href=\"", 545, "\"", 576, 1);
#nullable restore
#line 21 "C:\Users\Stefan\source\repos\PanSport\PanSport\Views\Cart\Index.cshtml"
WriteAttributeValue("", 552, cartItem.SubProductLink, 552, 24, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                <img");
            BeginWriteAttribute("src", " src=\"", 616, "\"", 637, 1);
#nullable restore
#line 22 "C:\Users\Stefan\source\repos\PanSport\PanSport\Views\Cart\Index.cshtml"
WriteAttributeValue("", 622, cartItem.Image, 622, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@"
                                     class=""rounded""
                                     style=""
    width:100%;
    height:100%;
    object-fit: contain;"" />
                            </a>
                        </div>
                        <div class=""col-1"">
                            <span>
                                <a class=""text-light text-decoration-none""");
            BeginWriteAttribute("href", "\r\n                                   href=\"", 1026, "\"", 1093, 1);
#nullable restore
#line 33 "C:\Users\Stefan\source\repos\PanSport\PanSport\Views\Cart\Index.cshtml"
WriteAttributeValue("", 1069, cartItem.SubProductLink, 1069, 24, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 33 "C:\Users\Stefan\source\repos\PanSport\PanSport\Views\Cart\Index.cshtml"
                                                              Write(cartItem.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                            </span>\r\n                        </div>\r\n                        <div class=\"col-1\">\r\n                            <span>\r\n");
#nullable restore
#line 38 "C:\Users\Stefan\source\repos\PanSport\PanSport\Views\Cart\Index.cshtml"
                                  
                                    List<string> parameters = new List<string>();
                                    if (cartItem.SubProduct.Package != null && cartItem.SubProduct.Package != string.Empty)
                                        parameters.Add(cartItem.SubProduct.Package);

                                    if (cartItem.SubProduct.Taste != null && cartItem.SubProduct.Taste != string.Empty)
                                        parameters.Add(cartItem.SubProduct.Taste);

                                    if (cartItem.SubProduct.Size != null && cartItem.SubProduct.Size != string.Empty)
                                        parameters.Add(cartItem.SubProduct.Size);

                                    if (cartItem.SubProduct.Color != null && cartItem.SubProduct.Color != string.Empty)
                                        parameters.Add(cartItem.SubProduct.Color);


                                    string parametersStr = string.Join(", ", parameters);
                                

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral("\r\n                                ");
#nullable restore
#line 58 "C:\Users\Stefan\source\repos\PanSport\PanSport\Views\Cart\Index.cshtml"
                           Write(parametersStr);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </span>\r\n                        </div>\r\n                        <div class=\"col-1\">\r\n                            <span class=\"font-weight-bold\">\r\n                                ");
#nullable restore
#line 63 "C:\Users\Stefan\source\repos\PanSport\PanSport\Views\Cart\Index.cshtml"
                           Write(cartItem.Amount);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                            </span>
                        </div>
                        <div class=""col-1"">
                            <span>
                                <i class=""fas fa-times""></i>
                            </span>
                        </div>
                        <div class=""col-2 p-0"">
                            <span class=""font-weight-bold"">
                                ");
#nullable restore
#line 73 "C:\Users\Stefan\source\repos\PanSport\PanSport\Views\Cart\Index.cshtml"
                           Write(cartItem?.SubProduct?.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" din.
                            </span>
                        </div>
                        <div class=""col-1"">
                            <span>
                                <i class=""fas fa-equals""></i>
                            </span>
                        </div>

                        <div class=""col-2 p-0"">
                            <span class=""font-weight-bold"">
                                ");
#nullable restore
#line 84 "C:\Users\Stefan\source\repos\PanSport\PanSport\Views\Cart\Index.cshtml"
                            Write(cartItem?.SubProduct?.Price * cartItem?.Amount);

#line default
#line hidden
#nullable disable
            WriteLiteral(" din.\r\n");
#nullable restore
#line 85 "C:\Users\Stefan\source\repos\PanSport\PanSport\Views\Cart\Index.cshtml"
                                  
                                    cartTotal += (double)(cartItem?.SubProduct?.Price * cartItem?.Amount);
                                

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </span>\r\n                        </div>\r\n\r\n                        <div class=\"col-2\">\r\n                            <input type=\"hidden\" class=\"subProductIdCart\"");
            BeginWriteAttribute("value", " value=\"", 4058, "\"", 4088, 1);
#nullable restore
#line 92 "C:\Users\Stefan\source\repos\PanSport\PanSport\Views\Cart\Index.cshtml"
WriteAttributeValue("", 4066, cartItem.SubProductId, 4066, 22, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                            <button");
            BeginWriteAttribute("class", " class=\"", 4129, "\"", 4231, 4);
            WriteAttributeValue("", 4137, "btn-sm", 4137, 6, true);
            WriteAttributeValue(" ", 4143, "btn-warning", 4144, 12, true);
            WriteAttributeValue(" ", 4155, "minusCartItemBtn", 4156, 17, true);
#nullable restore
#line 93 "C:\Users\Stefan\source\repos\PanSport\PanSport\Views\Cart\Index.cshtml"
WriteAttributeValue(" ", 4172, @cartItem.Amount == 1 ? "text-secondary" : "text-light", 4173, 58, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("\r\n                                    ");
#nullable restore
#line 94 "C:\Users\Stefan\source\repos\PanSport\PanSport\Views\Cart\Index.cshtml"
                                Write(@cartItem.Amount == 1 ? "disabled" : null);

#line default
#line hidden
#nullable disable
            WriteLiteral(@">
                                <i class=""fas fa-minus-circle""></i>
                            </button>


                            <button class=""btn-sm btn-primary plusCartItemBtn""><i class=""fas fa-plus-circle""></i></button>
                            <button class=""btn-sm btn-danger removeCartItemBtn""><i class=""fas fa-trash-alt""></i></button>
                        </div>
                    </div>
");
#nullable restore
#line 103 "C:\Users\Stefan\source\repos\PanSport\PanSport\Views\Cart\Index.cshtml"

                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n");
#nullable restore
#line 107 "C:\Users\Stefan\source\repos\PanSport\PanSport\Views\Cart\Index.cshtml"
        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <h2 class=\"text-danger ml-2\">Vasa korpa je prazna...</h2>\r\n            <div class=\"d-flex justify-content-center align-content-center\">\r\n\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ce0fd94738858f02a508568ba6f7321fa744795e14194", async() => {
                WriteLiteral("\r\n                    Pogledajte proizvode...\r\n                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </div>\r\n");
#nullable restore
#line 118 "C:\Users\Stefan\source\repos\PanSport\PanSport\Views\Cart\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n\r\n    <div class=\"row cartButtons\">\r\n");
#nullable restore
#line 122 "C:\Users\Stefan\source\repos\PanSport\PanSport\Views\Cart\Index.cshtml"
         if (Model.Count() > 0)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"col-4 d-flex align-items-center justify-content-center\">\r\n\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ce0fd94738858f02a508568ba6f7321fa744795e16308", async() => {
                WriteLiteral("\r\n                    Idi na placanje <i class=\"fas fa-money-bill-wave\"></i>\r\n                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </div>\r\n");
            WriteLiteral(@"            <div class=""col-4 d-flex align-items-center justify-content-center"">

                <button class=""btn-lg btn-danger emptyCartBtn"">
                    Isprazni korpu <i class=""fas fa-trash-alt""></i>
                </button>
            </div>
            <div class=""col-4"">

                <span class=""text-light font-italic"">
                    ");
#nullable restore
#line 141 "C:\Users\Stefan\source\repos\PanSport\PanSport\Views\Cart\Index.cshtml"
               Write(cartTotal);

#line default
#line hidden
#nullable disable
            WriteLiteral(" din.\r\n                </span>\r\n");
#nullable restore
#line 143 "C:\Users\Stefan\source\repos\PanSport\PanSport\Views\Cart\Index.cshtml"
                 if (cartTotal < 5000)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <br />\r\n                    <span class=\"text-light font-italic\">\r\n                        +240 din. (poštarina)\r\n                    </span>\r\n");
#nullable restore
#line 149 "C:\Users\Stefan\source\repos\PanSport\PanSport\Views\Cart\Index.cshtml"
                    cartTotal += 240;
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                <hr class=\"text-light\" />\r\n                <span class=\"text-light font-italic\">\r\n                    <b>\r\n                        ");
#nullable restore
#line 154 "C:\Users\Stefan\source\repos\PanSport\PanSport\Views\Cart\Index.cshtml"
                   Write(cartTotal);

#line default
#line hidden
#nullable disable
            WriteLiteral(" din.\r\n                    </b>\r\n                </span>\r\n            </div>\r\n");
#nullable restore
#line 158 "C:\Users\Stefan\source\repos\PanSport\PanSport\Views\Cart\Index.cshtml"

        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<CartItem>> Html { get; private set; }
    }
}
#pragma warning restore 1591