﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Labo8.Data;
using Labo8.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace Labo8.Controllers
{
    [Authorize]
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
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            User? user = await _context.Users.FindAsync(userId);
            List<Gallerie> galleries = await _context.Gallerie.ToListAsync();
            List<Gallerie> galleriesAEnlever = new List<Gallerie>();
            foreach (var item in galleries)
            {
                if (item.Users.Contains(user) || item.Publique == false)
                {
                    galleriesAEnlever.Add(item);
                }
            }

            foreach (var item in galleriesAEnlever)
            {
                galleries.Remove(item);
            }

            return galleries;
        }
        




        // GET: api/MyGalleries
        [HttpGet("MyGalleries")]
        public async Task<ActionResult<IEnumerable<Gallerie>>> GetMyGalleries()
        {
            if (_context.Gallerie == null)
            {
                return NotFound();
            }
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            User? user = await _context.Users.FindAsync(userId);

            if (user != null)
            {
                return user.Galleries;
            }


            return StatusCode(StatusCodes.Status400BadRequest, new { Message = "Utilisateur non toruvé" });
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



        // GET: api/Galleries/5
        [HttpPut("PartageGalerie/{id}/{nomUser}")]
        public async Task<ActionResult> PartageMyGallerie(int id, string nomUser)
        {
           
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            User? user = await _context.Users.FindAsync(userId);

            User userPartage = _context.Users.FirstOrDefault(u => u.NormalizedUserName == nomUser.ToUpper());

            Gallerie gallerie1 = await _context.Gallerie.FindAsync(id);

            if (gallerie1.Users.Contains(userPartage))
            {
                return StatusCode(StatusCodes.Status400BadRequest, new { Message = "Utilisateur Déja ajouté" });
            }

            gallerie1.Users.Add(userPartage);


            await _context.SaveChangesAsync();

            if (user != null)
            {
                return NoContent();
            }


            return StatusCode(StatusCodes.Status400BadRequest, new { Message = "Utilisateur non toruvé" });
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

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            User? user = await _context.Users.FindAsync(userId);

            Gallerie gallerie1 = await _context.Gallerie.FindAsync(id);

            if (!gallerie1.Users.Any(u => u.Id == userId)) // Vérifie si la gallerie contient l'user courant
            {
                return Forbid(); 
            }

            gallerie1.Publique = gallerie.Publique;


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
            string userID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            User? user = await _context.Users.FindAsync(userID);
            if (user != null)
            {
                List<User> users = new List<User>();
                users.Add(user);
                gallerie.Users = users;


                List<Gallerie> galleries = new List<Gallerie>();
                galleries.Add(gallerie);
                user.Galleries = galleries;

                _context.Gallerie.Add(gallerie);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetGallerie", new { id = gallerie.Id }, gallerie);
            }






            return StatusCode(StatusCodes.Status400BadRequest, new { Message = "Utilisateur non trouvé." });
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

            string userID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            User? user = await _context.Users.FindAsync(userID);

            if (!gallerie.Users.Contains(user))
            {
                return Forbid();
            }
            foreach (Photo photo in gallerie.Photos)
            {
                System.IO.File.Delete(Directory.GetCurrentDirectory() + "/images/miniature/" + photo.FileName);
                System.IO.File.Delete(Directory.GetCurrentDirectory() + "/images/original/" + photo.FileName);
                _context.Photo.Remove(photo);
              
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
