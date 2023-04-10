using Microsoft.AspNetCore.Mvc;
using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class EnclosureController : Controller
    {
        public IEnumerable<Enclosure> Enclosures { get; private set; }
        private readonly ApplicationDbContext _db;
        public EnclosureController(ApplicationDbContext db)
        {
            _db = db;
        }


        public IActionResult Index()
        {
            Enclosures = _db.Enclosures;
            return View(Enclosures);
        }

        public IActionResult Create()
        {
           
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Enclosure obj)
        {

            if (ModelState.IsValid)
            {

                _db.Enclosures.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Successfully created new enclosure.";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["error"] = "Successfully created new enclosure.";
                ModelState.AddModelError("Name", $"{obj.Name} is already present .kindly enter different name");
                return View(obj);
            }



            
        }


    }
}
