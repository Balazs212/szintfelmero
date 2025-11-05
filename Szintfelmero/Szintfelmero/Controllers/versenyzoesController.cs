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
    public class versenyzoesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public versenyzoesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/versenyzoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<versenyzo>>> GetVersenyzok()
        {
            return await _context.Versenyzok.ToListAsync();
        }

        // GET: api/versenyzoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<versenyzo>> Getversenyzo(int id)
        {
            var versenyzo = await _context.Versenyzok.FindAsync(id);

            if (versenyzo == null)
            {
                return NotFound();
            }

            return versenyzo;
        }

        // PUT: api/versenyzoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putversenyzo(int id, versenyzo versenyzo)
        {
            if (id != versenyzo.id)
            {
                return BadRequest();
            }

            _context.Entry(versenyzo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!versenyzoExists(id))
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

        // POST: api/versenyzoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<versenyzo>> Postversenyzo(versenyzo versenyzo)
        {
            _context.Versenyzok.Add(versenyzo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getversenyzo", new { id = versenyzo.id }, versenyzo);
        }

        // DELETE: api/versenyzoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteversenyzo(int id)
        {
            var versenyzo = await _context.Versenyzok.FindAsync(id);
            if (versenyzo == null)
            {
                return NotFound();
            }

            _context.Versenyzok.Remove(versenyzo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool versenyzoExists(int id)
        {
            return _context.Versenyzok.Any(e => e.id == id);
        }
    }
}
