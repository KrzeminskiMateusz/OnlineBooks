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
using OnlineBooksApi.Models.DTO.BookSubCategoryAssigment;

namespace OnlineBooksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookSubcategoryAssigmentsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger<BookSubcategoryAssigmentsController> _logger;
        private readonly LibraryContext _context;

        public BookSubcategoryAssigmentsController(IMapper mapper, ILogger<BookSubcategoryAssigmentsController> logger, LibraryContext context)
        {
            _mapper = mapper;
            _logger = logger;
            _context = context;
        }

        // GET: api/BookSubcategoryAssigments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookSubcategoryAssigmentDTO>>> GetBookSubcategoryAssigments()
        {
            try
            {
                var bookSubcategoryAssigments = await LoadBookSubcategoryAssigmentsAsync();

                var bookSubcategoryAssigmentsDTO = _mapper.Map<IEnumerable<BookSubcategoryAssigmentDTO>>(bookSubcategoryAssigments);

                return Ok(bookSubcategoryAssigmentsDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Methode GetBookSubcategoryAssigments was throw exception");
                return BadRequest();
            }
        }

        // GET: api/BookSubcategoryAssigments/5
        [HttpGet("{bookId}&{subcategoryId}")]
        public async Task<ActionResult<BookSubcategoryAssigmentDTO>> GetBookSubcategoryAssigment(int bookId, int subcategoryId)
        {
            try
            {
                var bookSubcategoryAssigment = await LoadBookSubcategoryAssigmentAsync(bookId, subcategoryId);

                var bookSubcategoryAssigmentDTO = _mapper.Map<BookSubcategoryAssigmentDTO>(bookSubcategoryAssigment);

                return Ok(bookSubcategoryAssigmentDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Methode GetBookSubcategoryAssigment was throw exception");
                return BadRequest();
            }
        }

        // POST: api/BookSubcategoryAssigments
        [HttpPost]
        public async Task<ActionResult<BookSubcategoryAssigmentDTO>> PostBookSubcategoryAssigment(POSTBookSubcategoryAssigmentDTO pOSTBookSubcategoryAssigmentDTO)
        {
            try
            {
                var bookSubcategoryAssigment = await LoadBookSubcategoryAssigmentAsync(pOSTBookSubcategoryAssigmentDTO.BookId, pOSTBookSubcategoryAssigmentDTO.SubcategoryId);

                if (bookSubcategoryAssigment != null)
                {
                    return BadRequest("This BookSubcategoryAssigment has been existed already");
                }

                var book = await _context.Authors.FindAsync(pOSTBookSubcategoryAssigmentDTO.BookId);

                if (book == null)
                {
                    return NotFound();
                }

                var subcategory = await _context.Subcategories.FindAsync(pOSTBookSubcategoryAssigmentDTO.SubcategoryId);

                if (subcategory == null)
                {
                    return NotFound();
                }

                bookSubcategoryAssigment = new BookSubcategoryAssigment { BookId = pOSTBookSubcategoryAssigmentDTO.BookId, SubcategoryId = pOSTBookSubcategoryAssigmentDTO.SubcategoryId };

                _context.BookSubcategoryAssigments.Add(bookSubcategoryAssigment);
                await _context.SaveChangesAsync();

                bookSubcategoryAssigment = await LoadBookSubcategoryAssigmentAsync(pOSTBookSubcategoryAssigmentDTO.BookId, pOSTBookSubcategoryAssigmentDTO.SubcategoryId);

                var bookSubcategoryAssigmentDTO = _mapper.Map<BookSubcategoryAssigmentDTO>(bookSubcategoryAssigment);

                return CreatedAtAction("GetBookSubcategoryAssigment", new { pOSTBookSubcategoryAssigmentDTO.BookId, pOSTBookSubcategoryAssigmentDTO.SubcategoryId }, bookSubcategoryAssigmentDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Methode PostBookSubcategoryAssigment was throw exception");
                return BadRequest();
            }
        }

        // DELETE: api/BookSubcategoryAssigments/5&5
        [HttpDelete("{bookId}&{subcategoryId}")]
        public async Task<ActionResult<BookSubcategoryAssigmentDTO>> DeleteBookSubcategoryAssigment(int bookId, int subcategoryId)
        {
            try
            {
                var bookSubcategoryAssigment = await LoadBookSubcategoryAssigmentAsync(bookId, subcategoryId);

                if (bookSubcategoryAssigment == null)
                {
                    return NotFound();
                }

                _context.BookSubcategoryAssigments.Remove(bookSubcategoryAssigment);
                await _context.SaveChangesAsync();

                var bookSubcategoryAssigmentDTO = _mapper.Map<BookSubcategoryAssigmentDTO>(bookSubcategoryAssigment);

                return Ok(bookSubcategoryAssigmentDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Methode DeleteBookSubcategoryAssigment was throw exception");
                return BadRequest();
            }
        }
        private async Task<IEnumerable<BookSubcategoryAssigment>> LoadBookSubcategoryAssigmentsAsync()
        {
            return await _context.BookSubcategoryAssigments
                                         .Include(x => x.Book)
                                         .Include(x => x.Subcategory)
                                         .AsNoTracking()
                                         .ToListAsync();
        }

        private async Task<BookSubcategoryAssigment> LoadBookSubcategoryAssigmentAsync(int bookId, int subcategoryId)
        {
            return await _context.BookSubcategoryAssigments
                                        .Include(x => x.Book)
                                        .Include(x => x.Subcategory)
                                        .AsNoTracking()
                                        .FirstOrDefaultAsync(x => x.BookId == bookId && x.SubcategoryId == subcategoryId);
        }
    }
}
