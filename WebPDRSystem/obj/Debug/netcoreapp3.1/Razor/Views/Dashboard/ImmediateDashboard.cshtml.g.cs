#pragma checksum "C:\Users\user\Source\Repos\kiiitiiing\WebPDRSystem\WebPDRSystem\Views\Dashboard\ImmediateDashboard.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "902c56956ee81446fdf5a9a4571b81850d192e70"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Dashboard_ImmediateDashboard), @"mvc.1.0.view", @"/Views/Dashboard/ImmediateDashboard.cshtml")]
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
#line 1 "C:\Users\user\Source\Repos\kiiitiiing\WebPDRSystem\WebPDRSystem\Views\_ViewImports.cshtml"
using WebPDRSystem;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\user\Source\Repos\kiiitiiing\WebPDRSystem\WebPDRSystem\Views\_ViewImports.cshtml"
using WebPDRSystem.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\user\Source\Repos\kiiitiiing\WebPDRSystem\WebPDRSystem\Views\_ViewImports.cshtml"
using WebPDRSystem.Models.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\user\Source\Repos\kiiitiiing\WebPDRSystem\WebPDRSystem\Views\_ViewImports.cshtml"
using System.Security.Claims;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\user\Source\Repos\kiiitiiing\WebPDRSystem\WebPDRSystem\Views\_ViewImports.cshtml"
using System.Globalization;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"902c56956ee81446fdf5a9a4571b81850d192e70", @"/Views/Dashboard/ImmediateDashboard.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cd5a22c6d35617c1e3ce08ff0048f0e904e4c32a", @"/Views/_ViewImports.cshtml")]
    public class Views_Dashboard_ImmediateDashboard : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\user\Source\Repos\kiiitiiing\WebPDRSystem\WebPDRSystem\Views\Dashboard\ImmediateDashboard.cshtml"
  
    ViewData["Title"] = "ImmediateDashboard";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""card"">
    <div class=""card-header"">
        <h3>UNUSUALITIES</h3>
    </div>
    <div class=""card-body"">
        <div class=""patient-list"">
            <table class=""table table-striped table-hover"">
                <thead>
                    <tr>
                        <th>
                            BED #
                        </th>
                        <th>
                            P.I.N.
                        </th>
                        <th>
                            ISSUE/DETAILS
                        </th>
                        <th>
                            STATUS
                        </th>
                        <th>
                            REMARKS
                        </th>
                    </tr>
                </thead>
                <tbody id=""idashboard_table"" style=""height: 350px; overflow: auto;"">
                    <tr>
                        <td colspan=""20"">
                            Loading....
          ");
            WriteLiteral("              </td>\r\n                    </tr>\r\n                </tbody>\r\n            </table>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n<script>\r\n    LoadIDP();\r\n</script>");
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
