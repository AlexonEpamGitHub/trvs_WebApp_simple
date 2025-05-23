using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication452_simple.Models;
using System.Linq;

namespace WebApplication452_simple.Controllers
{
    public class HotelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HotelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Hotels
        [HttpGet]
        public IActionResult Index()
        {
            var hotels = _context.Hotels.Include(h => h.Country);
            return View(hotels.ToList());
        }

        // GET: Hotels/Details/5
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest();
            }

            var hotel = _context.Hotels.Find(id.Value);
            if (hotel == null)
            {
                return NotFound();
            }

            return View(hotel);
        }

        // GET: Hotels/Create
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.CountryId = new SelectList(_context.Countries, "Id", "Name");
            return View();
        }

        // POST: Hotels/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromForm] Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                _context.Hotels.Add(hotel);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.CountryId = new SelectList(_context.Countries, "Id", "Name", hotel.CountryId);
            return View(hotel);
        }

        // GET: Hotels/Edit/5
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest();
            }

            var hotel = _context.Hotels.Find(id.Value);
            if (hotel == null)
            {
                return NotFound();
            }

            ViewBag.CountryId = new SelectList(_context.Countries, "Id", "Name", hotel.CountryId);
            return View(hotel);
        }

        // POST: Hotels/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [FromForm] Hotel hotel)
        {
            if (id != hotel.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Entry(hotel).State = EntityState.Modified;
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Hotels.Any(e => e.Id == id))
                    {
                        return NotFound();
                    }
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }

            ViewBag.CountryId = new SelectList(_context.Countries, "Id", "Name", hotel.CountryId);
            return View(hotel);
        }

        // GET: Hotels/Delete/5
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest();
            }

            var hotel = _context.Hotels.Find(id.Value);
            if (hotel == null)
            {
                return NotFound();
            }

            return View(hotel);
        }

        // POST: Hotels/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var hotel = _context.Hotels.Find(id);
            if (hotel != null)
            {
                _context.Hotels.Remove(hotel);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return NotFound();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}