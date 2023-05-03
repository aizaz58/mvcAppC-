using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Data;
using WebApplication3.Models;
using WebApplication3.Services;

namespace WebApplication3.Controllers
{
    public class MatchController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IUnitOfWork _unitOfWork;

        public IEnumerable<Match> Matches { get; set; }
        public MatchController(IUnitOfWork unitOfWork)
        {
            
            this._unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            Matches = _unitOfWork.Match.IncludeOther(x=>x.Stadiums).ToList();


            return View(Matches);
        }

        public IActionResult Create()
        {
            ViewData["StadiumId"] = new SelectList(_unitOfWork.Stadium.GetAll(), "Id", "Std_Name");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Match match)
        {
           if(ModelState.IsValid)
            {
                _unitOfWork.Match.Add(match);
                _unitOfWork.Save();
                TempData["success"] = "successfully created";
                return RedirectToAction("Index");
            }



            return View(Matches);
        }





        public IActionResult Edit(int id)
        {
            var Match = _unitOfWork.Match.GetById(id);
            ViewData["StadiumId"] = new SelectList(_unitOfWork.Stadium.GetAll(), "Id", "Std_Name",Match.StadiumId);




            return View(Match);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Match match)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Match.Update(match);
                _unitOfWork.Save();
                TempData["success"] = "successfully created";
                return RedirectToAction("Index");
            }



            return View(Matches);
        }
        public IActionResult Delete(int? id)
        {
            var Match = _unitOfWork.Match.GetById(id);
            if (id == null || id == 0||Match==null)
            {
                TempData["error"] = "no record found.";
                return NotFound();

            }
            ViewData["StadiumId"] = new SelectList(_unitOfWork.Stadium.GetAll(), "Id", "Std_Name",Match.StadiumId);
           
            return View(Match);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {

            var Match = _unitOfWork.Match.GetById(id);
            if (Match != null)
            {
                _unitOfWork.Match.Delete(Match);
                _unitOfWork.Save();
                TempData["success"] = "Successfully deleted the record.";
                return RedirectToAction("Index");
            }

            TempData["error"] = "no record found.";
            return View(Match);


           
        }







    }
}
