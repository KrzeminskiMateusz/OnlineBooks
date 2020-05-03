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
using OnlineBooksApi.Models.DTO.ShelfAuthorAssigment;

namespace OnlineBooksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShelfAuthorAssigmentsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger<ShelfAuthorAssigmentsController> _logger;
        private readonly LibraryContext _context;

        public ShelfAuthorAssigmentsController(IMapper mapper, ILogger<ShelfAuthorAssigmentsController> logger, LibraryContext context)
        {
            _mapper = mapper;
            _logger = logger;
            _context = context;
        }

        // GET: api/ShelftAuthorAssigments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShelfAuthorAssigmentDTO>>> GetShelfAuthorAssigments()
        {
            try
            {
                var shelftAuthorAssigments = await LoadShelfAuthorAssigmentsAsync();

                if (shelftAuthorAssigments == null)
                {
                    return NotFound();
                }

                var shelftAuthorAssigmentsDTO = _mapper.Map<IEnumerable<ShelfAuthorAssigmentDTO>>(shelftAuthorAssigments);

                return Ok(shelftAuthorAssigmentsDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Methode GetShelfAuthorAssigments was throw exception");
                return BadRequest();
            }
        }

        // GET: api/ShelftAuthorAssigments/5&5
        [HttpGet("{shelfId}&{authorId}")]
        public async Task<ActionResult<ShelfAuthorAssigmentDTO>> GetShelfAuthorAssigment(int shelfId, int authorId)
        {
            try
            {
                var shelftAuthorAssigment = await LoadShelfAuthorAssigmentAsync(shelfId, authorId);

                if (shelftAuthorAssigment == null)
                {
                    return NotFound();
                }

                var shelftAuthorAssigmentDTO = _mapper.Map<ShelfAuthorAssigmentDTO>(shelftAuthorAssigment);

                return Ok(shelftAuthorAssigmentDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Methode GetShelfAuthorAssigment was throw exception");
                return BadRequest();
            }
        }

        // POST: api/ShelftAuthorAssigments
        [HttpPost]
        public async Task<ActionResult<ShelfAuthorAssigmentDTO>> PostShelfAuthorAssigment(POSTShelfAuthorAssigmentDTO pOSTShelfAuthorAssigmentDTO)
        {
            try
            {
                var shelftAuthorAssigment = await LoadShelfAuthorAssigmentAsync(pOSTShelfAuthorAssigmentDTO.ShelfId, pOSTShelfAuthorAssigmentDTO.AuthorId);

                if (shelftAuthorAssigment != null)
                {
                    return BadRequest("This ShelfAuthorAssigment has been existed already");
                }

                var shelf = await _context.Shelves.FindAsync(pOSTShelfAuthorAssigmentDTO.ShelfId);

                if (shelf == null)
                {
                    return NotFound();
                }

                var author = await _context.Authors.FindAsync(pOSTShelfAuthorAssigmentDTO.AuthorId);

                if (author == null)
                {
                    return NotFound();
                }

                shelftAuthorAssigment = new ShelfAuthorAssigment { ShelfId = pOSTShelfAuthorAssigmentDTO.ShelfId, AuthorId = pOSTShelfAuthorAssigmentDTO.AuthorId };

                _context.ShelftAuthorAssigments.Add(shelftAuthorAssigment);
                await _context.SaveChangesAsync();

                shelftAuthorAssigment = await LoadShelfAuthorAssigmentAsync(pOSTShelfAuthorAssigmentDTO.ShelfId, pOSTShelfAuthorAssigmentDTO.AuthorId);

                var shelftAuthorAssigmentDTO = _mapper.Map<ShelfAuthorAssigmentDTO>(shelftAuthorAssigment);

                return CreatedAtAction("GetShelfAuthorAssigment", new { pOSTShelfAuthorAssigmentDTO.ShelfId, pOSTShelfAuthorAssigmentDTO.AuthorId }, shelftAuthorAssigmentDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Methode PostShelfAuthorAssigment was throw exception");
                return BadRequest();
            }
        }

        // DELETE: api/ShelftAuthorAssigments/5&5
        [HttpDelete("{shelfId}&{authorId}")]
        public async Task<ActionResult<ShelfAuthorAssigmentDTO>> DeleteShelfAuthorAssigment(int shelfId, int authorId)
        {
            try
            {
                var shelftAuthorAssigment = await LoadShelfAuthorAssigmentAsync(shelfId, authorId);

                if (shelftAuthorAssigment == null)
                {
                    return NotFound();
                }

                _context.ShelftAuthorAssigments.Remove(shelftAuthorAssigment);
                await _context.SaveChangesAsync();

                var shelftAuthorAssigmentDTO = _mapper.Map<ShelfAuthorAssigmentDTO>(shelftAuthorAssigment);

                return Ok(shelftAuthorAssigmentDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Methode DeleteShelfAuthorAssigment was throw exception");
                return BadRequest();
            }
        }

        private async Task<IEnumerable<ShelfAuthorAssigment>> LoadShelfAuthorAssigmentsAsync()
        {
            return await _context.ShelftAuthorAssigments
                                         .Include(x => x.Shelf)
                                         .Include(x => x.Author)
                                         .AsNoTracking()
                                         .ToListAsync();
        }

        private async Task<ShelfAuthorAssigment> LoadShelfAuthorAssigmentAsync(int shelfId, int authorId)
        {
            return await _context.ShelftAuthorAssigments
                                        .Include(x => x.Shelf)
                                        .Include(x => x.Author)
                                        .AsNoTracking()
                                        .FirstOrDefaultAsync(x => x.ShelfId == shelfId && x.AuthorId == authorId);
        }
    }
}
