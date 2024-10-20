using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using ttem2.Models;

namespace ttem2.Controllers
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
            var lstCauThu = db.Cauthus.Where(x => x.CauLacBoId == "101").ToList();
            return View(lstCauThu);
        }






        [HttpGet]
        [Route("Create")]
        public IActionResult Create()
        {

            ViewBag.CauLacBoId = new SelectList(db.Caulacbos.ToList(), "CauLacBoId", "TenClb");
            return View();

        }
        [HttpPost]
        [Route("Create")]
        public IActionResult Create(Cauthu cauthu)
        {
            if (ModelState.IsValid)
            {
                db.Cauthus.Add(cauthu);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "Home");


        }









        [HttpGet]
        [Route("Edit")]
        public IActionResult Edit(string? id)
        {

            var cauthu = db.Cauthus.Where(x => x.CauThuId == id).SingleOrDefault();

            ViewBag.CauLacBoId = new SelectList(db.Caulacbos.ToList(), "CauLacBoId", "TenClb");
            return View(cauthu);

        }
        [HttpPost]
        [Route("Edit")]
        public IActionResult Edit(Cauthu cauthu)
        {
            if (ModelState.IsValid)
            {
                db.Update(cauthu);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "Home");


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
