using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KindergartenApp.Models;

namespace KindergartenApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChildrenController : ControllerBase
    {
        private readonly ChildrenDbContext _context;

        public ChildrenController(ChildrenDbContext context)
        {
            _context = context;
        }

        // GET: api/Children
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Child>>> GetChildren()
        {
            return await _context.Children.ToListAsync();
        }

        // GET: api/Children/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Child>> GetChild(long id)
        {
            var child = await _context.Children.FindAsync(id);

            if (child == null)
            {
                return NotFound();
            }

            return child;
        }

        // PUT: api/Children/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChild(long id, Child child)
        {
            if (id != child.Id)
            {
                return BadRequest();
            }

            _context.Entry(child).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChildExists(id))
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

        // POST: api/Children
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Child>> PostChild(Child child)
        {
            _context.Children.Add(child);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChild", new { id = child.Id }, child);
        }

        // DELETE: api/Children/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Child>> DeleteChild(long id)
        {
            var child = await _context.Children.FindAsync(id);
            if (child == null)
            {
                return NotFound();
            }

            _context.Children.Remove(child);
            await _context.SaveChangesAsync();

            return child;
        }

        private bool ChildExists(long id)
        {
            return _context.Children.Any(e => e.Id == id);
        }
    }
}
