using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HotelReservation.Models;

namespace HotelReservation.Controllers
{
    public class HotelsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<HotelsController> _logger;

        public HotelsController(ApplicationDbContext context, ILogger<HotelsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: Hotels
        public async Task<IActionResult> Index()
        {
            var hotels = await _context.Hotels
                .Include(h => h.Country)
                .ToListAsync();
                
            return View(hotels);
        }

        // GET: Hotels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            
            var hotel = await _context.Hotels
                .Include(h => h.Country)
                .FirstOrDefaultAsync(h => h.Id == id);
                
            if (hotel == null)
            {
                return NotFound();
            }
            
            return View(hotel);
        }

        // GET: Hotels/Create
        public async Task<IActionResult> Create()
        {
            ViewData["CountryId"] = new SelectList(await _context.Countries.ToListAsync(), "Id", "Name");
            return View();
        }

        // POST: Hotels/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,CountryId,City,Stars,PricePerNight,IsAllInclusive")] Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hotel);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Hotel {Name} created successfully", hotel.Name);
                return RedirectToAction(nameof(Index));
            }
            
            ViewData["CountryId"] = new SelectList(await _context.Countries.ToListAsync(), "Id", "Name", hotel.CountryId);
            return View(hotel);
        }

        // GET: Hotels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            
            var hotel = await _context.Hotels.FindAsync(id);
            
            if (hotel == null)
            {
                return NotFound();
            }
            
            ViewData["CountryId"] = new SelectList(await _context.Countries.ToListAsync(), "Id", "Name", hotel.CountryId);
            return View(hotel);
        }

        // POST: Hotels/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,CountryId,City,Stars,PricePerNight,IsAllInclusive")] Hotel hotel)
        {
            if (id != hotel.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hotel);
                    await _context.SaveChangesAsync();
                    _logger.LogInformation("Hotel {Name} updated successfully", hotel.Name);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await HotelExistsAsync(hotel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            
            ViewData["CountryId"] = new SelectList(await _context.Countries.ToListAsync(), "Id", "Name", hotel.CountryId);
            return View(hotel);
        }

        // GET: Hotels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            
            var hotel = await _context.Hotels
                .Include(h => h.Country)
                .FirstOrDefaultAsync(h => h.Id == id);
                
            if (hotel == null)
            {
                return NotFound();
            }
            
            return View(hotel);
        }

        // POST: Hotels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hotel = await _context.Hotels.FindAsync(id);
            
            if (hotel != null)
            {
                _context.Hotels.Remove(hotel);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Hotel {Name} deleted successfully", hotel.Name);
            }
            
            return RedirectToAction(nameof(Index));
        }

        private Task<bool> HotelExistsAsync(int id)
        {
            return _context.Hotels.AnyAsync(e => e.Id == id);
        }
    }
}