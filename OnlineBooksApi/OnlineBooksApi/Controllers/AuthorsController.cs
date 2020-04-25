using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using OnlineBooksApi.Data;
using OnlineBooksApi.Models;

namespace OnlineBooksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly LibraryContext _context;

        public AuthorsController(LibraryContext context)
        {
            _context = context;
        }

        // GET: api/Authors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Author>>> GetAuthors()
        {
            //return await _context.Authors.ToListAsync();

            return await _context.Authors
                                        .Include(x => x.Books)
                                            .ThenInclude(x => x.Categories)
                                                .ThenInclude(x => x.Category)
                                        .Include(x => x.Books)
                                            .ThenInclude(x => x.Subcategories)
                                                .ThenInclude(x => x.Subcategory)
                                        .Include(x => x.Books)
                                            .ThenInclude(x => x.Shelves)
                                                .ThenInclude(x => x.Shelf)
                                        .Include(x => x.Categories)
                                            .ThenInclude(x => x.Category)
                                        .Include(x => x.Subcategories)
                                            .ThenInclude(x => x.Subcategory)
                                        .Include(x => x.Shelves)
                                            .ThenInclude(x => x.Shelf)
                                        .AsNoTracking()
                                        .ToListAsync();
        }

        // GET: api/Authors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> GetAuthor(int id)
        {
            var author = await _context.Authors
                                        .Include(x => x.Books)
                                            .ThenInclude(x => x.Categories)
                                                .ThenInclude(x => x.Category)
                                        .Include(x => x.Books)
                                            .ThenInclude(x => x.Subcategories)
                                                .ThenInclude(x => x.Subcategory)
                                        .Include(x => x.Books)
                                            .ThenInclude(x => x.Shelves)
                                                .ThenInclude(x => x.Shelf)
                                        .Include(x => x.Categories)
                                            .ThenInclude(x => x.Category)
                                        .Include(x => x.Subcategories)
                                            .ThenInclude(x => x.Subcategory)
                                        .Include(x => x.Shelves)
                                            .ThenInclude(x => x.Shelf)
                                        .AsNoTracking()
                                        .FirstOrDefaultAsync(x => x.Id == id);

            if (author == null)
            {
                return NotFound();
            }

            return author;
        }

        // PUT: api/Authors/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuthor(int id, Author author)
        {
            if (id != author.Id)
            {
                return BadRequest();
            }

            _context.Entry(author).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthorExists(id))
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

        // POST: api/Authors
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Author>> PostAuthor(Author author)
        {
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAuthor", new { id = author.Id }, author);
        }

        // DELETE: api/Authors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Author>> DeleteAuthor(int id)
        {
            var author = await _context.Authors.FindAsync(id);
            if (author == null)
            {
                return NotFound();
            }

            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();

            return author;
        }

        private bool AuthorExists(int id)
        {
            return _context.Authors.Any(e => e.Id == id);
        }
    }
}
