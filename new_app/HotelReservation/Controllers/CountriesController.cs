using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelReservation.Models;

namespace HotelReservation.Controllers
{
    public class CountriesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<CountriesController> _logger;

        public CountriesController(ApplicationDbContext context, ILogger<CountriesController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: Countries
        public async Task<IActionResult> Index()
        {
            return View(await _context.Countries.ToListAsync());
        }

        // GET: Countries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            
            var country = await _context.Countries
                .Include(c => c.Hotels)
                .FirstOrDefaultAsync(c => c.Id == id);
                
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
        public async Task<IActionResult> Create([Bind("Id,Name")] Country country)
        {
            if (ModelState.IsValid)
            {
                _context.Add(country);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Country {Name} created successfully", country.Name);
                return RedirectToAction(nameof(Index));
            }
            return View(country);
        }

        // GET: Countries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            
            var country = await _context.Countries.FindAsync(id);
            
            if (country == null)
            {
                return NotFound();
            }
            
            return View(country);
        }

        // POST: Countries/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Country country)
        {
            if (id != country.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(country);
                    await _context.SaveChangesAsync();
                    _logger.LogInformation("Country {Name} updated successfully", country.Name);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await CountryExistsAsync(country.Id))
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
            return View(country);
        }

        // GET: Countries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            
            var country = await _context.Countries
                .Include(c => c.Hotels)
                .FirstOrDefaultAsync(c => c.Id == id);
                
            if (country == null)
            {
                return NotFound();
            }
            
            ViewData["HasHotels"] = country.Hotels.Any();
            return View(country);
        }

        // POST: Countries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var country = await _context.Countries
                .Include(c => c.Hotels)
                .FirstOrDefaultAsync(c => c.Id == id);
                
            if (country != null)
            {
                if (country.Hotels.Any())
                {
                    ModelState.AddModelError(string.Empty, "Cannot delete country that has hotels associated with it.");
                    ViewData["HasHotels"] = true;
                    return View(country);
                }
                
                _context.Countries.Remove(country);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Country {Name} deleted successfully", country.Name);
            }
            
            return RedirectToAction(nameof(Index));
        }

        private Task<bool> CountryExistsAsync(int id)
        {
            return _context.Countries.AnyAsync(e => e.Id == id);
        }
    }
}