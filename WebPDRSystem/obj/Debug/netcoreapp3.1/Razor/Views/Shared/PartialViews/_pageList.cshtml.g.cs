#pragma checksum "C:\Users\KitingKo\Desktop\DATA BACKUP\WebPDRSystem\WebPDRSystem\Views\Shared\PartialViews\_pageList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a0a778d7774a6ef86ef4aa60d2fff3f00e8b9742"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_PartialViews__pageList), @"mvc.1.0.view", @"/Views/Shared/PartialViews/_pageList.cshtml")]
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
#line 1 "C:\Users\KitingKo\Desktop\DATA BACKUP\WebPDRSystem\WebPDRSystem\Views\_ViewImports.cshtml"
using WebPDRSystem;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\KitingKo\Desktop\DATA BACKUP\WebPDRSystem\WebPDRSystem\Views\_ViewImports.cshtml"
using WebPDRSystem.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\KitingKo\Desktop\DATA BACKUP\WebPDRSystem\WebPDRSystem\Views\_ViewImports.cshtml"
using WebPDRSystem.Models.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\KitingKo\Desktop\DATA BACKUP\WebPDRSystem\WebPDRSystem\Views\_ViewImports.cshtml"
using System.Security.Claims;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\KitingKo\Desktop\DATA BACKUP\WebPDRSystem\WebPDRSystem\Views\_ViewImports.cshtml"
using System.Globalization;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a0a778d7774a6ef86ef4aa60d2fff3f00e8b9742", @"/Views/Shared/PartialViews/_pageList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cd5a22c6d35617c1e3ce08ff0048f0e904e4c32a", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_PartialViews__pageList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PageListModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\KitingKo\Desktop\DATA BACKUP\WebPDRSystem\WebPDRSystem\Views\Shared\PartialViews\_pageList.cshtml"
 if (Model.TotalPages > 1)
{
    var prevDisabled = !Model.HasPreviousPage ? "disabled" : "";
    var nextDisabled = !Model.HasNextPage ? "disabled" : "";
    var between = false;
    var stringQuery = Model.Parameters;
    var index = Model.Parameters;

#line default
#line hidden
#nullable disable
            WriteLiteral("    <ul class=\"pagination\" style=\"margin-left:auto; margin-right:auto; white-space:normal !important\">\r\n        <li>\r\n");
#nullable restore
#line 12 "C:\Users\KitingKo\Desktop\DATA BACKUP\WebPDRSystem\WebPDRSystem\Views\Shared\PartialViews\_pageList.cshtml"
              
                Model.Parameters["page"] = (Model.PageIndex - 1).ToString();
                var url = "search=" + Model.Parameters["search"] + "&page=" + Model.Parameters["page"];
            

#line default
#line hidden
#nullable disable
            WriteLiteral("            <a");
            BeginWriteAttribute("class", " class=\"", 631, "\"", 668, 3);
            WriteAttributeValue("", 639, "btn", 639, 3, true);
            WriteAttributeValue(" ", 642, "btn-default", 643, 12, true);
#nullable restore
#line 16 "C:\Users\KitingKo\Desktop\DATA BACKUP\WebPDRSystem\WebPDRSystem\Views\Shared\PartialViews\_pageList.cshtml"
WriteAttributeValue(" ", 654, prevDisabled, 655, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("onclick", " onclick=\"", 669, "\"", 700, 3);
            WriteAttributeValue("", 679, "LoadDashboard(\'", 679, 15, true);
#nullable restore
#line 16 "C:\Users\KitingKo\Desktop\DATA BACKUP\WebPDRSystem\WebPDRSystem\Views\Shared\PartialViews\_pageList.cshtml"
WriteAttributeValue("", 694, url, 694, 4, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 698, "\')", 698, 2, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                «\r\n            </a>\r\n        </li>\r\n");
#nullable restore
#line 20 "C:\Users\KitingKo\Desktop\DATA BACKUP\WebPDRSystem\WebPDRSystem\Views\Shared\PartialViews\_pageList.cshtml"
         for (int x = 1; x <= Model.TotalPages; x++)
        {
            index["page"] = x.ToString();
            url = "search=" + Model.Parameters["search"] + "&page=" + index["page"];
            var activeClass = x == Model.PageIndex ? "btn-primary" : "btn-default";
            if (Model.TotalPages > 10)
            {
                if (Model.PageIndex < 8)
                {
                    if (x < 9)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <li>\r\n                            <a");
            BeginWriteAttribute("class", " class=\"", 1266, "\"", 1290, 2);
            WriteAttributeValue("", 1274, "btn", 1274, 3, true);
#nullable restore
#line 32 "C:\Users\KitingKo\Desktop\DATA BACKUP\WebPDRSystem\WebPDRSystem\Views\Shared\PartialViews\_pageList.cshtml"
WriteAttributeValue(" ", 1277, activeClass, 1278, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("onclick", " onclick=\"", 1291, "\"", 1322, 3);
            WriteAttributeValue("", 1301, "LoadDashboard(\'", 1301, 15, true);
#nullable restore
#line 32 "C:\Users\KitingKo\Desktop\DATA BACKUP\WebPDRSystem\WebPDRSystem\Views\Shared\PartialViews\_pageList.cshtml"
WriteAttributeValue("", 1316, url, 1316, 4, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1320, "\')", 1320, 2, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                ");
#nullable restore
#line 33 "C:\Users\KitingKo\Desktop\DATA BACKUP\WebPDRSystem\WebPDRSystem\Views\Shared\PartialViews\_pageList.cshtml"
                           Write(x);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </a>\r\n                        </li>\r\n");
#nullable restore
#line 36 "C:\Users\KitingKo\Desktop\DATA BACKUP\WebPDRSystem\WebPDRSystem\Views\Shared\PartialViews\_pageList.cshtml"
                    }
                    else if (x == 9 && !between)
                    {
                        between = !between;

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <li>\r\n                            <a class=\"btn btn-default link-muted\" style=\"cursor:not-allowed;\">\r\n                                ...\r\n                            </a>\r\n                        </li>\r\n");
#nullable restore
#line 45 "C:\Users\KitingKo\Desktop\DATA BACKUP\WebPDRSystem\WebPDRSystem\Views\Shared\PartialViews\_pageList.cshtml"
                    }
                    else if (x > (Model.TotalPages - 2))
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <li>\r\n                            <a");
            BeginWriteAttribute("class", " class=\"", 1960, "\"", 1984, 2);
            WriteAttributeValue("", 1968, "btn", 1968, 3, true);
#nullable restore
#line 49 "C:\Users\KitingKo\Desktop\DATA BACKUP\WebPDRSystem\WebPDRSystem\Views\Shared\PartialViews\_pageList.cshtml"
WriteAttributeValue(" ", 1971, activeClass, 1972, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("onclick", " onclick=\"", 1985, "\"", 2016, 3);
            WriteAttributeValue("", 1995, "LoadDashboard(\'", 1995, 15, true);
#nullable restore
#line 49 "C:\Users\KitingKo\Desktop\DATA BACKUP\WebPDRSystem\WebPDRSystem\Views\Shared\PartialViews\_pageList.cshtml"
WriteAttributeValue("", 2010, url, 2010, 4, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2014, "\')", 2014, 2, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                ");
#nullable restore
#line 50 "C:\Users\KitingKo\Desktop\DATA BACKUP\WebPDRSystem\WebPDRSystem\Views\Shared\PartialViews\_pageList.cshtml"
                           Write(x);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </a>\r\n                        </li>\r\n");
#nullable restore
#line 53 "C:\Users\KitingKo\Desktop\DATA BACKUP\WebPDRSystem\WebPDRSystem\Views\Shared\PartialViews\_pageList.cshtml"
                    }
                }
                else if (Model.PageIndex >= (Model.TotalPages - 6))
                {
                    if (x < 3)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <li>\r\n                            <a");
            BeginWriteAttribute("class", " class=\"", 2366, "\"", 2390, 2);
            WriteAttributeValue("", 2374, "btn", 2374, 3, true);
#nullable restore
#line 60 "C:\Users\KitingKo\Desktop\DATA BACKUP\WebPDRSystem\WebPDRSystem\Views\Shared\PartialViews\_pageList.cshtml"
WriteAttributeValue(" ", 2377, activeClass, 2378, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("onclick", " onclick=\"", 2391, "\"", 2422, 3);
            WriteAttributeValue("", 2401, "LoadDashboard(\'", 2401, 15, true);
#nullable restore
#line 60 "C:\Users\KitingKo\Desktop\DATA BACKUP\WebPDRSystem\WebPDRSystem\Views\Shared\PartialViews\_pageList.cshtml"
WriteAttributeValue("", 2416, url, 2416, 4, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2420, "\')", 2420, 2, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                ");
#nullable restore
#line 61 "C:\Users\KitingKo\Desktop\DATA BACKUP\WebPDRSystem\WebPDRSystem\Views\Shared\PartialViews\_pageList.cshtml"
                           Write(x);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </a>\r\n                        </li>\r\n");
#nullable restore
#line 64 "C:\Users\KitingKo\Desktop\DATA BACKUP\WebPDRSystem\WebPDRSystem\Views\Shared\PartialViews\_pageList.cshtml"
                    }
                    else if (x == 3 && !between)
                    {
                        between = !between;

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <li>\r\n                            <a class=\"btn btn-default link-muted\" style=\"cursor:not-allowed;\">\r\n                                ...\r\n                            </a>\r\n                        </li>\r\n");
#nullable restore
#line 73 "C:\Users\KitingKo\Desktop\DATA BACKUP\WebPDRSystem\WebPDRSystem\Views\Shared\PartialViews\_pageList.cshtml"
                    }
                    else if (x > (Model.TotalPages - 9))
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <li>\r\n                            <a");
            BeginWriteAttribute("class", " class=\"", 3060, "\"", 3084, 2);
            WriteAttributeValue("", 3068, "btn", 3068, 3, true);
#nullable restore
#line 77 "C:\Users\KitingKo\Desktop\DATA BACKUP\WebPDRSystem\WebPDRSystem\Views\Shared\PartialViews\_pageList.cshtml"
WriteAttributeValue(" ", 3071, activeClass, 3072, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("onclick", " onclick=\"", 3085, "\"", 3116, 3);
            WriteAttributeValue("", 3095, "LoadDashboard(\'", 3095, 15, true);
#nullable restore
#line 77 "C:\Users\KitingKo\Desktop\DATA BACKUP\WebPDRSystem\WebPDRSystem\Views\Shared\PartialViews\_pageList.cshtml"
WriteAttributeValue("", 3110, url, 3110, 4, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3114, "\')", 3114, 2, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                ");
#nullable restore
#line 78 "C:\Users\KitingKo\Desktop\DATA BACKUP\WebPDRSystem\WebPDRSystem\Views\Shared\PartialViews\_pageList.cshtml"
                           Write(x);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </a>\r\n                        </li>\r\n");
#nullable restore
#line 81 "C:\Users\KitingKo\Desktop\DATA BACKUP\WebPDRSystem\WebPDRSystem\Views\Shared\PartialViews\_pageList.cshtml"
                    }
                }
                else if (Model.PageIndex >= 8 && (Model.TotalPages - 4) >= Model.PageIndex)
                {
                    if (x < 3)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <li>\r\n                            <a");
            BeginWriteAttribute("class", " class=\"", 3490, "\"", 3514, 2);
            WriteAttributeValue("", 3498, "btn", 3498, 3, true);
#nullable restore
#line 88 "C:\Users\KitingKo\Desktop\DATA BACKUP\WebPDRSystem\WebPDRSystem\Views\Shared\PartialViews\_pageList.cshtml"
WriteAttributeValue(" ", 3501, activeClass, 3502, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("onclick", " onclick=\"", 3515, "\"", 3546, 3);
            WriteAttributeValue("", 3525, "LoadDashboard(\'", 3525, 15, true);
#nullable restore
#line 88 "C:\Users\KitingKo\Desktop\DATA BACKUP\WebPDRSystem\WebPDRSystem\Views\Shared\PartialViews\_pageList.cshtml"
WriteAttributeValue("", 3540, url, 3540, 4, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3544, "\')", 3544, 2, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                ");
#nullable restore
#line 89 "C:\Users\KitingKo\Desktop\DATA BACKUP\WebPDRSystem\WebPDRSystem\Views\Shared\PartialViews\_pageList.cshtml"
                           Write(x);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </a>\r\n                        </li>\r\n");
#nullable restore
#line 92 "C:\Users\KitingKo\Desktop\DATA BACKUP\WebPDRSystem\WebPDRSystem\Views\Shared\PartialViews\_pageList.cshtml"
                    }
                    else if (x == 3 || x == (Model.TotalPages - 3))
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <li>\r\n                            <a class=\"btn btn-default link-muted\" style=\"cursor:not-allowed;\">\r\n                                ...\r\n                            </a>\r\n                        </li>\r\n");
#nullable restore
#line 100 "C:\Users\KitingKo\Desktop\DATA BACKUP\WebPDRSystem\WebPDRSystem\Views\Shared\PartialViews\_pageList.cshtml"
                    }
                    else if (x >= (Model.PageIndex - 3) && x <= (Model.PageIndex + 3))
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <li>\r\n                            <a");
            BeginWriteAttribute("class", " class=\"", 4188, "\"", 4212, 2);
            WriteAttributeValue("", 4196, "btn", 4196, 3, true);
#nullable restore
#line 104 "C:\Users\KitingKo\Desktop\DATA BACKUP\WebPDRSystem\WebPDRSystem\Views\Shared\PartialViews\_pageList.cshtml"
WriteAttributeValue(" ", 4199, activeClass, 4200, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("onclick", " onclick=\"", 4213, "\"", 4244, 3);
            WriteAttributeValue("", 4223, "LoadDashboard(\'", 4223, 15, true);
#nullable restore
#line 104 "C:\Users\KitingKo\Desktop\DATA BACKUP\WebPDRSystem\WebPDRSystem\Views\Shared\PartialViews\_pageList.cshtml"
WriteAttributeValue("", 4238, url, 4238, 4, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 4242, "\')", 4242, 2, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                ");
#nullable restore
#line 105 "C:\Users\KitingKo\Desktop\DATA BACKUP\WebPDRSystem\WebPDRSystem\Views\Shared\PartialViews\_pageList.cshtml"
                           Write(x);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </a>\r\n                        </li>\r\n");
#nullable restore
#line 108 "C:\Users\KitingKo\Desktop\DATA BACKUP\WebPDRSystem\WebPDRSystem\Views\Shared\PartialViews\_pageList.cshtml"
                    }
                    else if (x >= (Model.TotalPages - 1))
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <li>\r\n                            <a");
            BeginWriteAttribute("class", " class=\"", 4514, "\"", 4538, 2);
            WriteAttributeValue("", 4522, "btn", 4522, 3, true);
#nullable restore
#line 112 "C:\Users\KitingKo\Desktop\DATA BACKUP\WebPDRSystem\WebPDRSystem\Views\Shared\PartialViews\_pageList.cshtml"
WriteAttributeValue(" ", 4525, activeClass, 4526, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("onclick", " onclick=\"", 4539, "\"", 4570, 3);
            WriteAttributeValue("", 4549, "LoadDashboard(\'", 4549, 15, true);
#nullable restore
#line 112 "C:\Users\KitingKo\Desktop\DATA BACKUP\WebPDRSystem\WebPDRSystem\Views\Shared\PartialViews\_pageList.cshtml"
WriteAttributeValue("", 4564, url, 4564, 4, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 4568, "\')", 4568, 2, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                ");
#nullable restore
#line 113 "C:\Users\KitingKo\Desktop\DATA BACKUP\WebPDRSystem\WebPDRSystem\Views\Shared\PartialViews\_pageList.cshtml"
                           Write(x);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </a>\r\n                        </li>\r\n");
#nullable restore
#line 116 "C:\Users\KitingKo\Desktop\DATA BACKUP\WebPDRSystem\WebPDRSystem\Views\Shared\PartialViews\_pageList.cshtml"
                    }
                }
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <li>\r\n                    <a");
            BeginWriteAttribute("class", " class=\"", 4809, "\"", 4833, 2);
            WriteAttributeValue("", 4817, "btn", 4817, 3, true);
#nullable restore
#line 122 "C:\Users\KitingKo\Desktop\DATA BACKUP\WebPDRSystem\WebPDRSystem\Views\Shared\PartialViews\_pageList.cshtml"
WriteAttributeValue(" ", 4820, activeClass, 4821, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("onclick", " onclick=\"", 4834, "\"", 4865, 3);
            WriteAttributeValue("", 4844, "LoadDashboard(\'", 4844, 15, true);
#nullable restore
#line 122 "C:\Users\KitingKo\Desktop\DATA BACKUP\WebPDRSystem\WebPDRSystem\Views\Shared\PartialViews\_pageList.cshtml"
WriteAttributeValue("", 4859, url, 4859, 4, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 4863, "\')", 4863, 2, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                        ");
#nullable restore
#line 123 "C:\Users\KitingKo\Desktop\DATA BACKUP\WebPDRSystem\WebPDRSystem\Views\Shared\PartialViews\_pageList.cshtml"
                   Write(x);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </a>\r\n                </li>\r\n");
#nullable restore
#line 126 "C:\Users\KitingKo\Desktop\DATA BACKUP\WebPDRSystem\WebPDRSystem\Views\Shared\PartialViews\_pageList.cshtml"
            }
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        <li>\r\n");
#nullable restore
#line 129 "C:\Users\KitingKo\Desktop\DATA BACKUP\WebPDRSystem\WebPDRSystem\Views\Shared\PartialViews\_pageList.cshtml"
              
                Model.Parameters["page"] = (Model.PageIndex + 1).ToString();
                url = "search=" + Model.Parameters["search"] + "&page=" + Model.Parameters["page"];
            

#line default
#line hidden
#nullable disable
            WriteLiteral("            <a");
            BeginWriteAttribute("class", " class=\"", 5210, "\"", 5247, 3);
            WriteAttributeValue("", 5218, "btn", 5218, 3, true);
            WriteAttributeValue(" ", 5221, "btn-default", 5222, 12, true);
#nullable restore
#line 133 "C:\Users\KitingKo\Desktop\DATA BACKUP\WebPDRSystem\WebPDRSystem\Views\Shared\PartialViews\_pageList.cshtml"
WriteAttributeValue(" ", 5233, nextDisabled, 5234, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("onclick", " onclick=\"", 5248, "\"", 5279, 3);
            WriteAttributeValue("", 5258, "LoadDashboard(\'", 5258, 15, true);
#nullable restore
#line 133 "C:\Users\KitingKo\Desktop\DATA BACKUP\WebPDRSystem\WebPDRSystem\Views\Shared\PartialViews\_pageList.cshtml"
WriteAttributeValue("", 5273, url, 5273, 4, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 5277, "\')", 5277, 2, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                »\r\n            </a>\r\n        </li>\r\n    </ul>\r\n");
#nullable restore
#line 138 "C:\Users\KitingKo\Desktop\DATA BACKUP\WebPDRSystem\WebPDRSystem\Views\Shared\PartialViews\_pageList.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<script>\r\n\r\n</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PageListModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
