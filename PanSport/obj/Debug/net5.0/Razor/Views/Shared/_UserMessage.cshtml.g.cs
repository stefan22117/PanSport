#pragma checksum "C:\Users\Stefan\source\repos\PanSport\PanSport\Views\Shared\_UserMessage.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e7aea2b427033839fec6311e5e7faa63e59ea56b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__UserMessage), @"mvc.1.0.view", @"/Views/Shared/_UserMessage.cshtml")]
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
#nullable restore
#line 1 "C:\Users\Stefan\source\repos\PanSport\PanSport\Views\Shared\_UserMessage.cshtml"
using PanSport.Infrastructure;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e7aea2b427033839fec6311e5e7faa63e59ea56b", @"/Views/Shared/_UserMessage.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1f7f47428d581f0e87b386d0d167146375111cc1", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__UserMessage : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Stefan\source\repos\PanSport\PanSport\Views\Shared\_UserMessage.cshtml"
 if (TempData.ContainsKey("UserMessage"))
{
    UserMessage data = TempData.Get<UserMessage>("UserMessage");


#line default
#line hidden
#nullable disable
            WriteLiteral("    <div id=\"UserMessage\"");
            BeginWriteAttribute("class", " class=\"", 173, "\"", 224, 4);
            WriteAttributeValue("", 181, "alert-dismissible", 181, 17, true);
            WriteAttributeValue(" ", 198, "alert", 199, 6, true);
            WriteAttributeValue(" ", 204, "alert-", 205, 7, true);
#nullable restore
#line 7 "C:\Users\Stefan\source\repos\PanSport\PanSport\Views\Shared\_UserMessage.cshtml"
WriteAttributeValue("", 211, data.Classes, 211, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" data-seconds=\"");
#nullable restore
#line 7 "C:\Users\Stefan\source\repos\PanSport\PanSport\Views\Shared\_UserMessage.cshtml"
                                                                                       Write(data.Seconds);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\r\n\r\n        <span>\r\n            ");
#nullable restore
#line 10 "C:\Users\Stefan\source\repos\PanSport\PanSport\Views\Shared\_UserMessage.cshtml"
       Write(data.Message);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </span>\r\n\r\n        <span class=\"close-button bg-transparent border-0 p-0 mr-1 position-absolute\">\r\n            <i class=\"far fa-times-circle\"></i>\r\n        </span>\r\n    </div>\r\n");
#nullable restore
#line 17 "C:\Users\Stefan\source\repos\PanSport\PanSport\Views\Shared\_UserMessage.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
