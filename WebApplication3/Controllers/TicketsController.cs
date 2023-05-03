using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Data;
using WebApplication3.Models;
using WebApplication3.Repositories;

namespace WebApplication3.Controllers
{
    public class TicketsController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        public IEnumerable<Ticket> Tickets { get; set; }
        public TicketsController(IUnitOfWork unitOfWork)
        {
       
            this._unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            //var ticket1 = _unitOfWork.Ticket.GetAll();

            Tickets = _unitOfWork.Ticket.IncludeOther(s=>s.Matches );

            return View(Tickets);
        }



        public IActionResult Create()
        {
            
            ViewData["Matchid"] = new SelectList(_unitOfWork.Match.GetAll(),"Id", "MatchName") ;
            ViewData["SeatId"] = new SelectList(_unitOfWork.Seat.GetAll(),"Id","SeatNo");

            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Ticket tkt)
        {

            if(ModelState.IsValid)
            {
                _unitOfWork.Ticket.Add(tkt);
                _unitOfWork.Save();
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
            var Tkt = _unitOfWork.Ticket.GetById(id);
            if (Tkt == null)
            {
                TempData["error"] = "no Ticket found.";
                return NotFound();

            }
            ViewData["Matchid"] = new SelectList(_unitOfWork.Match.GetAll(), "Id", "MatchName",Tkt.MatchId);
            ViewData["SeatId"] = new SelectList(_unitOfWork.Seat.GetAll(), "Id", "SeatNo",Tkt.SeatId);

            return View(Tkt);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Ticket tkt)
        {

            if (ModelState.IsValid)
            {
                _unitOfWork.Ticket.Update(tkt);
                _unitOfWork.Save();
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
            var Tkt = _unitOfWork.Ticket.GetById(id);
            
            if (Tkt == null)
            {
                TempData["error"] = "no Ticket found.";
                return NotFound();

            }
            ViewData["Matchid"] = new SelectList(_unitOfWork.Match.GetAll(), "Id", "MatchName");
            ViewData["SeatId"] = new SelectList(_unitOfWork.Seat.GetAll(), "Id", "SeatNo");

            return View(Tkt);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int? id)
        {
            var Ticket = _unitOfWork.Ticket.GetById(id);
            if (Ticket==null)
            {
            TempData["error"] = "not found.";
                return NotFound();
            }
            _unitOfWork.Ticket.Delete(Ticket);
            _unitOfWork.Save();
            TempData["success"] = $"Ticket No.{Ticket.Id} has been deleted successfully.";
            return RedirectToAction("Index");

     
        }


    }
}
