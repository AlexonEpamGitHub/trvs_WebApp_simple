using Microsoft.AspNetCore.Mvc;
using System.Linq;
using YourNamespace.Models;

namespace YourNamespace.Controllers
{
    public class HotelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        // Constructor for injecting ApplicationDbContext
        public HotelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Index method displaying all Hotels
        public IActionResult Index()
        {
            var hotels = _context.Hotels.ToList();
            return View(hotels);
        }

        // GET: Create Hotel form
        public IActionResult Create()
        {
            return View();
        }

        // POST: Save created Hotel
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
            return View(hotel);
        }

        // GET: Edit Hotel form
        public IActionResult Edit(int id)
        {
            var hotel = _context.Hotels.Find(id);
            if (hotel == null)
            {
                return NotFound();
            }
            return View(hotel);
        }

        // POST: Save updated Hotel
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                _context.Hotels.Update(hotel);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(hotel);
        }

        // GET: Details of a Hotel
        public IActionResult Details(int id)
        {
            var hotel = _context.Hotels.Find(id);
            if (hotel == null)
            {
                return NotFound();
            }
            return View(hotel);
        }

        // GET: Confirm delete Hotel
        public IActionResult Delete(int id)
        {
            var hotel = _context.Hotels.Find(id);
            if (hotel == null)
            {
                return NotFound();
            }
            return View(hotel);
        }

        // POST: Confirm and delete Hotel
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
    }
}