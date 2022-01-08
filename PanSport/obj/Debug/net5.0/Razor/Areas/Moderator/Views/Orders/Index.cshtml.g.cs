#pragma checksum "C:\Users\Stefan\source\repos\PanSport\PanSport\Areas\Moderator\Views\Orders\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8fc81fcbd21e085cd9f25d57a3998d516ae095dc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Moderator_Views_Orders_Index), @"mvc.1.0.view", @"/Areas/Moderator/Views/Orders/Index.cshtml")]
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
#line 1 "C:\Users\Stefan\source\repos\PanSport\PanSport\Areas\Moderator\Views\_ViewImports.cshtml"
using PanSport;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Stefan\source\repos\PanSport\PanSport\Areas\Moderator\Views\_ViewImports.cshtml"
using PanSport.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8fc81fcbd21e085cd9f25d57a3998d516ae095dc", @"/Areas/Moderator/Views/Orders/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2475e66b9022dd39cb848858d68380a2542127fa", @"/Areas/Moderator/Views/_ViewImports.cshtml")]
    public class Areas_Moderator_Views_Orders_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Order>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "Moderator", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Orders", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ChangeOrder", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-info"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("50"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("height", new global::Microsoft.AspNetCore.Html.HtmlString("50"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<h2>\r\n    Sve narudzbine\r\n</h2>\r\n<div class=\"bg-dark p-3 rounded\">\r\n\r\n");
#nullable restore
#line 7 "C:\Users\Stefan\source\repos\PanSport\PanSport\Areas\Moderator\Views\Orders\Index.cshtml"
     foreach (Order order in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"row mt-2 text-center\">\r\n            <div class=\"col-3 text-light\">\r\n                <p>Order number: #");
#nullable restore
#line 11 "C:\Users\Stefan\source\repos\PanSport\PanSport\Areas\Moderator\Views\Orders\Index.cshtml"
                             Write(order.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            </div>\r\n            <div class=\"col-1 text-light\">\r\n                <p>\r\n");
#nullable restore
#line 15 "C:\Users\Stefan\source\repos\PanSport\PanSport\Areas\Moderator\Views\Orders\Index.cshtml"
                     if (order.Sent)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <span class=\"text-info\">Poslata</span>\r\n");
#nullable restore
#line 18 "C:\Users\Stefan\source\repos\PanSport\PanSport\Areas\Moderator\Views\Orders\Index.cshtml"
                    }
                    else
                    {
                        if (order.Paused)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <span class=\"text-warning\">Pauzirana</span>\r\n");
#nullable restore
#line 24 "C:\Users\Stefan\source\repos\PanSport\PanSport\Areas\Moderator\Views\Orders\Index.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <span class=\"text-success\">Obrada</span>\r\n");
#nullable restore
#line 28 "C:\Users\Stefan\source\repos\PanSport\PanSport\Areas\Moderator\Views\Orders\Index.cshtml"

                        }
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </p>\r\n            </div>\r\n\r\n\r\n            <div class=\"col-3\">\r\n             <button class=\"btn btn-info seeProductsBtn vidi\" data-orderId=\"");
#nullable restore
#line 36 "C:\Users\Stefan\source\repos\PanSport\PanSport\Areas\Moderator\Views\Orders\Index.cshtml"
                                                                       Write(order.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">Vidi proizovde &#9660;</button>\r\n            </div>\r\n            <div class=\"col-2 text-light\">\r\n\r\n                ");
#nullable restore
#line 40 "C:\Users\Stefan\source\repos\PanSport\PanSport\Areas\Moderator\Views\Orders\Index.cshtml"
           Write(order.DateTime.Day);

#line default
#line hidden
#nullable disable
            WriteLiteral("/");
#nullable restore
#line 40 "C:\Users\Stefan\source\repos\PanSport\PanSport\Areas\Moderator\Views\Orders\Index.cshtml"
                               Write(order.DateTime.Month);

#line default
#line hidden
#nullable disable
            WriteLiteral("/");
#nullable restore
#line 40 "C:\Users\Stefan\source\repos\PanSport\PanSport\Areas\Moderator\Views\Orders\Index.cshtml"
                                                     Write(order.DateTime.Year);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 40 "C:\Users\Stefan\source\repos\PanSport\PanSport\Areas\Moderator\Views\Orders\Index.cshtml"
                                                                          Write(order.DateTime.Hour);

#line default
#line hidden
#nullable disable
            WriteLiteral(":");
#nullable restore
#line 40 "C:\Users\Stefan\source\repos\PanSport\PanSport\Areas\Moderator\Views\Orders\Index.cshtml"
                                                                                               Write(order.DateTime.Minute);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n\r\n            <div class=\"col-3\">\r\n\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8fc81fcbd21e085cd9f25d57a3998d516ae095dc9544", async() => {
                WriteLiteral("Detalji");
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
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 49 "C:\Users\Stefan\source\repos\PanSport\PanSport\Areas\Moderator\Views\Orders\Index.cshtml"
                     WriteLiteral(order.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n            </div>\r\n\r\n        </div>\r\n");
            WriteLiteral("        <div class=\"orderInfo overflow-hidden\" data-orderId=\"");
#nullable restore
#line 58 "C:\Users\Stefan\source\repos\PanSport\PanSport\Areas\Moderator\Views\Orders\Index.cshtml"
                                                        Write(order.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral(@""" style=""display: none;"">

            <div class=""row bg-info"">
                <div class=""col-3"">
                    Slika
                </div>
                <div class=""col-3"">
                    Proizvod
                </div>

                <div class=""col-1"">
                    Kolicina
                </div>

                <div class=""col-1"">
                    Cena
                </div>

                <div class=""col-1"">
                    Ukupno
                </div>

                <div class=""col-3 text-right text-light"">
                    <b>
                        ");
#nullable restore
#line 82 "C:\Users\Stefan\source\repos\PanSport\PanSport\Areas\Moderator\Views\Orders\Index.cshtml"
                   Write(order.GrandTotal);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </b>\r\n                </div>\r\n\r\n            </div>\r\n\r\n");
#nullable restore
#line 88 "C:\Users\Stefan\source\repos\PanSport\PanSport\Areas\Moderator\Views\Orders\Index.cshtml"
             foreach (var orderItem in order.OrderItems)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"row bg-info align-items-center\">\r\n                    <div class=\"col-3\">\r\n\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "8fc81fcbd21e085cd9f25d57a3998d516ae095dc13988", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 2647, "~/images/", 2647, 9, true);
#nullable restore
#line 93 "C:\Users\Stefan\source\repos\PanSport\PanSport\Areas\Moderator\Views\Orders\Index.cshtml"
AddHtmlAttributeValue("", 2656, orderItem.SubProduct.Product.ShowImage != null ?
                @orderItem.SubProduct.Product.Category.Slug+"/"+  orderItem.SubProduct.Product.Slug+"/"+ orderItem.SubProduct.Image
                :"noimage.png", 2656, 216, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n                    </div>\r\n                    <div class=\"col-3\">\r\n                        <span>\r\n\r\n\r\n\r\n\r\n                            <a");
            BeginWriteAttribute("href", " href=\"", 3102, "\"", 3251, 1);
#nullable restore
#line 106 "C:\Users\Stefan\source\repos\PanSport\PanSport\Areas\Moderator\Views\Orders\Index.cshtml"
WriteAttributeValue("", 3109, "/proizvodi" + "/" + orderItem.SubProduct?.Product?.Category?.Slug
                            + "/" + orderItem.SubProduct?.Product?.Slug, 3109, 142, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                ");
#nullable restore
#line 108 "C:\Users\Stefan\source\repos\PanSport\PanSport\Areas\Moderator\Views\Orders\Index.cshtml"
                           Write(orderItem.SubProduct.Product.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </a>\r\n                        </span>\r\n                    </div>\r\n                    <div class=\"col-1\">\r\n                        <span>\r\n                            ");
#nullable restore
#line 114 "C:\Users\Stefan\source\repos\PanSport\PanSport\Areas\Moderator\Views\Orders\Index.cshtml"
                       Write(orderItem.Amount);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </span>\r\n                    </div>\r\n                    <div class=\"col-1\">\r\n                        <span>\r\n                            ");
#nullable restore
#line 119 "C:\Users\Stefan\source\repos\PanSport\PanSport\Areas\Moderator\Views\Orders\Index.cshtml"
                       Write(orderItem.SubProduct.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </span>\r\n                    </div>\r\n\r\n                    <div class=\"col-1\">\r\n                        <span>\r\n");
#nullable restore
#line 125 "C:\Users\Stefan\source\repos\PanSport\PanSport\Areas\Moderator\Views\Orders\Index.cshtml"
                              
                                double cartTotal = 0;
                            

#line default
#line hidden
#nullable disable
            WriteLiteral("                            ");
#nullable restore
#line 128 "C:\Users\Stefan\source\repos\PanSport\PanSport\Areas\Moderator\Views\Orders\Index.cshtml"
                        Write(orderItem?.SubProduct?.Price * orderItem?.Amount);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 129 "C:\Users\Stefan\source\repos\PanSport\PanSport\Areas\Moderator\Views\Orders\Index.cshtml"
                              
                                cartTotal += (double)(orderItem?.SubProduct?.Price * orderItem?.Amount);


                            

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </span>\r\n                    </div>\r\n\r\n\r\n\r\n\r\n");
            WriteLiteral("\r\n\r\n                </div>\r\n");
#nullable restore
#line 149 "C:\Users\Stefan\source\repos\PanSport\PanSport\Areas\Moderator\Views\Orders\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n");
#nullable restore
#line 151 "C:\Users\Stefan\source\repos\PanSport\PanSport\Areas\Moderator\Views\Orders\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n</div>\r\n\r\n\r\n");
            DefineSection("scripts", async() => {
                WriteLiteral(@"
    <script>

        $("".seeProductsBtn"").click(function () {


            if ($(this).hasClass(""sakrij"")) {
                $(this).html(""Vidi proizovde &#9660;"").removeClass(""sakrij"").addClass(""vidi"");
            }
            else if ($(this).hasClass(""vidi"")) {

                $(this).html(""Sakrij proizovde &#9650;"").removeClass(""vidi"").addClass(""sakrij"");
            }





            let orderId = $(this).data(""orderid"");

            let info = $("".orderInfo"").filter((i, x) => {
                return $(x).data(""orderid"") == orderId;
            });



            $(info)
                .stop(true, true)
                .animate({
                    height: ""toggle"",
                    opacity: ""toggle""
                }, 1000);

        })


    </script>



    <script>
        //ovo vec postoji u ChangeOrder.cshtml
        $("".copyToCartBtn"").click(function () {
            let orderId = $(this).data(""orderid"");

            $.post(""/cart/copyToC");
                WriteLiteral("art/\" + orderId, {}, function (data) {\r\n                printCartItems(data);\r\n                $(\"#cartHeader\").removeClass(\"d-none\");\r\n            })\r\n        });\r\n    </script>\r\n");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Order>> Html { get; private set; }
    }
}
#pragma warning restore 1591
