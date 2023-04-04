using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class StadiumController : Controller
    {
        private readonly ApplicationDbContext _db;
        public IEnumerable<Stadium> Stadiums { get; set; }

        public StadiumController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            Stadiums = _db.Stadiums;

            return View(Stadiums);
        }


        //Get Stadiums Actionmethod
        public IActionResult Create()
        {

            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Stadium obj)
        {


            if (ModelState.IsValid)
            {

                _db.Stadiums.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("Std_Name", $"{obj.Std_Name} is already present .kindly enter different name");
                return View(obj);
            }
        }



        //Edit
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            else
            {

                var Std = _db.Stadiums.Find(id);
                

                return View(Std);
            }


        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Stadium obj)
        {


            if (ModelState.IsValid)
            {
                
                _db.Stadiums.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("Std_Name", $"{obj.Std_Name} is already present .kindly enter different name");
                return View(obj);
            }
        }






        //Delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            else
            {

                var Std = _db.Stadiums.Find(id);

                return View(Std);
            }


        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {



            var Std = _db.Stadiums.Find(id);

            if (Std == null)
            {
                return(NotFound());
            }
            _db.Stadiums.Remove(Std);
                _db.SaveChanges();
                return RedirectToAction("Index");
            
            
        }







    }
}


