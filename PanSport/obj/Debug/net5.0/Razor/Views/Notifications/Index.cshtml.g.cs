#pragma checksum "C:\Users\Stefan\source\repos\PanSport\PanSport\Views\Notifications\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b492b1f08f80c59877373f608d18e5757f8da5ad"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Notifications_Index), @"mvc.1.0.view", @"/Views/Notifications/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b492b1f08f80c59877373f608d18e5757f8da5ad", @"/Views/Notifications/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1f7f47428d581f0e87b386d0d167146375111cc1", @"/Views/_ViewImports.cshtml")]
    public class Views_Notifications_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Notification>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "MarkAllAsReadNot", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("markAllAsReadNotBtn"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-info"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "RemoveAllNot", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("removeAllNotBtn"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n<div class=\"bg-dark p-3 rounded\">\r\n");
#nullable restore
#line 4 "C:\Users\Stefan\source\repos\PanSport\PanSport\Views\Notifications\Index.cshtml"
     if (Model.Count > 0)
    {



#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"text-right\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b492b1f08f80c59877373f608d18e5757f8da5ad5442", async() => {
                WriteLiteral("Mark all as read");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b492b1f08f80c59877373f608d18e5757f8da5ad6785", async() => {
                WriteLiteral("Remove all");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </div>\r\n");
#nullable restore
#line 13 "C:\Users\Stefan\source\repos\PanSport\PanSport\Views\Notifications\Index.cshtml"
         foreach (Notification notification in Model)
        {
            string readClasses = "bg-light text-info border border-info";

            if (!notification.Read)
            {
                readClasses = "bg-info text-light border border-light";
            }


#line default
#line hidden
#nullable disable
            WriteLiteral("            <div");
            BeginWriteAttribute("class", " class=\"", 669, "\"", 765, 7);
            WriteAttributeValue("", 677, "row", 677, 3, true);
            WriteAttributeValue(" ", 680, "mt-2", 681, 5, true);
            WriteAttributeValue(" ", 685, "text-center", 686, 12, true);
            WriteAttributeValue(" ", 697, "align-items-center", 698, 19, true);
            WriteAttributeValue(" ", 716, "cursot-pointer", 717, 15, true);
#nullable restore
#line 22 "C:\Users\Stefan\source\repos\PanSport\PanSport\Views\Notifications\Index.cshtml"
WriteAttributeValue(" ", 731, readClasses, 732, 12, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 744, "notificationRowIndex", 745, 21, true);
            EndWriteAttribute();
            WriteLiteral("\r\n                 data-notificationId=\"");
#nullable restore
#line 23 "C:\Users\Stefan\source\repos\PanSport\PanSport\Views\Notifications\Index.cshtml"
                                 Write(notification.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\r\n\r\n                <div class=\"col-3\">\r\n                    ");
#nullable restore
#line 26 "C:\Users\Stefan\source\repos\PanSport\PanSport\Views\Notifications\Index.cshtml"
               Write(notification.DateTime.Day);

#line default
#line hidden
#nullable disable
            WriteLiteral("/");
#nullable restore
#line 26 "C:\Users\Stefan\source\repos\PanSport\PanSport\Views\Notifications\Index.cshtml"
                                          Write(notification.DateTime.Month);

#line default
#line hidden
#nullable disable
            WriteLiteral("/");
#nullable restore
#line 26 "C:\Users\Stefan\source\repos\PanSport\PanSport\Views\Notifications\Index.cshtml"
                                                                       Write(notification.DateTime.Year);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 26 "C:\Users\Stefan\source\repos\PanSport\PanSport\Views\Notifications\Index.cshtml"
                                                                                                   Write(notification.DateTime.Hour);

#line default
#line hidden
#nullable disable
            WriteLiteral(":");
#nullable restore
#line 26 "C:\Users\Stefan\source\repos\PanSport\PanSport\Views\Notifications\Index.cshtml"
                                                                                                                               Write(notification.DateTime.Minute);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n                <div class=\"col-8\">\r\n                    ");
#nullable restore
#line 29 "C:\Users\Stefan\source\repos\PanSport\PanSport\Views\Notifications\Index.cshtml"
               Write(notification.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n\r\n\r\n\r\n\r\n                <div class=\"col-1 text-right\">\r\n\r\n\r\n                    <button class=\"btn btn-outline-danger removeNotificationBtn badge rounded-circle\" data-notificationId=\"");
#nullable restore
#line 38 "C:\Users\Stefan\source\repos\PanSport\PanSport\Views\Notifications\Index.cshtml"
                                                                                                                      Write(notification.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\r\n                        <i class=\"fas fa-times\"></i>\r\n\r\n                    </button>\r\n\r\n\r\n                </div>\r\n\r\n            </div>\r\n");
#nullable restore
#line 47 "C:\Users\Stefan\source\repos\PanSport\PanSport\Views\Notifications\Index.cshtml"


        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 49 "C:\Users\Stefan\source\repos\PanSport\PanSport\Views\Notifications\Index.cshtml"
         

    }
    else
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("<h1 class=\"text-center text-secondary font-italic\">Nemate notifikacija...</h1>\r\n");
#nullable restore
#line 55 "C:\Users\Stefan\source\repos\PanSport\PanSport\Views\Notifications\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n\r\n\r\n");
            DefineSection("scripts", async() => {
                WriteLiteral(@"
    <script>
        $("".notificationRowIndex"").click(function () {
            
            let row = this;
            let notificationId = $(row).data(""notificationid"");

            $("".notificationRow[data-notificationid='"" + notificationId + ""']"").click();


            $.post(""/notifications/ReadNotification"", { id: notificationId }, function (data) {
                $(row).removeClass(""bg-info text-light border border-light"");
                $(row).addClass(""bg-light text-info border border-info"");
            });
        });

        

        $("".removeNotificationBtn"").click(function () {
            let notificationId = $(this).data(""notificationid"");
            

            let rowIndex = $("".notificationRowIndex[data-notificationid='"" + notificationId + ""']"");
            rowIndex.click();


            $.post(""/notifications/RemoveNotification"", { id: notificationId }, function (data) {

                $(rowIndex).stop(true, false).slideUp(1000,
               ");
                WriteLiteral("     function () {\r\n                        $(rowIndex).remove();\r\n                    });\r\n            });\r\n\r\n            });\r\n    </script>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Notification>> Html { get; private set; }
    }
}
#pragma warning restore 1591
