using MeisterLuisLB_295_TODO.Model;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MeisterLuisLB_295_TODO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TODOController : ControllerBase
    {
        private readonly TODODB _context;

        public TODOController(TODODB context)
        {
            _context = context;
        }

        // GET: api/TODO
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TODODTO>>> GetTODO()
        {
            var todos = await _context.TODOs.ToListAsync();
            var todoDTOs = todos.Select(todo => TODOToTODODTO(todo)).ToList();

            return todoDTOs;
        }

        // GET: api/TODO/
        [HttpGet("{id}")]
        public async Task<ActionResult<TODODTO>> GetTODO(int id)
        {
            var todo = await _context.TODOs.FindAsync(id);

            if (todo == null)
            {
                return NotFound();
            }

            return TODOToTODODTO(todo);
        }

        // POST: api/TODO
        [HttpPost]
        public async Task<ActionResult<TODODTO>> PostTODO(TODODTO todoDTO)
        {
            var todo = new TODO
            {
                Name = todoDTO.Name,
                Content = todoDTO.Content
            };

            _context.TODOs.Add(todo);
            await _context.SaveChangesAsync();

            todoDTO.Id = todo.Id;
            return CreatedAtAction(nameof(PostTODO), new { id = todo.Id }, todoDTO);
        }

        private static TODODTO TODOToTODODTO(TODO todo)
        {
            return new TODODTO
            {
                Id = todo.Id,
                Name = todo.Name,
                Content = todo.Content
            };
        }

        // PUT: api/TODO/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTODO(int id, TODODTO todoDTO)
        {
            if (id != todoDTO.Id)
            {
                return BadRequest();
            }

            var todo = await _context.TODOs.FindAsync(id);
            if (todo == null)
            {
                return NotFound();
            }

            todo.Name = todoDTO.Name;
            todo.Content = todoDTO.Content;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool TodoExists(int id)
        {
            return _context.TODOs.Any(e => e.Id == id);
        }

        // DELETE: api/TODO/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTODO(int id)
        {
            var todo = await _context.TODOs.FindAsync(id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.TODOs.Remove(todo);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
