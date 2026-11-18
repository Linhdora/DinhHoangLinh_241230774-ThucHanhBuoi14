using DinhHoangLinh_241230774.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace DinhHoangLinh_241230774.Controllers
{
    public class HomeController : Controller
    {
        private readonly QLNhaSachContext db;
        public HomeController(QLNhaSachContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            var ds = db.Saches.Where(s => s.Gia != null && s.Gia >= 100).ToList();
            return View(ds);
        }
        public IActionResult TheoTheLoai(int id)
        {
            var ds = db.Saches.Where(s => s.MaTl == id).ToList();
            return PartialView("_DinhHoangLinh_DanhSachSach", ds);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.DsTheLoai = new SelectList(db.TheLoais, "MaTL", "TenTL");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Sach sach)
        {
            if (ModelState.IsValid)
            {
                db.Saches.Add(sach);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DsTheLoai = new SelectList(db.TheLoais, "MaTL", "TenTL", sach.MaTl);
            return View(sach);
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
