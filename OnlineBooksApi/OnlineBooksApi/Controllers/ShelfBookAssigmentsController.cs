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
using OnlineBooksApi.Models.DTO.ShelfBookAssigment;

namespace OnlineBooksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShelfBookAssigmentsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger<ShelfBookAssigmentsController> _logger;
        private readonly LibraryContext _context;

        public ShelfBookAssigmentsController(IMapper mapper, ILogger<ShelfBookAssigmentsController> logger, LibraryContext context)
        {
            _mapper = mapper;
            _logger = logger;
            _context = context;
        }

        // GET: api/ShelfBookAssigments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShelfBookAssigmentDTO>>> GetShelfBookAssigments()
        {
            try
            {
                var shelftBookAssigments = await LoadShelfBookAssigmentsAsync();

                if (shelftBookAssigments == null)
                {
                    return NotFound();
                }

                var shelftBookAssigmentsDTO = _mapper.Map<IEnumerable<ShelfBookAssigmentDTO>>(shelftBookAssigments);

                return Ok(shelftBookAssigmentsDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Methode GetShelfBookAssigments was throw exception");
                return BadRequest();
            }
        }

        // GET: api/ShelfBookAssigments/5&5
        [HttpGet("{shelfId}&{bookId}")]
        public async Task<ActionResult<ShelfBookAssigmentDTO>> GetShelfBookAssigment(int shelfId, int bookId)
        {
            try
            {
                var shelftBookAssigment = await LoadShelfBookAssigmentAsync(shelfId, bookId);

                if (shelftBookAssigment == null)
                {
                    return NotFound();
                }

                var shelftBookAssigmentDTO = _mapper.Map<ShelfBookAssigmentDTO>(shelftBookAssigment);

                return Ok(shelftBookAssigmentDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Methode GetShelfBookAssigment was throw exception");
                return BadRequest();
            }
        }

        // POST: api/ShelfBookAssigments
        [HttpPost]
        public async Task<ActionResult<ShelfBookAssigmentDTO>> PostShelfBookAssigment(POSTShelfBookAssigmentDTO pOSTShelfBookAssigmentDTO)
        {
            try
            {
                var shelftBookAssigment = await LoadShelfBookAssigmentAsync(pOSTShelfBookAssigmentDTO.ShelfId, pOSTShelfBookAssigmentDTO.BookId);

                if (shelftBookAssigment != null)
                {
                    return BadRequest("This PostShelfBookAssigment has been existed already");
                }

                var shelf = await _context.Shelves.FindAsync(pOSTShelfBookAssigmentDTO.ShelfId);

                if (shelf == null)
                {
                    return NotFound();
                }

                var book = await _context.Books.FindAsync(pOSTShelfBookAssigmentDTO.BookId);

                if (book == null)
                {
                    return NotFound();
                }

                shelftBookAssigment = new ShelfBookAssigment { ShelfId = pOSTShelfBookAssigmentDTO.ShelfId, BookId = pOSTShelfBookAssigmentDTO.BookId };

                _context.ShelfBookAssigments.Add(shelftBookAssigment);
                await _context.SaveChangesAsync();

                shelftBookAssigment = await LoadShelfBookAssigmentAsync(pOSTShelfBookAssigmentDTO.ShelfId, pOSTShelfBookAssigmentDTO.BookId);

                var shelftBookAssigmentDTO = _mapper.Map<ShelfBookAssigmentDTO>(shelftBookAssigment);

                return CreatedAtAction("GetShelfBookAssigment", new { pOSTShelfBookAssigmentDTO.ShelfId, pOSTShelfBookAssigmentDTO.BookId }, shelftBookAssigmentDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Methode PostShelfBookAssigment was throw exception");
                return BadRequest();
            }
        }

        // DELETE: api/ShelfBookAssigments/5&5
        [HttpDelete("{shelfId}&{bookId}")]
        public async Task<ActionResult<ShelfBookAssigmentDTO>> DeleteShelfBookAssigment(int shelfId, int bookId)
        {
            try
            {
                var shelftBookAssigment = await LoadShelfBookAssigmentAsync(shelfId, bookId);

                if (shelftBookAssigment == null)
                {
                    return NotFound();
                }

                _context.ShelfBookAssigments.Remove(shelftBookAssigment);
                await _context.SaveChangesAsync();

                var shelftBookAssigmentDTO = _mapper.Map<ShelfBookAssigmentDTO>(shelftBookAssigment);

                return Ok(shelftBookAssigmentDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Methode DeleteShelfBookAssigment was throw exception");
                return BadRequest();
            }
        }
        private async Task<IEnumerable<ShelfBookAssigment>> LoadShelfBookAssigmentsAsync()
        {
            return await _context.ShelfBookAssigments
                                         .Include(x => x.Shelf)
                                         .Include(x => x.Book)
                                         .AsNoTracking()
                                         .ToListAsync();
        }

        private async Task<ShelfBookAssigment> LoadShelfBookAssigmentAsync(int shelfId, int bookId)
        {
            return await _context.ShelfBookAssigments
                                        .Include(x => x.Shelf)
                                        .Include(x => x.Book)
                                        .AsNoTracking()
                                        .FirstOrDefaultAsync(x => x.ShelfId == shelfId && x.BookId == bookId);
        }
    }
}
