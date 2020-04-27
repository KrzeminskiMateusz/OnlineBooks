using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using OnlineBooksApi.Data;
using OnlineBooksApi.Models;
using OnlineBooksApi.Models.DTO;

namespace OnlineBooksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly LibraryContext _context;

        public AuthorsController(IMapper mapper, LibraryContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        // GET: api/Authors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorDTO>>> GetAuthors()
        {
            var authors =  await _context.Authors
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

            var authorsDTO = _mapper.Map<IEnumerable<AuthorDTO>>(authors);

            return CreatedAtAction("GetAuthors", authorsDTO);
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

        [HttpPost]
        public async Task<ActionResult<AuthorDTO>> PostAuthor(AuthorDTO authorDTO)
        {
            //_context.Authors.Add(author);
            //await _context.SaveChangesAsync();

            //return CreatedAtAction("GetAuthor", new { id = author.Id }, author);

            var newAuthor = new Author();

            if (await TryUpdateModelAsync<Author>(
                newAuthor,
                "",
                x => x.FirstName, x => x.LastName, x => x.Nationality, x => x.DataOfBirth, x => x.PlaceOfBirth, x => x.CountryOfBirth,
                x => x.DateOfDeath, x => x.PlaceOfDeath, x => x.CountryOfDeath, x => x.Description, x => x.Image, x => x.IsAlive))
            {
                _context.Authors.Add(newAuthor);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetAuthor", new { id = newAuthor.Id }, authorDTO);
            }

            return null;
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
