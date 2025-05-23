using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApplication452_simple.Models;

namespace WebApplication452_simple.Controllers
{
    public class HotelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Hotels
        public async Task<ActionResult> Index()
        {
            var hotels = db.Hotels.Include(h => h.Country);
            return View(await hotels.ToListAsync());
        }

        // GET: Hotels/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (!id.HasValue || id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var hotel = await db.Hotels.Include(h => h.Country)
                                       .FirstOrDefaultAsync(h => h.Id == id);
            if (hotel == null)
            {
                return HttpNotFound();
            }

            return View(hotel);
        }

        // GET: Hotels/Create
        public ActionResult Create()
        {
            ViewBag.CountryId = new SelectList(db.Countries, "Id", "Name");
            return View();
        }

        // POST: Hotels/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,CountryId,City,Stars,PricePerNight,IsAllInclusive")] Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                db.Hotels.Add(hotel);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CountryId = new SelectList(db.Countries, "Id", "Name", hotel.CountryId);
            return View(hotel);
        }

        // GET: Hotels/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (!id.HasValue || id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var hotel = await db.Hotels.FirstOrDefaultAsync(h => h.Id == id);
            if (hotel == null)
            {
                return HttpNotFound();
            }

            ViewBag.CountryId = new SelectList(db.Countries, "Id", "Name", hotel.CountryId);
            return View(hotel);
        }

        // POST: Hotels/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,CountryId,City,Stars,PricePerNight,IsAllInclusive")] Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hotel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CountryId = new SelectList(db.Countries, "Id", "Name", hotel.CountryId);
            return View(hotel);
        }

        // GET: Hotels/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (!id.HasValue || id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var hotel = await db.Hotels.FirstOrDefaultAsync(h => h.Id == id);
            if (hotel == null)
            {
                return HttpNotFound();
            }

            return View(hotel);
        }

        // POST: Hotels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var hotel = await db.Hotels.FirstOrDefaultAsync(h => h.Id == id);
            if (hotel == null)
            {
                return HttpNotFound();
            }

            db.Hotels.Remove(hotel);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}