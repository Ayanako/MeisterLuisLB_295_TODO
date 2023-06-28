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
            if (_context.TODOs == null)
            {
                return NotFound();
            }

            var todos = await _context.TODOs.ToListAsync();
            var todoDTOs = todos.Select(todo => TODOToTODODTO(todo)).ToList();

            return todoDTOs;
        }

        // GET: api/TODO/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TODODTO>> GetTODO(int id)
        {
            if (_context.TODOs == null)
            {
                return NotFound();
            }
            var mitarbeiter = await _context.TODOs.FindAsync(id);

            if (mitarbeiter == null)
            {
                return NotFound();
            }

            return TODOToTODODTO(mitarbeiter);
        }

        // POST: api/TODO
        [HttpPost]
        public async Task<ActionResult<TODODTO>> PostTODO(TODODTO todoDTO)
        {
            if (_context.TODOs == null)
            {
                return Problem("Entity set 'TODODB.todo' is null.");
            }
            var todo = new TODO
            {
                Id = todoDTO.Id,
                Name = todoDTO.Name,
                Content = todoDTO.Content
            };
            _context.TODOs.Add(todo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("PostTODO", new { id = todo.Id }, todo);
        }

        private static TODODTO TODOToTODODTO(TODO todo)
        {
            return new TODODTO
            {
                Id = todo.Id,
                Name = todo.Name,
                Content = todo.Content,
            };
        }


    }
}
