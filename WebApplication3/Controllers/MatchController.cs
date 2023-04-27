using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class MatchController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public IEnumerable<Match> matches { get; set; }
        public MatchController(ApplicationDbContext db)
        {
            _dbContext = db;
        }
        public IActionResult Index()
        {
            matches = _dbContext.Matches.Include(s=>s.Stadiums);

            return View(matches);
        }

        public IActionResult Create()
        {
            ViewData["StadiumId"] = new SelectList(_dbContext.Stadiums, "Id", "Std_Name");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Match match)
        {
           if(ModelState.IsValid)
            {
                _dbContext.Matches.Add(match);
                _dbContext.SaveChanges();
                TempData["success"] = "successfully created";
                return RedirectToAction("Index");
            }



            return View(matches);
        }





        public IActionResult Edit(int id)
        {
            var Match = _dbContext.Matches.Find(id);
            ViewData["StadiumId"] = new SelectList(_dbContext.Stadiums, "Id", "Std_Name",Match.StadiumId);




            return View(Match);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Match match)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Matches.Update(match);
                _dbContext.SaveChanges();
                TempData["success"] = "successfully created";
                return RedirectToAction("Index");
            }



            return View(matches);
        }
        public IActionResult Delete(int? id)
        {
            var Match = _dbContext.Matches.Find(id);
            if (id == null || id == 0||Match==null)
            {
                TempData["error"] = "no record found.";
                return NotFound();

            }
            ViewData["StadiumId"] = new SelectList(_dbContext.Stadiums, "Id", "Std_Name",Match.StadiumId);
           
            return View(Match);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {

            var Match = _dbContext.Matches.Find(id);
            if (Match != null)
            {
                _dbContext.Matches.Remove(Match);
                _dbContext.SaveChanges();
                TempData["success"] = "Successfully deleted the record.";
                return RedirectToAction("Index");
            }

            TempData["error"] = "no record found.";
            return View(Match);


           
        }







    }
}
