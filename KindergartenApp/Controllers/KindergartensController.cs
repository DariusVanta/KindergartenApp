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
    public class KindergartensController : ControllerBase
    {
        private readonly KindergartensDbContext _context;

        public KindergartensController(KindergartensDbContext context)
        {
            _context = context;
        }

        // GET: api/Kindergartens
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Kindergarten>>> GetKindergartens()
        {
            return await _context.Kindergartens.ToListAsync();
        }

        // GET: api/Kindergartens/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Kindergarten>> GetKindergarten(long id)
        {
            var kindergarten = await _context.Kindergartens.FindAsync(id);

            if (kindergarten == null)
            {
                return NotFound();
            }

            return kindergarten;
        }

        // PUT: api/Kindergartens/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKindergarten(long id, Kindergarten kindergarten)
        {
            if (id != kindergarten.KindergartenId)
            {
                return BadRequest();
            }

            _context.Entry(kindergarten).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KindergartenExists(id))
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

        // POST: api/Kindergartens
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Kindergarten>> PostKindergarten(Kindergarten kindergarten)
        {
            _context.Kindergartens.Add(kindergarten);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKindergarten", new { id = kindergarten.KindergartenId }, kindergarten);
        }

        // DELETE: api/Kindergartens/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Kindergarten>> DeleteKindergarten(long id)
        {
            var kindergarten = await _context.Kindergartens.FindAsync(id);
            if (kindergarten == null)
            {
                return NotFound();
            }

            _context.Kindergartens.Remove(kindergarten);
            await _context.SaveChangesAsync();

            return kindergarten;
        }

        private bool KindergartenExists(long id)
        {
            return _context.Kindergartens.Any(e => e.KindergartenId == id);
        }
    }
}
