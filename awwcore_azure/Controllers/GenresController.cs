﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using awwcore_azure.Database.Entities;
using awwcore_azure.Database.Interface;

namespace awwcore_azure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly GameReviewsContext _context;

        public GenresController(GameReviewsContext context)
        {
            _context = context;
        }

        // GET: api/Genres
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Genre>>> GetGenres()
        {
            return await _context.Genres.ToListAsync();
        }

        // GET: api/Genres/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Genre>> GetGenre(int id)
        {
            var genre = await _context.Genres.FindAsync(id);

            if (genre == null)
            {
                return NotFound();
            }

            return genre;
        }

        // PUT: api/Genres/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGenre(int id, Genre genre)
        {
            if (id != genre.ID)
            {
                return BadRequest();
            }

            _context.Entry(genre).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GenreExists(id))
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

        // POST: api/Genres
        [HttpPost]
        public async Task<ActionResult<Genre>> PostGenre(Genre genre)
        {
            if (genre.ID < 0 || _context.Genres.Any(g => g.ID == genre.ID))
                return BadRequest();

            _context.Genres.Add(genre);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGenre", new { id = genre.ID }, genre);
        }

        // DELETE: api/Genres/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Genre>> DeleteGenre(int id)
        {
            var genre = await _context.Genres.FindAsync(id);
            if (genre == null)
            {
                return NotFound();
            }

            _context.Genres.Remove(genre);
            await _context.SaveChangesAsync();

            return genre;
        }

        private bool GenreExists(int id)
        {
            return _context.Genres.Any(e => e.ID == id);
        }
    }
}
