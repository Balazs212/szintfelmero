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
    public class szakmasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public szakmasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/szakmas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<szakma>>> GetSzakmak()
        {
            return await _context.Szakmak.ToListAsync();
        }

        // GET: api/szakmas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<szakma>> Getszakma(int id)
        {
            var szakma = await _context.Szakmak.FindAsync(id);

            if (szakma == null)
            {
                return NotFound();
            }

            return szakma;
        }

        // PUT: api/szakmas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putszakma(int id, szakma szakma)
        {
            if (id != szakma.szakmaId)
            {
                return BadRequest();
            }

            _context.Entry(szakma).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!szakmaExists(id))
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

        // POST: api/szakmas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<szakma>> Postszakma(szakma szakma)
        {
            _context.Szakmak.Add(szakma);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getszakma", new { id = szakma.szakmaId }, szakma);
        }

        // DELETE: api/szakmas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteszakma(int id)
        {
            var szakma = await _context.Szakmak.FindAsync(id);
            if (szakma == null)
            {
                return NotFound();
            }

            _context.Szakmak.Remove(szakma);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool szakmaExists(int id)
        {
            return _context.Szakmak.Any(e => e.szakmaId == id);
        }
    }
}
