using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebPDRSystem.Data;
using WebPDRSystem.Models;
using WebPDRSystem.Services;

namespace WebPDRSystem.Controllers
{
    public class ToPdfController : Controller
    {
        private readonly WebPDRContext _context;
        private IConverter _converter;

        public ToPdfController(WebPDRContext context, IConverter converter)
        {
            _context = context;
            _converter = converter;
        }

        public async Task<IActionResult> ViewLabResults(int pdrId)
        {
            var results = await _context.LabResult
                .Include(x => x.Pdr)
                    .ThenInclude(x => x.PatientNavigation)
                .Where(x => x.PdrId == pdrId)
                .FirstOrDefaultAsync();

            var file = SetPDF(results);

            return File(file, "application/pdf");
        }

        #region HELPERS
        public byte[] SetPDF(LabResult form)
        {
            new CustomAssemblyLoadContext().LoadUnmanagedLibrary(Path.Combine(Directory.GetCurrentDirectory(), "libwkhtmltox.dll"));
            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 1.54, Bottom = 1.34, Left = 1.34, Right = 1.34, Unit = Unit.Centimeters },
                DocumentTitle = form.Pdr.PatientNavigation.GetFullName() + " Lab results"
            };
            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = /*DTR(),*/ LabResults(form),
                WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "assets", "dist", "css", "adminlte.css") }
            };

            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };
            return _converter.Convert(pdf);
        }

        public string LabResults(LabResult model)
        {
            var pdf = new StringBuilder();

            pdf.Append(@"
            <html>
            <head></head>
            <body>
            <p>hellooowww</p>
            ");

            pdf.AppendFormat(@"
            <div class='row'>
                <div class='col-md-12'>
                    <img src='/img/LabResults/{0}' style='width=100%; height=auto;'/>
                </div>
            </div>
            ",model.ResultPic);

            pdf.AppendFormat(@"
            {0}
            ", model.ResultPic);

            pdf.Append(@"
            </body>
            </html>
            ");

            return pdf.ToString(); ;
        }


        #endregion
    }
}