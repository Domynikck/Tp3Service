using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Labo8.Data;
using Labo8.Models;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Authorization;

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
        [HttpGet("{size}/{id}")]
        public async Task<ActionResult<Photo>> GetPhoto(string size, int id )
        {
          if (_context.Photo == null)
          {
              return NotFound();
          }
            Photo? photo = await _context.Photo.FindAsync(id);
            if (photo == null || photo.FileName == null || photo.MimeType == null)
            {
                return NotFound(new { Message = "Cette photo n'existe pas" });
            }
            if (!(Regex.Match(size, "original|miniature").Success))
            {
                return BadRequest(new { Message = "La taille demandée est inadéquate" });
            }
            byte[] bytes = System.IO.File.ReadAllBytes(Directory.GetCurrentDirectory() + "/images/" + size + "/" + photo.FileName);
            return File(bytes, photo.MimeType);

        }
        // GET: api/AllPhotos
        [HttpGet("AllPhotos/{id}")]
        public async Task<ActionResult<IEnumerable<Photo>>> GetAllPhotos(int id)
        {
            if (_context.Gallerie == null)
            {
                return NotFound();
            }
            Gallerie gallerie = await _context.Gallerie.FindAsync(id);

            if (gallerie != null)
            {
                return gallerie.Photos;
            }


            return StatusCode(StatusCodes.Status400BadRequest, new { Message = "Utilisateur non toruvé" });
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
        public async Task<ActionResult<Photo>> PostPhoto(int id)
        {
            try
            {
  
                IFormCollection formCollection = await Request.ReadFormAsync();
                IFormFile? file = formCollection.Files.GetFile("monImage");
                if(file != null)
                {

                    Gallerie gallerie = await _context.Gallerie.FindAsync(id);

                    Photo photo = new Photo();
                    Image image = Image.Load(file.OpenReadStream());

                    photo.FileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    photo.MimeType = file.ContentType;
                    photo.Gallerie = gallerie;

                    gallerie.Photos.Add(photo);

                    image.Save(Directory.GetCurrentDirectory() + "/images/original/" + photo.FileName);
                    image.Mutate(i => i.Resize(new ResizeOptions()
                    {
                        Mode = ResizeMode.Min,
                        Size = new Size() { Width = 320 }
                    }));
                    image.Save(Directory.GetCurrentDirectory() + "/images/miniature/" + photo.FileName);

                     _context.Photo.Add(photo);
                    _context.Entry(gallerie).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return NoContent();
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
        [HttpPost("SetCover/{id}")]
        [DisableRequestSizeLimit]
        public async Task<ActionResult<Photo>> PostCover(int id)
        {
            try
            {

                IFormCollection formCollection = await Request.ReadFormAsync();
                IFormFile? file = formCollection.Files.GetFile("monCover");
                if (file != null)
                {

                    Gallerie gallerie = await _context.Gallerie.FindAsync(id);

                    Photo photo = new Photo();
                    Image image = Image.Load(file.OpenReadStream());

                    photo.FileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    photo.MimeType = file.ContentType;
                    

                 


                    image.Mutate(i => i.Resize(new ResizeOptions()
                    {
                        Mode = ResizeMode.Min,
                        Size = new Size() { Width = 320 }
                    }));
                    image.Save(Directory.GetCurrentDirectory() + "/images/miniature/" + photo.FileName);
 


                    _context.Photo.Add(photo);
                    await _context.SaveChangesAsync(); 

                    gallerie.CoverID = photo.Id;
                    _context.Entry(gallerie).State = EntityState.Modified;
                     _context.Update(gallerie);
                    await _context.SaveChangesAsync();
                    return NoContent();
                }
                else
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
            if (photo.MimeType != null && photo.FileName != null)
            {
                string test = Directory.GetCurrentDirectory() + "/images/miniature/" + photo.FileName;
                string test2 = Directory.GetCurrentDirectory() + "/images/original/" + photo.FileName;
                string woah = "";
                System.IO.File.Delete(Directory.GetCurrentDirectory() + "/images/miniature/" + photo.FileName);
                System.IO.File.Delete(Directory.GetCurrentDirectory() + "/images/original/" + photo.FileName);
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
