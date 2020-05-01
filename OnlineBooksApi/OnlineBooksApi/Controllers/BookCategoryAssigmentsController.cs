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
using OnlineBooksApi.Models.DTO.BookCategoryAssigment;

namespace OnlineBooksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookCategoryAssigmentsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger<BookCategoryAssigmentsController> _logger;
        private readonly LibraryContext _context;

        public BookCategoryAssigmentsController(IMapper mapper, ILogger<BookCategoryAssigmentsController> logger, LibraryContext context)
        {
            _mapper = mapper;
            _logger = logger;
            _context = context;
        }

        // GET: api/BookCategoryAssigments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookCategoryAssigmentDTO>>> GetBookCategoryAssigments()
        {
            try
            {
                var bookCategoryAssigments = await LoadBookCategoryAssigmentsAsync();

                var bookCategoryAssigmentsDTO = _mapper.Map<IEnumerable<BookCategoryAssigmentDTO>>(bookCategoryAssigments);

                return Ok(bookCategoryAssigmentsDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Methode GetBookCategoryAssigments was throw exception");
                return BadRequest();
            }
        }

        // GET: api/BookCategoryAssigments/5&5
        [HttpGet("{bookId}&{categoryId}")]
        public async Task<ActionResult<BookCategoryAssigmentDTO>> GetBookCategoryAssigment(int bookId, int categoryId)
        {
            try
            {
                var bookCategoryAssigment = await LoadBookCategoryAssigmentAsync(bookId, categoryId);

                var bookCategoryAssigmentDTO = _mapper.Map<BookCategoryAssigmentDTO>(bookCategoryAssigment);

                return Ok(bookCategoryAssigmentDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Methode GetBookCategoryAssigment was throw exception");
                return BadRequest();
            }
        }

        // POST: api/BookCategoryAssigments
        [HttpPost]
        public async Task<ActionResult<BookCategoryAssigmentDTO>> PostBookCategoryAssigment(POSTBookCategoryAssigmentDTO pOSTBookCategoryAssigmentDTO)
        {
            try
            {
                var bookCategoryAssigment = await LoadBookCategoryAssigmentAsync(pOSTBookCategoryAssigmentDTO.BookId, pOSTBookCategoryAssigmentDTO.CategoryId);

                if (bookCategoryAssigment != null)
                {
                    return BadRequest("This BookCategoryAssigment has been existed already");
                }

                var book = await _context.Authors.FindAsync(pOSTBookCategoryAssigmentDTO.BookId);

                if (book == null)
                {
                    return NotFound();
                }

                var category = await _context.Categories.FindAsync(pOSTBookCategoryAssigmentDTO.CategoryId);

                if (category == null)
                {
                    return NotFound();
                }

                bookCategoryAssigment = new BookCategoryAssigment { BookId = pOSTBookCategoryAssigmentDTO.BookId, CategoryId = pOSTBookCategoryAssigmentDTO.CategoryId };

                _context.BookCategoryAssigments.Add(bookCategoryAssigment);
                await _context.SaveChangesAsync();

                bookCategoryAssigment = await LoadBookCategoryAssigmentAsync(pOSTBookCategoryAssigmentDTO.BookId, pOSTBookCategoryAssigmentDTO.CategoryId);

                var bookCategoryAssigmentDTO = _mapper.Map<BookCategoryAssigmentDTO>(bookCategoryAssigment);

                return CreatedAtAction("GetBookCategoryAssigment", new { pOSTBookCategoryAssigmentDTO.BookId, pOSTBookCategoryAssigmentDTO.CategoryId }, bookCategoryAssigmentDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Methode PostBookCategoryAssigment was throw exception");
                return BadRequest();
            }
        }

        // DELETE: api/BookCategoryAssigments/5&5
        [HttpDelete("{bookId}&{categoryId}")]
        public async Task<ActionResult<BookCategoryAssigmentDTO>> DeleteBookCategoryAssigment(int bookId, int categoryId)
        {
            try
            {
                var bookCategoryAssigment = await LoadBookCategoryAssigmentAsync(bookId, categoryId);

                if (bookCategoryAssigment == null)
                {
                    return NotFound();
                }

                _context.BookCategoryAssigments.Remove(bookCategoryAssigment);
                await _context.SaveChangesAsync();

                var bookCategoryAssigmentDTO = _mapper.Map<BookCategoryAssigmentDTO>(bookCategoryAssigment);

                return Ok(bookCategoryAssigmentDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Methode DeleteBookCategoryAssigment was throw exception");
                return BadRequest();
            }
        }

        private async Task<IEnumerable<BookCategoryAssigment>> LoadBookCategoryAssigmentsAsync()
        {
            return await _context.BookCategoryAssigments
                                         .Include(x => x.Book)
                                         .Include(x => x.Category)
                                         .AsNoTracking()
                                         .ToListAsync();
        }

        private async Task<BookCategoryAssigment> LoadBookCategoryAssigmentAsync(int bookId, int categoryId)
        {
            return await _context.BookCategoryAssigments
                                        .Include(x => x.Book)
                                        .Include(x => x.Category)
                                        .AsNoTracking()
                                        .FirstOrDefaultAsync(x => x.BookId == bookId && x.CategoryId == categoryId);
        }
    }
}
