using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication452_simple.Models;
using System.Linq;

namespace WebApplication452_simple.Controllers
{
    public class CountriesController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CountriesController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: Countries
        public IActionResult Index()
        {
            return View(_db.Countries.ToList());
        }

        // GET: Countries/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return StatusCode(400); // BadRequest
            }
            var country = _db.Countries.Find(id);
            if (country == null)
            {
                return NotFound();
            }
            return View(country);
        }

        // GET: Countries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Countries/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name")] Country country)
        {
            if (ModelState.IsValid)
            {
                _db.Countries.Add(country);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(country);
        }

        // GET: Countries/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return StatusCode(400); // BadRequest
            }
            var country = _db.Countries.Find(id);
            if (country == null)
            {
                return NotFound();
            }
            return View(country);
        }

        // POST: Countries/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind("Id,Name")] Country country)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(country).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(country);
        }

        // GET: Countries/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return StatusCode(400); // BadRequest
            }
            var country = _db.Countries.Find(id);
            if (country == null)
            {
                return NotFound();
            }
            return View(country);
        }

        // POST: Countries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var country = _db.Countries.Find(id);
            if (country != null)
            {
                _db.Countries.Remove(country);
                _db.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}