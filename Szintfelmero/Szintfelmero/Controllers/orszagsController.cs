using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Szintfelmero.Data;
using Szintfelmero.Models;

namespace Szintfelmero.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class orszagsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public orszagsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/orszags
        [HttpGet]
        public async Task<ActionResult<IEnumerable<orszag>>> GetOrszagok()
        {
            return await _context.Orszagok.ToListAsync();
        }

        // GET: api/orszags/5
        [HttpGet("{id}")]
        public async Task<ActionResult<orszag>> Getorszag(int id)
        {
            var orszag = await _context.Orszagok.FindAsync(id);

            if (orszag == null)
            {
                return NotFound();
            }

            return orszag;
        }

        // PUT: api/orszags/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putorszag(int id, orszag orszag)
        {
            if (id != orszag.orszagId)
            {
                return BadRequest();
            }

            _context.Entry(orszag).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!orszagExists(id))
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

        // POST: api/orszags
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<orszag>> Postorszag(orszag orszag)
        {
            _context.Orszagok.Add(orszag);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getorszag", new { id = orszag.orszagId }, orszag);
        }

        // DELETE: api/orszags/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteorszag(int id)
        {
            var orszag = await _context.Orszagok.FindAsync(id);
            if (orszag == null)
            {
                return NotFound();
            }

            _context.Orszagok.Remove(orszag);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool orszagExists(int id)
        {
            return _context.Orszagok.Any(e => e.orszagId == id);
        }
    }
}
