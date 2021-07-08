using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiDinkToPdf.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GeneradorPdfController : ControllerBase
    {

        private IConverter _converter;

        public GeneradorPdfController(IConverter converter)
        {
            _converter = converter;
        }

        [HttpGet("{nombre}")]
        public IActionResult Get(string nombre)
        {

            try
            {
                //IConverter _converter = new SynchronizedConverter(new PdfTools());

                var tender = new TemplateGenerator();
                var html = tender.GetHTMLString("reporte.html");
                html = html.Replace("{NOMBRE}", nombre);
                var globalSettings = new GlobalSettings
                {
                    ColorMode = ColorMode.Color,
                    Orientation = Orientation.Portrait,
                    PaperSize = PaperKind.A4,
                    Margins = new MarginSettings { Top = 10 },
                    DocumentTitle = "PDF Report"
                };
                var objectSettings = new ObjectSettings
                {
                    PagesCount = true,
                    HtmlContent = html
                    //WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = Path.Combine(Directory.GetCurrentDirectory(), "assets", "styles.css") },
                    //HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Page [page] of [toPage]", Line = true },
                    //FooterSettings = { FontName = "Arial", FontSize = 9, Line = true, Center = "Report Footer" }
                };
                var pdf = new HtmlToPdfDocument()
                {
                    GlobalSettings = globalSettings,
                    Objects = { objectSettings }
                };
                var file = _converter.Convert(pdf);
                return File(file, "application/pdf");
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
            
        }

        [HttpGet]
        public IActionResult GetAnother([FromQuery] string url)
        {

            try
            {
                //IConverter _converter = new SynchronizedConverter(new PdfTools());
                //string archivourl = "https://" + dominio + "/" + blob + "/" + archivo;
                var globalSettings = new GlobalSettings
                {
                    ColorMode = ColorMode.Color,
                    Orientation = Orientation.Portrait,
                    PaperSize = PaperKind.A4,
                    Margins = new MarginSettings { Top = 10 },
                    DocumentTitle = "PDF Report"
                };
                var objectSettings = new ObjectSettings
                {
                    //PagesCount = true,
                    Page = url
                    //Page = "https://gtitanalmc.blob.core.windows.net/gtcomparte/reporte_2.html?name=sinthia"
                    //WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = Path.Combine(Directory.GetCurrentDirectory(), "assets", "styles.css") },
                    //HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Page [page] of [toPage]", Line = true },
                    //FooterSettings = { FontName = "Arial", FontSize = 9, Line = true, Center = "Report Footer" }
                };
                var pdf = new HtmlToPdfDocument()
                {
                    GlobalSettings = globalSettings,
                    Objects = { objectSettings }
                };
                var file = _converter.Convert(pdf);
                return File(file, "application/pdf");
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }

        }
    }
}
