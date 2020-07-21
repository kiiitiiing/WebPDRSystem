#pragma checksum "C:\Users\user\Source\Repos\kiiitiiing\WebPDRSystem\WebPDRSystem\Views\Dashboard\CensusPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6b9fdf0377bba3afd8db2eba0ad5db97d55aa34b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Dashboard_CensusPartial), @"mvc.1.0.view", @"/Views/Dashboard/CensusPartial.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6b9fdf0377bba3afd8db2eba0ad5db97d55aa34b", @"/Views/Dashboard/CensusPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cd5a22c6d35617c1e3ce08ff0048f0e904e4c32a", @"/Views/_ViewImports.cshtml")]
    public class Views_Dashboard_CensusPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DashboardModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\user\Source\Repos\kiiitiiing\WebPDRSystem\WebPDRSystem\Views\Dashboard\CensusPartial.cshtml"
  
    var left = Model.TotalBedOccupancy - Model.CurrBedOccupancy;
    var percentage = Math.Floor(((double)Model.CurrBedOccupancy / (double)Model.TotalBedOccupancy) * 100);
    var leftper = 100 - percentage;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<div class=""card-body"">
            <div class=""row"">
                <div class=""col-md-5"">
                    <div class=""col-md-12"">
                        <div class=""row"">
                            <div class=""col-md-6"">
                                <div class=""info-box"">
                                    <div class=""info-box-content"">
                                        <span class=""info-box-text"">TOTAL CENSUS</span>
                                        <span class=""info-box-number"">");
#nullable restore
#line 19 "C:\Users\user\Source\Repos\kiiitiiing\WebPDRSystem\WebPDRSystem\Views\Dashboard\CensusPartial.cshtml"
                                                                 Write(Model.TotalCensus);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                                    </div>
                                    <!-- /.info-box-content -->
                                </div>
                            </div>
                            <div class=""col-md-6"">
                                <div class=""info-box"">
                                    <div class=""info-box-content"">
                                        <span class=""info-box-text"">TOTAL Male Patients</span>
                                        <span class=""info-box-number"">");
#nullable restore
#line 28 "C:\Users\user\Source\Repos\kiiitiiing\WebPDRSystem\WebPDRSystem\Views\Dashboard\CensusPartial.cshtml"
                                                                 Write(Model.MaleCtr);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                                    </div>
                                    <!-- /.info-box-content -->
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class=""col-md-12"">
                        <div class=""row"">
                            <div class=""col-md-6"">
                                <div class=""chartjs-size-monitor""><div class=""chartjs-size-monitor-expand""><div");
            BeginWriteAttribute("class", " class=\"", 1841, "\"", 1849, 0);
            EndWriteAttribute();
            WriteLiteral("></div></div><div class=\"chartjs-size-monitor-shrink\"><div");
            BeginWriteAttribute("class", " class=\"", 1908, "\"", 1916, 0);
            EndWriteAttribute();
            WriteLiteral(@"></div></div></div>
                                <canvas id=""pieChart"" style=""height: 230px; min-height: 230px; display: block; width: 572px;"" width=""715"" height=""287"" class=""chartjs-render-monitor""></canvas>
                            </div>
                            <div class=""col-md-6"">
                                <div class=""info-box"">
                                    <div class=""info-box-content"">
                                        <span class=""info-box-text"">TOTAL Female Patients</span>
                                        <span class=""info-box-number"">");
#nullable restore
#line 46 "C:\Users\user\Source\Repos\kiiitiiing\WebPDRSystem\WebPDRSystem\Views\Dashboard\CensusPartial.cshtml"
                                                                 Write(Model.FemaleCtr);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                                    </div>
                                </div>
                                <div class=""info-box"">
                                    <div class=""info-box-content"">
                                        <span class=""info-box-text"">OCCUPIED</span>
                                        <span class=""info-box-number"">");
#nullable restore
#line 52 "C:\Users\user\Source\Repos\kiiitiiing\WebPDRSystem\WebPDRSystem\Views\Dashboard\CensusPartial.cshtml"
                                                                 Write(percentage);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"%</span>
                                    </div>
                                </div>
                                <div class=""info-box"">
                                    <div class=""info-box-content"">
                                        <span class=""info-box-text"">NOT OCCUPIED</span>
                                        <span class=""info-box-number"">");
#nullable restore
#line 58 "C:\Users\user\Source\Repos\kiiitiiing\WebPDRSystem\WebPDRSystem\Views\Dashboard\CensusPartial.cshtml"
                                                                 Write(leftper);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"%</span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class=""col-md-12"">
                        <div class=""info-box"">
                            <div class=""info-box-content"">
                                <span class=""info-box-text"">Patient with Co Morbidities</span>
                                <span class=""info-box-number"">");
#nullable restore
#line 68 "C:\Users\user\Source\Repos\kiiitiiing\WebPDRSystem\WebPDRSystem\Views\Dashboard\CensusPartial.cshtml"
                                                         Write(Model.CoMorbidities);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                            </div>
                            <!-- /.info-box-content -->
                        </div>
                        <!-- /.info-box -->
                    </div>
                </div>
                <div class=""col-md-7"">
                    <!-- ODR -->
                    <div class=""col-md-12"">
                        <div class=""info-box"">
                            <div class=""info-box-content"">
                                <span class=""info-box-text"">OFFICER OF THE DAY (RED ZONE)</span>
                                <span class=""info-box-number"">");
#nullable restore
#line 81 "C:\Users\user\Source\Repos\kiiitiiing\WebPDRSystem\WebPDRSystem\Views\Dashboard\CensusPartial.cshtml"
                                                         Write(Model.ODR);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                            </div>
                            <!-- /.info-box-content -->
                        </div>
                        <!-- /.info-box -->
                    </div>
                    <!-- ODG -->
                    <div class=""col-md-12"">
                        <div class=""info-box"">
                            <div class=""info-box-content"">
                                <span class=""info-box-text"">OFFICER OF THE DAY (GREEN ZONE)</span>
                                <span class=""info-box-number"">");
#nullable restore
#line 92 "C:\Users\user\Source\Repos\kiiitiiing\WebPDRSystem\WebPDRSystem\Views\Dashboard\CensusPartial.cshtml"
                                                         Write(Model.ODG);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                            </div>
                            <!-- /.info-box-content -->
                        </div>
                        <!-- /.info-box -->
                    </div>
                    <!-- QOD -->
                    <div class=""col-md-12"">
                        <div class=""info-box"">
                            <div class=""info-box-content"">
                                <span class=""info-box-text"">QUARANTINE DOCTOR</span>
                                <span class=""info-box-number"">");
#nullable restore
#line 103 "C:\Users\user\Source\Repos\kiiitiiing\WebPDRSystem\WebPDRSystem\Views\Dashboard\CensusPartial.cshtml"
                                                         Write(Model.QD);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                            </div>
                            <!-- /.info-box-content -->
                        </div>
                        <!-- /.info-box -->
                    </div>
                    <!-- NOD A -->
                    <div class=""col-md-12"">
                        <div class=""info-box"">
                            <div class=""info-box-content"">
                                <span class=""info-box-text"">NURSE OF THE DAY (CHAMBER A)</span>
                                <span class=""info-box-number"">");
#nullable restore
#line 114 "C:\Users\user\Source\Repos\kiiitiiing\WebPDRSystem\WebPDRSystem\Views\Dashboard\CensusPartial.cshtml"
                                                         Write(Model.NODA);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                            </div>
                            <!-- /.info-box-content -->
                        </div>
                        <!-- /.info-box -->
                    </div>
                    <!-- NOT B -->
                    <div class=""col-md-12"">
                        <div class=""info-box"">
                            <div class=""info-box-content"">
                                <span class=""info-box-text"">NURSE OF THE DAY (CHAMBER B)</span>
                                <span class=""info-box-number"">");
#nullable restore
#line 125 "C:\Users\user\Source\Repos\kiiitiiing\WebPDRSystem\WebPDRSystem\Views\Dashboard\CensusPartial.cshtml"
                                                         Write(Model.NODB);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                            </div>
                            <!-- /.info-box-content -->
                        </div>
                        <!-- /.info-box -->
                    </div>
                </div>
            </div>
        </div>

<script>
    var donutData = {
        labels: [
            'Occupied',
            'Not occupied'
        ],
        datasets: [
            {
                data: [");
#nullable restore
#line 143 "C:\Users\user\Source\Repos\kiiitiiing\WebPDRSystem\WebPDRSystem\Views\Dashboard\CensusPartial.cshtml"
                  Write(Model.CurrBedOccupancy);

#line default
#line hidden
#nullable disable
            WriteLiteral(",");
#nullable restore
#line 143 "C:\Users\user\Source\Repos\kiiitiiing\WebPDRSystem\WebPDRSystem\Views\Dashboard\CensusPartial.cshtml"
                                          Write(left);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"],
                backgroundColor: ['#f56954', '#00a65a'],
            }
        ]
    };
    var pieChartCanvas = $('#pieChart').get(0).getContext('2d')
    var pieData = donutData;
    var pieOptions = {
        maintainAspectRatio: false,
        responsive: true
    }
    //Create pie or douhnut chart
    // You can switch between pie and douhnut using the method below.
    var pieChart = new Chart(pieChartCanvas, {
        type: 'pie',
        data: pieData,
        options: pieOptions
    });



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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DashboardModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
