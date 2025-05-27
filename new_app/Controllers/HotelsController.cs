using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using new_app.Data;
using new_app.Models;

namespace new_app.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HotelsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<HotelsController> _logger;

        public HotelsController(ApplicationDbContext context, ILogger<HotelsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: api/Hotels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hotel>>> GetHotels()
        {
            var hotels = await Task.FromResult(_context.Hotels.ToList());
            return Ok(hotels);
        }

        // GET: api/Hotels/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Hotel>> GetHotel(int id)
        {
            var hotel = await Task.FromResult(_context.Hotels.Find(id));
            if (hotel == null)
            {
                return NotFound();
            }

            return Ok(hotel);
        }

        // POST: api/Hotels
        [HttpPost]
        public async Task<ActionResult<Hotel>> AddHotel(Hotel hotel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Hotels.Add(hotel);
            await Task.FromResult(_context.SaveChanges());
            return CreatedAtAction(nameof(GetHotel), new { id = hotel.Id }, hotel);
        }

        // PUT: api/Hotels/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHotel(int id, Hotel hotel)
        {
            if (id != hotel.Id || !ModelState.IsValid)
            {
                return BadRequest();
            }

            var existingHotel = _context.Hotels.Find(id);
            if (existingHotel == null)
            {
                return NotFound();
            }

            existingHotel.Name = hotel.Name;
            existingHotel.City = hotel.City;
            existingHotel.Country = hotel.Country;
            existingHotel.Stars = hotel.Stars;
            existingHotel.Price = hotel.Price;

            await Task.FromResult(_context.SaveChanges());
            return NoContent();
        }

        // DELETE: api/Hotels/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            var hotel = _context.Hotels.Find(id);
            if (hotel == null)
            {
                return NotFound();
            }

            _context.Hotels.Remove(hotel);
            await Task.FromResult(_context.SaveChanges());
            return NoContent();
        }
    }
}