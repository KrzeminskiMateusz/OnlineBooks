using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OnlineBooksApi.Data;
using OnlineBooksApi.Models;
using OnlineBooksApi.Models.DTO.Book;

namespace OnlineBooksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger<BooksController> _logger;
        private readonly LibraryContext _context;

        public BooksController(IMapper mapper, ILogger<BooksController> logger, LibraryContext context)
        {
            _mapper = mapper;
            _logger = logger;
            _context = context;
        }

        // GET: api/Books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDTO>>> GetBooks()
        {
            try
            {
                var books = await LoadBooksAsync();

                if (books == null)
                {
                    return NotFound();
                }

                var booksDTO = _mapper.Map<IEnumerable<BookDTO>>(books);

                return Ok(booksDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Methode GetBooks was throw exception");
                return BadRequest();
            }
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookDTO>> GetBook(int id)
        {          
            try
            {
                var book = await LoadBookAsync(id);

                if (book == null)
                {
                    return NotFound();
                }

                var bookDTO = _mapper.Map<BookDTO>(book);

                return Ok(bookDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Methode GetBook was throw exception");
                return BadRequest();
            }
        }

        // PUT: api/Books/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, BookDTO bookDTO)
        {
            try
            {
                var book = await _context.Books.FindAsync(id);

                if (book == null)
                {
                    return NotFound();
                }

                _mapper.Map<BookDTO, Book>(bookDTO, book);

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException) when (!BookExists(id))
                {
                    return NotFound();
                }

                book = await LoadBookAsync(id);

                bookDTO = _mapper.Map<BookDTO>(book);

                return Ok(bookDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Methode PutBook was throw exception");
                return BadRequest();
            }
        }

        // POST: api/Books
        [HttpPost]
        public async Task<ActionResult<BookDTO>> PostBook(BookDTO bookDTO)
        {
            try
            {
                var book = _mapper.Map<Book>(bookDTO);

                _context.Books.Add(book);
                await _context.SaveChangesAsync();

                book = await LoadBookAsync(book.Id);

                bookDTO = _mapper.Map<BookDTO>(book);

                return CreatedAtAction("GetBook", new { id = book.Id }, bookDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Methode PostBook was throw exception");
                return BadRequest();
            }
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BookDTO>> DeleteBook(int id)
        {
            try
            {
                var book = await _context.Books.FindAsync(id);

                if (book == null)
                {
                    return NotFound();
                }

                _context.Books.Remove(book);
                await _context.SaveChangesAsync();

                var bookDTO = _mapper.Map<BookDTO>(book);

                return Ok(bookDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Methode DeleteBook was throw exception");
                return BadRequest();
            }
        }

        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.Id == id);
        }

        private async Task<IEnumerable<Book>> LoadBooksAsync()
        {
            return await _context.Books
                                       .Include(x => x.Author)
                                                .ThenInclude(x => x.Categories)
                                                    .ThenInclude(x => x.Category)
                                       .Include(x => x.Author)
                                            .ThenInclude(x => x.Subcategories)
                                                .ThenInclude(x => x.Subcategory)
                                       .Include(x => x.Author)
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

        private async Task<Book> LoadBookAsync(int id)
        {
            return await _context.Books
                                       .Include(x => x.Author)
                                            .ThenInclude(x => x.Categories)
                                                .ThenInclude(x => x.Category)
                                       .Include(x => x.Author)
                                            .ThenInclude(x => x.Subcategories)
                                                .ThenInclude(x => x.Subcategory)
                                       .Include(x => x.Author)
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
