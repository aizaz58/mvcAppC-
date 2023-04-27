using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class TicketsController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public IEnumerable<Ticket> Tickets { get; set; }
        public TicketsController(ApplicationDbContext db)
        {
            _dbContext = db;
        }
        public IActionResult Index()
        {
            var ticket1 = _dbContext.Tickets;

            Tickets = _dbContext.Tickets.Include(s=>s.Seats).Include(y=>y.Matches);

            return View(Tickets);
        }



        public IActionResult Create()
        {
            
            ViewData["Matchid"] = new SelectList(_dbContext.Matches,"Id", "MatchName") ;
            ViewData["SeatId"] = new SelectList(_dbContext.Seats,"Id","SeatNo");

            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Ticket tkt)
        {

            if(ModelState.IsValid)
            {
                _dbContext.Tickets.Add(tkt);
                _dbContext.SaveChanges();
                TempData["success"] = $"Ticket No.{tkt.Id} has created successfully.";
                return RedirectToAction("Index");
            }
            
            TempData["error"] ="Something wrong happened." ;

            return View();
        }




        public IActionResult Edit(int id)
        {
            if (id == 0)
                return NotFound();
            var Tkt = _dbContext.Tickets.Find(id);
            if (Tkt == null)
            {
                TempData["error"] = "no Ticket found.";
                return NotFound();

            }
            ViewData["Matchid"] = new SelectList(_dbContext.Matches, "Id", "MatchName",Tkt.MatchId);
            ViewData["SeatId"] = new SelectList(_dbContext.Seats, "Id", "SeatNo",Tkt.SeatId);

            return View(Tkt);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Ticket tkt)
        {

            if (ModelState.IsValid)
            {
                _dbContext.Tickets.Update(tkt);
                _dbContext.SaveChanges();
                TempData["success"] = $"Ticket No.{tkt.Id} has created successfully.";
                return RedirectToAction("Index");
            }

            TempData["error"] = "Something wrong happened.";

            return View();
        }





        public IActionResult Delete(int id)
        {
            if (id == 0)
                return NotFound();
            var Tkt = _dbContext.Tickets.Find(id);
            
            if (Tkt == null)
            {
                TempData["error"] = "no Ticket found.";
                return NotFound();

            }
            ViewData["Matchid"] = new SelectList(_dbContext.Matches, "Id", "MatchName");
            ViewData["SeatId"] = new SelectList(_dbContext.Seats, "Id", "SeatNo");

            return View(Tkt);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int? id)
        {
            var Ticket = _dbContext.Tickets.Find(id);
            if (Ticket==null)
            {
            TempData["error"] = "not found.";
                return NotFound();
            }
            _dbContext.Tickets.Remove(Ticket);
            _dbContext.SaveChanges();
            TempData["success"] = $"Ticket No.{Ticket.Id} has been deleted successfully.";
            return RedirectToAction("Index");

     
        }


    }
}
