#pragma checksum "C:\Users\KitingKo\Desktop\DATA BACKUP\WebPDRSystem\WebPDRSystem\Views\PDRUsers\MedHistoryPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bea63e3df4d58173a1c5acaf72fc4f41a3a62f34"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_PDRUsers_MedHistoryPartial), @"mvc.1.0.view", @"/Views/PDRUsers/MedHistoryPartial.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bea63e3df4d58173a1c5acaf72fc4f41a3a62f34", @"/Views/PDRUsers/MedHistoryPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cd5a22c6d35617c1e3ce08ff0048f0e904e4c32a", @"/Views/_ViewImports.cshtml")]
    public class Views_PDRUsers_MedHistoryPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Pdr>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\KitingKo\Desktop\DATA BACKUP\WebPDRSystem\WebPDRSystem\Views\PDRUsers\MedHistoryPartial.cshtml"
 foreach(var patient in Model)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"card\">\r\n        <div class=\"card-header\">\r\n            <h4>");
#nullable restore
#line 7 "C:\Users\KitingKo\Desktop\DATA BACKUP\WebPDRSystem\WebPDRSystem\Views\PDRUsers\MedHistoryPartial.cshtml"
           Write(patient.PatientNavigation.GetFullName());

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n        </div>\r\n        <div class=\"card-body\">\r\n            <div class=\"row\">\r\n                <div class=\"col-md-4\">\r\n                    List of Meds\r\n                    <div class=\"list-group\" style=\"max-height: 200px; overflow: auto;\">\r\n");
#nullable restore
#line 14 "C:\Users\KitingKo\Desktop\DATA BACKUP\WebPDRSystem\WebPDRSystem\Views\PDRUsers\MedHistoryPartial.cshtml"
                         foreach (var item in patient.PatientNavigation.Medications.GroupBy(x => x.MedName))
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <a class=\"list-group-item\"");
            BeginWriteAttribute("id", " id=\"", 618, "\"", 639, 1);
#nullable restore
#line 16 "C:\Users\KitingKo\Desktop\DATA BACKUP\WebPDRSystem\WebPDRSystem\Views\PDRUsers\MedHistoryPartial.cshtml"
WriteAttributeValue("", 623, patient.Patient, 623, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"cursor: pointer;\"");
            BeginWriteAttribute("onclick", " onclick=\"", 665, "\"", 717, 5);
            WriteAttributeValue("", 675, "ChangeName(\'", 675, 12, true);
#nullable restore
#line 16 "C:\Users\KitingKo\Desktop\DATA BACKUP\WebPDRSystem\WebPDRSystem\Views\PDRUsers\MedHistoryPartial.cshtml"
WriteAttributeValue("", 687, patient.Patient, 687, 16, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 703, "\',\'", 703, 3, true);
#nullable restore
#line 16 "C:\Users\KitingKo\Desktop\DATA BACKUP\WebPDRSystem\WebPDRSystem\Views\PDRUsers\MedHistoryPartial.cshtml"
WriteAttributeValue("", 706, item.Key, 706, 9, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 715, "\')", 715, 2, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                ");
#nullable restore
#line 17 "C:\Users\KitingKo\Desktop\DATA BACKUP\WebPDRSystem\WebPDRSystem\Views\PDRUsers\MedHistoryPartial.cshtml"
                           Write(item.Key);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </a>\r\n");
#nullable restore
#line 19 "C:\Users\KitingKo\Desktop\DATA BACKUP\WebPDRSystem\WebPDRSystem\Views\PDRUsers\MedHistoryPartial.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </div>\r\n                </div>\r\n                <div class=\"col-md-8\">\r\n                    Medication History\r\n                    <div class=\"list-group\" style=\"max-height: 200px; overflow: auto;\">\r\n");
#nullable restore
#line 25 "C:\Users\KitingKo\Desktop\DATA BACKUP\WebPDRSystem\WebPDRSystem\Views\PDRUsers\MedHistoryPartial.cshtml"
                         foreach (var history in patient.PatientNavigation.Medications.OrderBy(x => x.CreatedAt))
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <a class=\"list-group-item\" style=\"cursor: pointer;\"");
            BeginWriteAttribute("onclick", " onclick=\"", 1267, "\"", 1307, 3);
            WriteAttributeValue("", 1277, "EditMedHistory(\'", 1277, 16, true);
#nullable restore
#line 27 "C:\Users\KitingKo\Desktop\DATA BACKUP\WebPDRSystem\WebPDRSystem\Views\PDRUsers\MedHistoryPartial.cshtml"
WriteAttributeValue("", 1293, history.Id, 1293, 11, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1304, "\');", 1304, 3, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                <span class=\"title-info\">");
#nullable restore
#line 28 "C:\Users\KitingKo\Desktop\DATA BACKUP\WebPDRSystem\WebPDRSystem\Views\PDRUsers\MedHistoryPartial.cshtml"
                                                    Write(history.Day);

#line default
#line hidden
#nullable disable
            WriteLiteral(" | ");
#nullable restore
#line 28 "C:\Users\KitingKo\Desktop\DATA BACKUP\WebPDRSystem\WebPDRSystem\Views\PDRUsers\MedHistoryPartial.cshtml"
                                                                   Write(history.MedName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span><br />\r\n                                <small>");
#nullable restore
#line 29 "C:\Users\KitingKo\Desktop\DATA BACKUP\WebPDRSystem\WebPDRSystem\Views\PDRUsers\MedHistoryPartial.cshtml"
                                  Write(history.CreatedAt.GetDate("dd/MM/yyyy hh:mm tt"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</small>\r\n                            </a>\r\n");
#nullable restore
#line 31 "C:\Users\KitingKo\Desktop\DATA BACKUP\WebPDRSystem\WebPDRSystem\Views\PDRUsers\MedHistoryPartial.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 37 "C:\Users\KitingKo\Desktop\DATA BACKUP\WebPDRSystem\WebPDRSystem\Views\PDRUsers\MedHistoryPartial.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Pdr>> Html { get; private set; }
    }
}
#pragma warning restore 1591
