using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace new_app.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExampleApiController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<string>> GetExamples()
        {
            var examples = new List<string> { "Example1", "Example2", "Example3" };
            return Ok(examples);
        }

        [HttpGet("{id}")]
        public ActionResult<string> GetExampleById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid ID.");
            }

            return Ok($"Example{id}");
        }

        [HttpPost]
        public ActionResult CreateExample([FromBody] string example)
        {
            if (string.IsNullOrWhiteSpace(example))
            {
                return BadRequest("Example cannot be empty.");
            }

            return CreatedAtAction(nameof(GetExampleById), new { id = 1 }, example);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateExample(int id, [FromBody] string updatedExample)
        {
            if (id <= 0 || string.IsNullOrWhiteSpace(updatedExample))
            {
                return BadRequest("Invalid data.");
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteExample(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid ID.");
            }

            return NoContent();
        }
    }
}