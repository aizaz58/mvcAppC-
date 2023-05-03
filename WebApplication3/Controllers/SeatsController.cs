using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Data;
using WebApplication3.Models;
using WebApplication3.Services;

namespace WebApplication3.Controllers
{
    public class SeatsController : Controller
    {
      
        private readonly IUnitOfWork _unitOfWork;

        public SeatsController(IUnitOfWork unitOfWork)
        {
           
            this._unitOfWork = unitOfWork;
        }

        // GET: Seats
        public IActionResult Index()
        {

            var seats = _unitOfWork.Seat.IncludeOther(x=>x.Enclosures).ToList();
            return View( seats);
        }

       
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null || _context.Seats == null)
        //    {
        //        return NotFound();
        //    }

        //    var seat = await _context.Seats
        //        .Include(s => s.Enclosures)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (seat == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(seat);
        //}

        // GET: Seats/Create
        public IActionResult Create()
        {
            ViewData["EnclosureId"] = new SelectList(_unitOfWork.Enclosure.GetAll(), "Id", "Name");
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create( Seat seat)
        {
            if (ModelState.IsValid)
            {
               _unitOfWork.Seat.Add(seat);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            ViewData["EnclosureId"] = new SelectList(_unitOfWork.Enclosure.GetAll(), "Id", "Name", seat.EnclosureId);
            return View(seat);
        }

       
        public IActionResult Edit(int? id)
        {
            if (id == null || _unitOfWork.Seat.GetAll() == null)
            {
                return NotFound();
            }

            var seat = _unitOfWork.Seat.GetById(id);
            if (seat == null)
            {
                return NotFound();
            }
            ViewData["EnclosureId"] = new SelectList(_unitOfWork.Enclosure.GetAll(), "Id", "Name", seat.EnclosureId);
            return View(seat);
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit( Seat seat)
        {
            if (seat ==null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                
                    _unitOfWork.Seat.Update(seat);
                    _unitOfWork.Save();
                TempData["success"] = "Successfully updated.";



                return RedirectToAction(nameof(Index));
            }
            ViewData["EnclosureId"] = new SelectList(_unitOfWork.Enclosure.GetAll(), "Id", "Name", seat.EnclosureId);
            return View(seat);
        }

        
        public IActionResult Delete(int? id)
        {
            if (id == null ||_unitOfWork.Seat.GetAll() == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Seats'  is null.");
                
            }

            var seat = _unitOfWork.Seat.GetById(id);
              //  .Include(s => s.Enclosures)
               // .FirstOrDefaultAsync(m => m.Id == id);
            if (seat == null)
            {
                return NotFound();
            }

            return View(seat);
        }

        // POST: Seats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            if (_unitOfWork.Seat.GetById(id) == null)
            {
                return NotFound();
            }
            var seat = _unitOfWork.Seat.GetById(id);
            if (seat == null)
            {
                TempData["error"] = "error occured while deleting.";
                return View();

            }
            _unitOfWork.Seat.Delete(seat);
                _unitOfWork.Save();
            TempData["success"] = "Successfully deleted.";
            return RedirectToAction(nameof(Index));
            
           
        }

      
    }
}
