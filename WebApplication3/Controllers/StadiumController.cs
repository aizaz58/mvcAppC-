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
    }
}
