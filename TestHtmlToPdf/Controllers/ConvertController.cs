
using IronPdf;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TestHtmlToPdf.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConvertController : ControllerBase
    {

        [HttpGet]
        public IActionResult CreatePDF()
        {
            //bool result = IronPdf.License.IsValidLicense("IRONPDF.SINTHIARODRIGUEZ.32129-C6AE15D959-53H7JJNO24OSEZ5P-YZTMH7PA3KSM-NPIWPDYCBQG4-Q6EZ54HRRLBC-F3SFXHCAIX6E-M22C74-TMDRZDSAQIWAUA-DEPLOYMENT.TRIAL-QBGKCQ.TRIAL.EXPIRES.06.JUL.2021");

            //bool is_licensed = IronPdf.License.IsLicensed;

            //var Renderer = new HtmlToPdf();
            //Renderer.PrintOptions.CssMediaType = PdfPrintOptions.PdfCssMediaType.Print;
            //Renderer.PrintOptions.EnableJavaScript = true;
            //Renderer.PrintOptions.RenderDelay = 500; //milliseconds

            var PDF = HtmlToPdf.StaticRenderHTMLFileAsPdf("REPORTE/output.html");
            //var OutputPath = "estoPrueba.pdf";
            //var file = PDF.SaveAs(OutputPath);

            //var PDF = HtmlToPdf.StaticRenderUrlAsPdf(new Uri("https://gtitanalmc.blob.core.windows.net/gtcomparte/reporte_2.html?name=sinthiaaaaa"));
            return File(PDF.BinaryData, "application/pdf");
            //return Ok("Successfully created PDF document.");
        }

    }
}
