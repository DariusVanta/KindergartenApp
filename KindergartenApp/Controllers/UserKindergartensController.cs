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
    public class UserKindergartensController : ControllerBase
    {
        private readonly KindergartensDbContext _context;

        public UserKindergartensController(KindergartensDbContext context)
        {
            _context = context;
        }

        // GET: api/UserKindergartens
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserKindergarten>>> GetUserKindergartens()
        {
            return await _context.UserKindergartens.ToListAsync();
        }

        // GET: api/UserKindergartens/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserKindergarten>> GetUserKindergarten(long id)
        {
            var userKindergarten = await _context.UserKindergartens.FindAsync(id);

            if (userKindergarten == null)
            {
                return NotFound();
            }

            return userKindergarten;
        }

        // PUT: api/UserKindergartens/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserKindergarten(long id, UserKindergarten userKindergarten)
        {
            if (id != userKindergarten.UserId)
            {
                return BadRequest();
            }

            _context.Entry(userKindergarten).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserKindergartenExists(id))
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

        // POST: api/UserKindergartens
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<UserKindergarten>> PostUserKindergarten(UserKindergarten userKindergarten)
        {
            _context.UserKindergartens.Add(userKindergarten);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserKindergartenExists(userKindergarten.UserId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUserKindergarten", new { id = userKindergarten.UserId }, userKindergarten);
        }

        // DELETE: api/UserKindergartens/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserKindergarten>> DeleteUserKindergarten(long id)
        {
            var userKindergarten = await _context.UserKindergartens.FindAsync(id);
            if (userKindergarten == null)
            {
                return NotFound();
            }

            _context.UserKindergartens.Remove(userKindergarten);
            await _context.SaveChangesAsync();

            return userKindergarten;
        }

        private bool UserKindergartenExists(long id)
        {
            return _context.UserKindergartens.Any(e => e.UserId == id);
        }
    }
}
