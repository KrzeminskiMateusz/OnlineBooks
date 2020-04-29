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
using OnlineBooksApi.Models.DTO.Subcategory;

namespace OnlineBooksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubcategoriesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger<SubcategoriesController> _logger;
        private readonly LibraryContext _context;

        public SubcategoriesController(IMapper mapper, ILogger<SubcategoriesController> logger, LibraryContext context)
        {
            _mapper = mapper;
            _logger = logger;
            _context = context;
        }

        // GET: api/Subcategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubcategoryDTO>>> GetSubcategories()
        {
            try
            {
                var subcategories = await LoadSubcategoriesAsync();

                var subcategoriesDTO = _mapper.Map<IEnumerable<SubcategoryDTO>>(subcategories);

                return Ok(subcategoriesDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Methode GetSubcategories was throw exception");
                return BadRequest();
            }
        }

        // GET: api/Subcategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SubcategoryDTO>> GetSubcategory(int id)
        {
            try
            {
                var subcategory = await LoadSubcategoryAsync(id);

                var subcategoryDTO = _mapper.Map<SubcategoryDTO>(subcategory);

                return Ok(subcategoryDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Methode GetSubcategory was throw exception");
                return BadRequest();
            }
        }

        // PUT: api/Subcategories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubcategory(int id, SubcategoryDTO subcategoryDTO)
        {
            try
            {
                var subcategory = await _context.Subcategories.FindAsync(id);

                if (subcategory == null)
                {
                    return NotFound();
                }

                var subcategories = await _context.Subcategories.ToListAsync();

                if (subcategoryDTO.Name != null && subcategories.Any(x => x.Name == subcategoryDTO.Name && x.Id != id))
                {
                    return BadRequest("This subcategory has been existed already");
                }

                _mapper.Map<SubcategoryDTO, Subcategory>(subcategoryDTO, subcategory);

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException) when (!SubcategoryExists(id))
                {
                    return NotFound();
                }

                subcategory = await LoadSubcategoryAsync(id);

                subcategoryDTO = _mapper.Map<SubcategoryDTO>(subcategory);

                return Ok(subcategoryDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Methode PutSubcategory was throw exception");
                return BadRequest();
            }
        }

        // POST: api/Subcategories
        [HttpPost]
        public async Task<ActionResult<SubcategoryDTO>> PostSubcategory(SubcategoryDTO subcategoryDTO)
        {
            try
            {
                var subcategories = await _context.Subcategories.ToListAsync();

                if (subcategoryDTO.Name != null && subcategories.Any(x => x.Name == subcategoryDTO.Name))
                {
                    return BadRequest("This subcategory has been existed already");
                }

                var subcategory = _mapper.Map<Subcategory>(subcategoryDTO);

                _context.Subcategories.Add(subcategory);
                await _context.SaveChangesAsync();

                subcategory = await LoadSubcategoryAsync(subcategory.Id);

                subcategoryDTO = _mapper.Map<SubcategoryDTO>(subcategory);

                return CreatedAtAction("GetSubcategory", new { id = subcategory.Id }, subcategoryDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Methode PostSubcategory was throw exception");
                return BadRequest();
            }
        }

        // DELETE: api/Subcategories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SubcategoryDTO>> DeleteSubcategory(int id)
        {
            try
            {
                var subcategory = await _context.Subcategories.FindAsync(id);

                if (subcategory == null)
                {
                    return NotFound();
                }

                _context.Subcategories.Remove(subcategory);
                await _context.SaveChangesAsync();

                var subcategoryDTO = _mapper.Map<SubcategoryDTO>(subcategory);

                return Ok(subcategoryDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Methode DeleteSubcategory was throw exception");
                return BadRequest();
            }
        }

        private bool SubcategoryExists(int id)
        {
            return _context.Subcategories.Any(e => e.Id == id);
        }

        private async Task<IEnumerable<Subcategory>> LoadSubcategoriesAsync()
        {
            return await _context.Subcategories
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
                                       .Include(x => x.Categories)
                                            .ThenInclude(x => x.Category)
                                       .ToListAsync();
        }

        private async Task<Subcategory> LoadSubcategoryAsync(int id)
        {
            return await _context.Subcategories
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
                                       .Include(x => x.Categories)
                                            .ThenInclude(x => x.Category)
                                       .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
