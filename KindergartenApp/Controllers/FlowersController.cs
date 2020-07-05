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
    public class FlowersController : ControllerBase
    {
        private readonly FlowersDbContext _context;

        public FlowersController(FlowersDbContext context)
        {
            _context = context;
        }

        // GET: api/Flowers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Flower>>> GetFlowers(DateTimeOffset? from = null, DateTimeOffset? to = null)
        {
            IQueryable<Flower> result = _context.Flowers;
            if (from != null && to != null)
            {
                result = result.Where(f => from <= f.DateAdded && f.DateAdded <= to);
            }
            else if (from != null)
            {
                result = result.Where(f => from <= f.DateAdded);
            }
            else if (to != null)
            {
                result = result.Where(f => f.DateAdded <= to);
            }
            return await result.ToListAsync();

            //return await _
            //    .Where(f => from <= f.DateAdded && f.DateAdded <= to)
            //    .ToListAsync();

            //return await _context.Flowers.ToListAsync();
        }

        // GET: api/Flowers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Flower>> GetFlower(long id)
        {
            var flower = await _context.Flowers.FindAsync(id);

            if (flower == null)
            {
                return NotFound();
            }

            return flower;
        }

        // PUT: api/Flowers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFlower(long id, Flower flower)
        {
            if (id != flower.Id)
            {
                return BadRequest();
            }

            _context.Entry(flower).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FlowerExists(id))
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

        // POST: api/Flowers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Flower>> PostFlower(Flower flower)
        {
            //if(!ModelState.IsValid)
            _context.Flowers.Add(flower);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFlower", new { id = flower.Id }, flower);
        }

        // DELETE: api/Flowers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Flower>> DeleteFlower(long id)
        {
            var flower = await _context.Flowers.FindAsync(id);
            if (flower == null)
            {
                return NotFound();
            }

            _context.Flowers.Remove(flower);
            await _context.SaveChangesAsync();

            return flower;
        }

        private bool FlowerExists(long id)
        {
            return _context.Flowers.Any(e => e.Id == id);
        }
    }
}
