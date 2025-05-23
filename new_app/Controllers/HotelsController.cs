using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using new_app.Models;

namespace new_app.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HotelsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public HotelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Hotels
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Hotel>>> GetHotels()
        {
            var hotels = await _context.Hotels.Include(h => h.Country).ToListAsync();
            return Ok(hotels);
        }

        // GET: api/Hotels/{id}
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Hotel>> GetHotel(int id)
        {
            var hotel = await _context.Hotels.Include(h => h.Country).FirstOrDefaultAsync(h => h.Id == id);

            if (hotel == null)
            {
                return NotFound();
            }

            return Ok(hotel);
        }

        // POST: api/Hotels
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Hotel>> CreateHotel([FromBody] Hotel hotel)
        {
            if (hotel == null || !ModelState.IsValid)
            {
                return BadRequest();
            }

            await _context.Hotels.AddAsync(hotel);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetHotel), new { id = hotel.Id }, hotel);
        }

        // PUT: api/Hotels/{id}
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateHotel(int id, [FromBody] Hotel hotel)
        {
            if (hotel == null || hotel.Id != id || !ModelState.IsValid)
            {
                return BadRequest();
            }

            var existingHotel = await _context.Hotels.FindAsync(id);
            if (existingHotel == null)
            {
                return NotFound();
            }

            _context.Entry(existingHotel).CurrentValues.SetValues(hotel);
            await _context.SaveChangesAsync();

            return Ok(existingHotel);
        }

        // DELETE: api/Hotels/{id}
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            var hotel = await _context.Hotels.FindAsync(id);
            if (hotel == null)
            {
                return NotFound();
            }

            _context.Hotels.Remove(hotel);
            await _context.SaveChangesAsync();

            return Ok(hotel);
        }
    }
}