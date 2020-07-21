#pragma checksum "C:\Users\user\Source\Repos\kiiitiiing\WebPDRSystem\WebPDRSystem\Views\PDRUsers\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9a5d603b5ec62f6275f7c2c70a633a842ed77f09"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_PDRUsers_Index), @"mvc.1.0.view", @"/Views/PDRUsers/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9a5d603b5ec62f6275f7c2c70a633a842ed77f09", @"/Views/PDRUsers/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cd5a22c6d35617c1e3ce08ff0048f0e904e4c32a", @"/Views/_ViewImports.cshtml")]
    public class Views_PDRUsers_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<WebPDRSystem.Models.Pdrusers>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\user\Source\Repos\kiiitiiing\WebPDRSystem\WebPDRSystem\Views\PDRUsers\Index.cshtml"
  
    ViewData["Title"] = "Index";
    var hewi = "60px";

    string BgColor(string role)
    {
        string color = "";

        switch(role)
        {
            case "Doctor":
                {
                    color = "bg-primary";
                    break;
                }
            case "Nurse":
                {
                    color = "bg-warning";
                    break;
                }
            case "Healhcare Buddy":
                {
                    color = "bg-default";
                    break;
                }
        }

        return color;
    }
    

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
    <div class=""content"">
        <div class=""col-md-12"">
            <!-- ONLINE DOCTORS -->
            <div class=""card card-outline"">
                <!-- DAILY USERS HEADER -->
                <div class=""card-header with-border"">
                    <div class=""fa-pull-right form-inline ml-3"">
                        <div class=""input-group input-group-sm"">
                            <input class=""form-control form-control-navbar"" id=""search"" type=""text"" placeholder=""search"">
                            <div class=""input-group-append"">
                                <button class=""btn btn-navbar"" onclick=""Search();"">
                                    <i class=""fas fa-search""></i>
                                </button>
                            </div>
                        </div>
                        <button type=""button"" class=""btn btn-sm btn-default"" data-toggle=""ajax-modal"" data-target=""#add-users"" data-url=""");
#nullable restore
#line 49 "C:\Users\user\Source\Repos\kiiitiiing\WebPDRSystem\WebPDRSystem\Views\PDRUsers\Index.cshtml"
                                                                                                                                    Write(Url.Action("AddUsers","Pdrusers"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@""">
                            <i class=""fas fa-plus""></i>
                            &nbsp;Add
                        </button>
                        <button type=""button"" class=""btn btn-sm btn-success"" data-toggle=""ajax-modal"" data-target=""#new-users"" data-url=""");
#nullable restore
#line 53 "C:\Users\user\Source\Repos\kiiitiiing\WebPDRSystem\WebPDRSystem\Views\PDRUsers\Index.cshtml"
                                                                                                                                    Write(Url.Action("NewUser","Pdrusers"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@""">
                            <i class=""fas fa-plus""></i>
                            &nbsp;New
                        </button>
                    </div>
                    <h2>
                        Team A
                    </h2>
                </div>
                <!-- DAILY USERS BODY -->
                <div class=""card-body"" id=""indexpartial"" style=""height: 350px; overflow-y: auto;"">
                    <div class=""overlay d-flex justify-content-center align-items-center"">
                        <i class=""fas fa-2x fa-sync fa-spin""></i>
                    </div>
                </div>
            </div>
        </div>
    </div>
<script>
    $(function () {
        LoadIndex('');
    })

    function Search() {
        var se = $('#search').val();
        console.log(se);
        LoadIndex(se);
    }
</script>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<WebPDRSystem.Models.Pdrusers>> Html { get; private set; }
    }
}
#pragma warning restore 1591
