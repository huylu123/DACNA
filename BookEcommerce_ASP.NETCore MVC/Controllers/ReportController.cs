using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using AspNetCore.Reporting;
using System.Threading.Tasks;

namespace BookEcommerce_ASP.NETCore_MVC.Controllers
{
    public class ReportController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IRepositoryCheckOut _RepositoryCheckOut;
        public ReportController(IWebHostEnvironment webHostEnvironment, IRepositoryCheckOut RepositoryCheckOut)
        {
            this._webHostEnvironment = webHostEnvironment;
            this._RepositoryCheckOut = RepositoryCheckOut;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task< IActionResult> Print()
        {
            string mimtype = "";
            int extension = 1;
            var path = $"{this._webHostEnvironment.WebRootPath}\\Reports\\Report2.rdlc";
            Dictionary<string, string> paramaters = new Dictionary<string, string>();
           //paramaters.Add("rp1", "hello");
            var checkout = await _RepositoryCheckOut.GetCheckouts(); 
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("Data", checkout);
            var result = localReport.Execute(RenderType.Pdf, extension, paramaters, mimtype);
            return File(result.MainStream, "application/pdf");

            
        }
    }
}
