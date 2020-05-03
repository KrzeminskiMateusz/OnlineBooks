using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<AuthorsController> _logger;
        private readonly LibraryContext _context;

        public AuthorsController(IMapper mapper, ILogger<AuthorsController> logger, LibraryContext context)
        {
            _mapper = mapper;
            _context = context;
            _logger = logger;
        }

        // GET: api/Authors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorDTO>>> GetAuthors()
        {
            try
            {
                var authors = await LoadAuthorsAsync();

                if (authors == null)
                {
                    return NotFound();
                }

                var authorsDTO = _mapper.Map<IEnumerable<AuthorDTO>>(authors);

                return Ok(authorsDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Methode GetAuthors was throw exception");
                return BadRequest();
            }
        }

        // GET: api/Authors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorDTO>> GetAuthor(int id)
        {
            try
            {
                var author = await LoadAuthorAsync(id);

                if (author == null)
                {
                    return NotFound();
                }

                var authorDTO = _mapper.Map<AuthorDTO>(author);

                return Ok(authorDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Methode GetAuthor was throw exception");
                return BadRequest();
            }
        }

        // PUT: api/Authors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuthor(int id, AuthorDTO authorDTO)
        {
            try
            {
                var author = await _context.Authors.FindAsync(id);

                if (author == null)
                {
                    return NotFound();
                }

                var authors = await _context.Authors.ToListAsync();

                if (authorDTO.LastName != null && authors.Any(x => x.LastName == authorDTO.LastName && x.Id != id))
                {
                    return BadRequest();
                }

                _mapper.Map<AuthorDTO, Author>(authorDTO, author);

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException) when (!AuthorExists(id))
                {
                    return NotFound();
                }

                author = await LoadAuthorAsync(id);

                authorDTO = _mapper.Map<AuthorDTO>(author);

                return Ok(authorDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Methode PutAuthor was throw exception");
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<ActionResult<AuthorDTO>> PostAuthor(AuthorDTO authorDTO)
        {
            try
            {
                var authors = await _context.Authors.ToListAsync();

                if (authors.Any(x => x.LastName == authorDTO.LastName) && authorDTO.LastName != null)
                {
                    return BadRequest("This author has been existed already");
                }

                var author = _mapper.Map<Author>(authorDTO);

                _context.Authors.Add(author);
                await _context.SaveChangesAsync();

                author = await LoadAuthorAsync(author.Id);

                authorDTO = _mapper.Map<AuthorDTO>(author);

                return CreatedAtAction("GetAuthor", new { id = author.Id }, authorDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Methode PostAuthor was throw exception");
                return BadRequest();
            }
        }

        // DELETE: api/Authors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AuthorDTO>> DeleteAuthor(int id)
        {
            try
            {
                var author = await _context.Authors.FindAsync(id);

                if (author == null)
                {
                    return NotFound();
                }

                _context.Authors.Remove(author);
                await _context.SaveChangesAsync();

                var authorDTO = _mapper.Map<AuthorDTO>(author);

                return Ok(authorDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Methode DeleteAuthor was throw exception");
                return BadRequest();
            }
        }

        private bool AuthorExists(int id)
        {
            return _context.Authors.Any(e => e.Id == id);
        }

        private async Task<IEnumerable<Author>> LoadAuthorsAsync()
        {
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

        private async Task<Author> LoadAuthorAsync(int id)
        {
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
                                        .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
