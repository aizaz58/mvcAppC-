using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApplication3.Data;
using WebApplication3.Models;
using WebApplication3.Services;

namespace WebApplication3.Controllers
{
    public class StadiumController : Controller
    {
        
        private readonly IUnitOfWork _unitOfWork;

        public IEnumerable<Stadium> Stadiums { get; set; }

        public StadiumController(IUnitOfWork unitOfWork)
        {
           
            this._unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {

            return View(_unitOfWork.Stadium.GetAll().ToList());
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
                _unitOfWork.Stadium.Add(obj);
                _unitOfWork.Save();
                // _db.Stadiums.Add(obj);
               // _db.SaveChanges();
                TempData["success"] = "Successfully created new stadium.";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["error"] = "error has ocured.";
                ModelState.AddModelError("Std_Name", $"{obj.Std_Name} is already present .kindly enter different name");
                return View(obj);
            }
        }



        //Edit
        public IActionResult Edit(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            else
            {

                var Std = _unitOfWork.Stadium.GetById(id);
                

                return View(Std);
            }


        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Stadium obj)
        {


            if (ModelState.IsValid)
            {
                _unitOfWork.Stadium.Update(obj);
                _unitOfWork.Save();
                
                TempData["success"] = "Successfully updated stadium.";
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

                var Std = _unitOfWork.Stadium.GetById(id);


                return View(Std);
            }


        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {



            var Std = _unitOfWork.Stadium.GetById(id);

            if (Std == null)
            {
                return(NotFound());
            }
            _unitOfWork.Stadium.Delete(Std);
            _unitOfWork.Save();
            TempData["success"] = "Successfully deleted stadium.";
            return RedirectToAction("Index");
            
            
        }







    }
}


