using MeisterLuisLB_295_TODO.Model;

using Microsoft.AspNetCore.Mvc;

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

        private static TODO GetTODO(TODO todo)
        {
            return new TODO
            {
                Id = todo.Id,
                Name = todo.Name,
                Content = todo.Content
            };
        }
    }
}
