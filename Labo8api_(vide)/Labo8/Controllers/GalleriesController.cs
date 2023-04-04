using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Labo8.Data;
using Labo8.Models;

namespace Labo8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GalleriesController : ControllerBase
    {
        private readonly Labo8Context _context;

        public GalleriesController(Labo8Context context)
        {
            _context = context;
        }

        // GET: api/Galleries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Gallerie>>> GetGallerie()
        {
          if (_context.Gallerie == null)
          {
              return NotFound();
          }
            return await _context.Gallerie.ToListAsync();
        }

        // GET: api/Galleries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Gallerie>> GetGallerie(int id)
        {
          if (_context.Gallerie == null)
          {
              return NotFound();
          }
            var gallerie = await _context.Gallerie.FindAsync(id);

            if (gallerie == null)
            {
                return NotFound();
            }

            return gallerie;
        }

        // PUT: api/Galleries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGallerie(int id, Gallerie gallerie)
        {
            if (id != gallerie.Id)
            {
                return BadRequest();
            }

            _context.Entry(gallerie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GallerieExists(id))
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

        // POST: api/Galleries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Gallerie>> PostGallerie(Gallerie gallerie)
        {
          if (_context.Gallerie == null)
          {
              return Problem("Entity set 'Labo8Context.Gallerie'  is null.");
          }
            _context.Gallerie.Add(gallerie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGallerie", new { id = gallerie.Id }, gallerie);
        }

        // DELETE: api/Galleries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGallerie(int id)
        {
            if (_context.Gallerie == null)
            {
                return NotFound();
            }
            var gallerie = await _context.Gallerie.FindAsync(id);
            if (gallerie == null)
            {
                return NotFound();
            }

            _context.Gallerie.Remove(gallerie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GallerieExists(int id)
        {
            return (_context.Gallerie?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
