using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Text;
using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class EnclosureController : Controller
    {
        //public IEnumerable<Enclosure> Enclosures { get; set; }
        private readonly ApplicationDbContext _db;
        public EnclosureController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            ViewData["StadiumId"] = new SelectList(_db.Stadiums, "Id", "Std_Name");

            IEnumerable<Enclosure> Enclosures = _db.Enclosures.Include(s=>s.Stadiums);
            return View(Enclosures);
        }

        public IActionResult Create()
        {
            ViewData["StadiumId"] = new SelectList(_db.Stadiums, "Id", "Std_Name");

            
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
            ViewData["StadiumId"] = new SelectList(_db.Stadiums, "Id", "Name", obj.StadiumId);
                return View(obj);
            }



        }





        public IActionResult Edit(int? id)
        {
            if (id == 0 || id == null)
                return NotFound();

            var Enc=_db.Enclosures.Find(id);

            return View(Enc);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Enclosure obj)
        {


            if (ModelState.IsValid)
            {

                _db.Enclosures.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Successfully updated  enclosure.";
                ViewData["StadiumId"] = new SelectList(_db.Stadiums, "Id", "Name", obj.StadiumId);
                return RedirectToAction("Index");
            }
            else
            {
                TempData["error"] = "error has occured";
                ModelState.AddModelError("Name", $"{obj.Name} is already present .kindly enter different name");
                return View(obj);
            }




        }


        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            else
            {

                var Enc = _db.Enclosures.Find(id);

                return View(Enc);
            }


        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {



            var Enc = _db.Enclosures.Find(id);

            if (Enc == null)
            {
                return (NotFound());
            }
            _db.Enclosures.Remove(Enc);
            _db.SaveChanges();
            TempData["success"] = "Successfully deleted Enclosure.";
            return RedirectToAction("Index");


        }




    }
}
