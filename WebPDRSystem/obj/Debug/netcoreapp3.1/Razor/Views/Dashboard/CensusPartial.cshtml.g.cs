#pragma checksum "C:\Users\Keith\Desktop\doh\WebPDRSystem\WebPDRSystem\Views\Dashboard\CensusPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "36b347042ba3f5cddd034dab51e118abec5155d4"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"36b347042ba3f5cddd034dab51e118abec5155d4", @"/Views/Dashboard/CensusPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dd0de6f509fd11d1eacc1af603f29baa90bb40be", @"/Views/_ViewImports.cshtml")]
    public class Views_Dashboard_CensusPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DashboardModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Keith\Desktop\doh\WebPDRSystem\WebPDRSystem\Views\Dashboard\CensusPartial.cshtml"
  
    var left = Model.TotalBedOccupancy - Model.CurrBedOccupancy;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div row>
    <div class=""card"">
        <div class=""card-body"">
            <div class=""row"">
                <div class=""col-md-5"">
                    <div class=""col-md-12"">
                        <div class=""info-box"">
                            <div class=""info-box-content"">
                                <span class=""info-box-text"">TOTAL CENSUS</span>
                                <span class=""info-box-number"">");
#nullable restore
#line 16 "C:\Users\Keith\Desktop\doh\WebPDRSystem\WebPDRSystem\Views\Dashboard\CensusPartial.cshtml"
                                                         Write(Model.TotalCensus);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                            </div>
                            <!-- /.info-box-content -->
                        </div>
                        <!-- /.info-box -->
                    </div>

                    <div class=""col-md-12"">
                        <div class=""chartjs-size-monitor""><div class=""chartjs-size-monitor-expand""><div");
            BeginWriteAttribute("class", " class=\"", 910, "\"", 918, 0);
            EndWriteAttribute();
            WriteLiteral("></div></div><div class=\"chartjs-size-monitor-shrink\"><div");
            BeginWriteAttribute("class", " class=\"", 977, "\"", 985, 0);
            EndWriteAttribute();
            WriteLiteral(@"></div></div></div>
                        <canvas id=""pieChart"" style=""height: 230px; min-height: 230px; display: block; width: 572px;"" width=""715"" height=""287"" class=""chartjs-render-monitor""></canvas>
                    </div>
                    <div class=""col-md-12"">
                        <div class=""info-box"">
                            <div class=""info-box-content"">
                                <span class=""info-box-text"">MAY GO HOME</span>
                                <span class=""info-box-number"">");
#nullable restore
#line 31 "C:\Users\Keith\Desktop\doh\WebPDRSystem\WebPDRSystem\Views\Dashboard\CensusPartial.cshtml"
                                                         Write(Model.MayGoHome);

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
                                <span class=""info-box-text"">ODR</span>
                                <span class=""info-box-number"">");
#nullable restore
#line 44 "C:\Users\Keith\Desktop\doh\WebPDRSystem\WebPDRSystem\Views\Dashboard\CensusPartial.cshtml"
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
                                <span class=""info-box-text"">ODG</span>
                                <span class=""info-box-number"">");
#nullable restore
#line 55 "C:\Users\Keith\Desktop\doh\WebPDRSystem\WebPDRSystem\Views\Dashboard\CensusPartial.cshtml"
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
                                <span class=""info-box-text"">QOD</span>
                                <span class=""info-box-number"">");
#nullable restore
#line 66 "C:\Users\Keith\Desktop\doh\WebPDRSystem\WebPDRSystem\Views\Dashboard\CensusPartial.cshtml"
                                                         Write(Model.QOD);

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
                                <span class=""info-box-text"">CHAMBER A NOD</span>
                                <span class=""info-box-number"">");
#nullable restore
#line 77 "C:\Users\Keith\Desktop\doh\WebPDRSystem\WebPDRSystem\Views\Dashboard\CensusPartial.cshtml"
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
                                <span class=""info-box-text"">CHAMBER B NOD</span>
                                <span class=""info-box-number"">");
#nullable restore
#line 88 "C:\Users\Keith\Desktop\doh\WebPDRSystem\WebPDRSystem\Views\Dashboard\CensusPartial.cshtml"
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
#line 108 "C:\Users\Keith\Desktop\doh\WebPDRSystem\WebPDRSystem\Views\Dashboard\CensusPartial.cshtml"
                  Write(Model.CurrBedOccupancy);

#line default
#line hidden
#nullable disable
            WriteLiteral(",");
#nullable restore
#line 108 "C:\Users\Keith\Desktop\doh\WebPDRSystem\WebPDRSystem\Views\Dashboard\CensusPartial.cshtml"
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
