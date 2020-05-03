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
using OnlineBooksApi.Models.DTO.Shelf;

namespace OnlineBooksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShelvesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger<ShelvesController> _logger;
        private readonly LibraryContext _context;

        public ShelvesController(IMapper mapper, ILogger<ShelvesController> logger, LibraryContext context)
        {
            _mapper = mapper;
            _logger = logger;
            _context = context;
        }

        // GET: api/Shelves
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShelfDTO>>> GetShelves()
        {
            try
            {
                var shelves = await LoadShelvesAsync();

                if (shelves == null)
                {
                    return NotFound();
                }

                var shelvesDTO = _mapper.Map<IEnumerable<ShelfDTO>>(shelves);

                return Ok(shelvesDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Methode GetShelves was throw exception");
                return BadRequest();
            }
        }

        // GET: api/Shelves/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ShelfDTO>> GetShelf(int id)
        {
            try
            {
                var shelf = await LoadShelfAsync(id);

                if (shelf == null)
                {
                    return NotFound();
                }

                var shelfDTO = _mapper.Map<ShelfDTO>(shelf);

                return Ok(shelfDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Methode GetShelf was throw exception");
                return BadRequest();
            }
        }

        // PUT: api/Shelves/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShelf(int id, ShelfDTO shelfDTO)
        {
            try
            {
                var shelf = await _context.Shelves.FindAsync(id);

                if (shelf == null)
                {
                    return NotFound();
                }

                var shelves = await _context.Shelves.ToListAsync();

                if (shelfDTO.Name != null && shelves.Any(x => x.Name == shelfDTO.Name && x.Id != id))
                {
                    return BadRequest("This shelf has been existed already");
                }

                _mapper.Map<ShelfDTO, Shelf>(shelfDTO, shelf);

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException) when (!ShelfExists(id))
                {
                    return NotFound();
                }

                shelf = await LoadShelfAsync(id);

                shelfDTO = _mapper.Map<ShelfDTO>(shelf);

                return Ok(shelfDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Methode PutShelf was throw exception");
                return BadRequest();
            }
        }

        // POST: api/Shelves
        [HttpPost]
        public async Task<ActionResult<ShelfDTO>> PostShelf(ShelfDTO shelfDTO)
        {
            try
            {
                var shelves = await _context.Shelves.ToListAsync();

                if (shelfDTO.Name != null && shelves.Any(x => x.Name == shelfDTO.Name))
                {
                    return BadRequest("This shelf has been existed already");
                }

                var shelf = _mapper.Map<Shelf>(shelfDTO);

                _context.Shelves.Add(shelf);
                await _context.SaveChangesAsync();

                shelf = await LoadShelfAsync(shelf.Id);

                shelfDTO = _mapper.Map<ShelfDTO>(shelf);

                return CreatedAtAction("GetShelf", new { id = shelf.Id }, shelfDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Methode PostShelf was throw exception");
                return BadRequest();
            }
        }

        // DELETE: api/Shelves/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ShelfDTO>> DeleteShelf(int id)
        {
            try
            {
                var shelf = await _context.Shelves.FindAsync(id);

                if (shelf == null)
                {
                    return NotFound();
                }

                _context.Shelves.Remove(shelf);
                await _context.SaveChangesAsync();

                var shelfDTO = _mapper.Map<ShelfDTO>(shelf);

                return Ok(shelfDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Methode DeleteShelf was throw exception");
                return BadRequest();
            }
        }

        private bool ShelfExists(int id)
        {
            return _context.Shelves.Any(e => e.Id == id);
        }

        private async Task<IEnumerable<Shelf>> LoadShelvesAsync()
        {
            return await _context.Shelves
                                       .Include(x => x.Authors)
                                                .ThenInclude(x => x.Author)
                                                    .ThenInclude(x => x.Categories)
                                                        .ThenInclude(x => x.Category)
                                       .Include(x => x.Authors)
                                            .ThenInclude(x => x.Author)
                                                .ThenInclude(x => x.Subcategories)
                                                    .ThenInclude(x => x.Subcategory)
                                        .Include(x => x.Authors)
                                            .ThenInclude(x => x.Author)
                                                .ThenInclude(x => x.Shelves)
                                                    .ThenInclude(x => x.Shelf)
                                      .Include(x => x.Books)
                                                .ThenInclude(x => x.Book)
                                                    .ThenInclude(x => x.Categories)
                                                        .ThenInclude(x => x.Category)
                                       .Include(x => x.Books)
                                            .ThenInclude(x => x.Book)
                                                .ThenInclude(x => x.Subcategories)
                                                    .ThenInclude(x => x.Subcategory)
                                        .Include(x => x.Books)
                                            .ThenInclude(x => x.Book)
                                                .ThenInclude(x => x.Shelves)
                                                    .ThenInclude(x => x.Shelf)
                                       .ToListAsync();
        }

        private async Task<Shelf> LoadShelfAsync(int id)
        {
            return await _context.Shelves
                                       .Include(x => x.Authors)
                                                .ThenInclude(x => x.Author)
                                                    .ThenInclude(x => x.Categories)
                                                        .ThenInclude(x => x.Category)
                                       .Include(x => x.Authors)
                                            .ThenInclude(x => x.Author)
                                                .ThenInclude(x => x.Subcategories)
                                                    .ThenInclude(x => x.Subcategory)
                                        .Include(x => x.Authors)
                                            .ThenInclude(x => x.Author)
                                                .ThenInclude(x => x.Shelves)
                                                    .ThenInclude(x => x.Shelf)
                                      .Include(x => x.Books)
                                                .ThenInclude(x => x.Book)
                                                    .ThenInclude(x => x.Categories)
                                                        .ThenInclude(x => x.Category)
                                       .Include(x => x.Books)
                                            .ThenInclude(x => x.Book)
                                                .ThenInclude(x => x.Subcategories)
                                                    .ThenInclude(x => x.Subcategory)
                                        .Include(x => x.Books)
                                            .ThenInclude(x => x.Book)
                                                .ThenInclude(x => x.Shelves)
                                                    .ThenInclude(x => x.Shelf)
                                       .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
