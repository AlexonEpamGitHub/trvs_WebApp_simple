using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using new_app.Models;

namespace new_app.Controllers
{
    [ApiController]
    [Route("api/countries")]
    public class CountriesController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public CountriesController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/countries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Country>>> GetCountries()
        {
            return await _dbContext.Countries.ToListAsync();
        }

        // GET: api/countries/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Country>> GetCountry(int id)
        {
            var country = await _dbContext.Countries.FindAsync(id);

            if (country == null)
            {
                return NotFound();
            }

            return country;
        }

        // POST: api/countries
        [HttpPost]
        public async Task<ActionResult<Country>> CreateCountry(Country country)
        {
            _dbContext.Countries.Add(country);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCountry), new { id = country.Id }, country);
        }

        // PUT: api/countries/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCountry(int id, Country country)
        {
            if (id != country.Id)
            {
                return BadRequest();
            }

            _dbContext.Entry(country).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CountryExists(id))
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }

        // DELETE: api/countries/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            var country = await _dbContext.Countries.FindAsync(id);
            if (country == null)
            {
                return NotFound();
            }

            _dbContext.Countries.Remove(country);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        private bool CountryExists(int id)
        {
            return _dbContext.Countries.Any(e => e.Id == id);
        }
    }
}