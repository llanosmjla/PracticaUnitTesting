using Microsoft.AspNetCore.Mvc;

namespace StudentControl.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        // Dummy in-memory list for demonstration
        private static readonly List<string> Students = new List<string>
        {
            "Alice",
            "Bob",
            "Charlie"
        };

        [HttpGet]
        public ActionResult<IEnumerable<string>> GetAll()
        {
            return Ok(Students);
        }

        [HttpGet("{id}")]
        public ActionResult<string> GetById(int id)
        {
            if (id < 0 || id >= Students.Count)
                return NotFound();

            return Ok(Students[id]);
        }

        [HttpPost]
        public ActionResult Add([FromBody] string name)
        {
            Students.Add(name);
            return CreatedAtAction(nameof(GetById), new { id = Students.Count - 1 }, name);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] string name)
        {
            if (id < 0 || id >= Students.Count)
                return NotFound();

            Students[id] = name;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (id < 0 || id >= Students.Count)
                return NotFound();

            Students.RemoveAt(id);
            return NoContent();
        }
    }
}