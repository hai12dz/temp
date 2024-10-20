using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using tem3.Models;

namespace tem3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        QlgiaiBongDaContext db = new QlgiaiBongDaContext();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var lstHLV = db.Huanluyenviens.ToList();
            return View(lstHLV);
        }






        [HttpGet]
        [Route("Details")] // Thay ??i route thành "Details"
        public IActionResult Detail(string? id)
        {
            var cauthu = db.Cauthus.Where(x => x.CauThuId == id).SingleOrDefault();
            return View(cauthu);
        }

























        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
