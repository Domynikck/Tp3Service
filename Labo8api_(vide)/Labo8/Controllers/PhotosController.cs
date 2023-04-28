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
    public class PhotosController : ControllerBase
    {
        private readonly Labo8Context _context;

        public PhotosController(Labo8Context context)
        {
            _context = context;
        }

        // GET: api/Photos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Photo>>> GetPhoto()
        {
          if (_context.Photo == null)
          {
              return NotFound();
          }
            return await _context.Photo.ToListAsync();
        }

        // GET: api/Photos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Photo>> GetPhoto(int id)
        {
          if (_context.Photo == null)
          {
              return NotFound();
          }
            var photo = await _context.Photo.FindAsync(id);

            if (photo == null)
            {
                return NotFound();
            }

            return photo;
        }

        // PUT: api/Photos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPhoto(int id, Photo photo)
        {
            if (id != photo.Id)
            {
                return BadRequest();
            }

            _context.Entry(photo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhotoExists(id))
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

        // POST: api/Photos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{id}")]
        [DisableRequestSizeLimit]
        public async Task<ActionResult<Photo>> PostPhoto(Photo photo)
        {
          //if (_context.Photo == null)
          //{
          //    return Problem("Entity set 'Labo8Context.Photo'  is null.");
          //}
          //  _context.Photo.Add(photo);
          //  await _context.SaveChangesAsync();

          //  return CreatedAtAction("GetPhoto", new { id = photo.Id }, photo);

            try
            {
                IFormCollection formCollection = await Request.ReadFormAsync();
                IFormFile? file = formCollection.Files.GetFile("monImage");
                if(file != null)
                {
                    Image image = Image.Load(file.OpenReadStream());

                    photo.FileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    photo.MimeType = file.ContentType;

                    image.Save(Directory.GetCurrentDirectory() + "/images/original/" + photo.FileName);

                    _context.Entry(photo).State = EntityState.Modified;
                    await _context.SaveChangesAsync();

                } else
                {
                    return NotFound(new { Message = "Aucune image fournie" });
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        // DELETE: api/Photos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePhoto(int id)
        {
            if (_context.Photo == null)
            {
                return NotFound();
            }
            var photo = await _context.Photo.FindAsync(id);
            if (photo == null)
            {
                return NotFound();
            }

            _context.Photo.Remove(photo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PhotoExists(int id)
        {
            return (_context.Photo?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
