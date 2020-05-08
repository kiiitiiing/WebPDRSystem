#pragma checksum "C:\Users\Keith\Desktop\doh\WebPDRSystem\WebPDRSystem\Views\Home\Dashboard.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6c62dc3faef8bdbae6bbd9c2ce0ddff187ce0ca6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Dashboard), @"mvc.1.0.view", @"/Views/Home/Dashboard.cshtml")]
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
#line 1 "C:\Users\Keith\Desktop\doh\WebPDRSystem\WebPDRSystem\Views\_ViewImports.cshtml"
using WebPDRSystem;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Keith\Desktop\doh\WebPDRSystem\WebPDRSystem\Views\_ViewImports.cshtml"
using WebPDRSystem.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Keith\Desktop\doh\WebPDRSystem\WebPDRSystem\Views\_ViewImports.cshtml"
using WebPDRSystem.Models.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Keith\Desktop\doh\WebPDRSystem\WebPDRSystem\Views\_ViewImports.cshtml"
using System.Security.Claims;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Keith\Desktop\doh\WebPDRSystem\WebPDRSystem\Views\_ViewImports.cshtml"
using System.Globalization;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6c62dc3faef8bdbae6bbd9c2ce0ddff187ce0ca6", @"/Views/Home/Dashboard.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cd5a22c6d35617c1e3ce08ff0048f0e904e4c32a", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Dashboard : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\Keith\Desktop\doh\WebPDRSystem\WebPDRSystem\Views\Home\Dashboard.cshtml"
  
    ViewData["Title"] = "Dashboard";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""container"" style=""margin-top: 20px;"">
    <div class=""card"">
        <div class=""card-header"">
            <div class=""fa-pull-right form-inline ml-3"">
                <!-- INPUT -->
                <input class=""form-control form-control-sm""
                        name=""search""
                        id=""searchDetail""
                        placeholder=""Lastname""
                        type=""text""");
            BeginWriteAttribute("value", "\r\n                        value=\"", 475, "\"", 508, 0);
            EndWriteAttribute();
            WriteLiteral(@" />
                <button onclick=""SearchPatient();"" class=""btn btn-sm btn-success"">
                    <i class=""fa fa-search""></i>
                </button>
            </div>
            <h3 class=""card-title"">
                Patient List
            </h3><br />
            <span class=""text-sm text-muted"">TOTAL: <span class=""total_number""></span></span>
        </div>
        <div class=""card-body"">
            <!--Patient LISTS-->
            <div class=""patient-list"">
                <table class=""table table-list table-hover table-responsive table-striped dashboard"" >
                    <thead>
                        <tr>
                            <th class=""text-center"">Bed #</th>
                            <th class=""text-center"">Name </th>
                            <th class=""text-center"">Age </th>
                            <th class=""text-center"">Sex </th>
                            <th class=""text-center"">City/Municipality</th>
                            <th cla");
            WriteLiteral(@"ss=""text-center"">Chief Complaints</th>
                            <th class=""text-center"">Date and Time of Admission</th>
                            <th class=""text-center"">Date VS taken </th>
                            <th class=""text-center"">BP </th>
                            <th class=""text-center"">HR </th>
                            <th class=""text-center"">RR </th>
                            <th class=""text-center"">T</th>
                            <th class=""text-center"">O2Sat </th>
                            <th class=""text-center"">Subjective Complaints</th>
");
            WriteLiteral(@"                            <th class=""text-center"">Medications/ Therapeutics</th>
                            <th class=""text-center"">Consultant Referral </th>
                            <th class=""text-center"">Other remarks </th>
                        </tr>
                    </thead>
                    <tbody id=""dashboard_table"" style=""height: 350px; overflow: auto;"">
                        <tr>
                            <td colspan=""20"">
                                Loading....
                            </td>
                        </tr>
                    </tbody>

                </table>
            </div>
        </div>
    </div>
</div>


<script>
    $(function () {
        LoadDashboard('');
    })

    function SearchPatient() {
        var search = $('#searchDetail').val();
        console.log(search);
        LoadDashboard(search);
    }
</script>");
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
