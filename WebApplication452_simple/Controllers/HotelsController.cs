using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication452_simple.Models;

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
        public IActionResult Index()
        {
            var hotels = _context.Hotels.Include(h => h.Country);
            return View(hotels.ToList());
        }

        // GET: Hotels/Details/5
        public IActionResult Details(int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest();
            }

            var hotel = _context.Hotels
                .Include(h => h.Country)
                .FirstOrDefault(h => h.Id == id.Value);

            if (hotel == null)
            {
                return NotFound();
            }

            return View(hotel);
        }

        // GET: Hotels/Create
        public IActionResult Create()
        {
            ViewBag.CountryId = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(_context.Countries, "Id", "Name");
            return View();
        }

        // POST: Hotels/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                _context.Hotels.Add(hotel);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.CountryId = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(_context.Countries, "Id", "Name", hotel.CountryId);
            return View(hotel);
        }

        // GET: Hotels/Edit/5
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

            ViewBag.CountryId = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(_context.Countries, "Id", "Name", hotel.CountryId);
            return View(hotel);
        }

        // POST: Hotels/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(hotel).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.CountryId = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(_context.Countries, "Id", "Name", hotel.CountryId);
            return View(hotel);
        }

        // GET: Hotels/Delete/5
        public IActionResult Delete(int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest();
            }

            var hotel = _context.Hotels
                .Include(h => h.Country)
                .FirstOrDefault(h => h.Id == id.Value);

            if (hotel == null)
            {
                return NotFound();
            }

            return View(hotel);
        }

        // POST: Hotels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var hotel = _context.Hotels.Find(id);
            if (hotel != null)
            {
                _context.Hotels.Remove(hotel);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
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