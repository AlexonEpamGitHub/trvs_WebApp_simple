using Microsoft.AspNetCore.Mvc;
using new_app.Models; // Assuming Models namespace
using System.Linq;

namespace new_app.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context; // Entity Framework context

        public CountriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/countries
        [HttpGet]
        public IActionResult GetCountries()
        {
            var countries = _context.Countries.ToList();
            return Ok(countries);
        }

        // GET: api/countries/{id}
        [HttpGet("{id}")]
        public IActionResult GetCountry(int id)
        {
            var country = _context.Countries.FirstOrDefault(c => c.Id == id);
            if (country == null)
            {
                return NotFound();
            }
            return Ok(country);
        }

        // POST: api/countries
        [HttpPost]
        public IActionResult CreateCountry([FromBody] Country country)
        {
            if (ModelState.IsValid)
            {
                _context.Countries.Add(country);
                _context.SaveChanges();
                return CreatedAtAction(nameof(GetCountry), new { id = country.Id }, country);
            }
            return BadRequest(ModelState);
        }

        // PUT: api/countries/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateCountry(int id, [FromBody] Country country)
        {
            if (id != country.Id || !ModelState.IsValid)
            {
                return BadRequest();
            }

            var existingCountry = _context.Countries.FirstOrDefault(c => c.Id == id);
            if (existingCountry == null)
            {
                return NotFound();
            }

            existingCountry.Name = country.Name; // Modify fields as per Country model
            // Add other fields as necessary
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/countries/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteCountry(int id)
        {
            var country = _context.Countries.FirstOrDefault(c => c.Id == id);
            if (country == null)
            {
                return NotFound();
            }

            _context.Countries.Remove(country);
            _context.SaveChanges();
            return NoContent();
        }
    }
}