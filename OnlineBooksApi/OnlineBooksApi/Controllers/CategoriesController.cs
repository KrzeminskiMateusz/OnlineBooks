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
using OnlineBooksApi.Models.DTO;
using OnlineBooksApi.Models.DTO.Category;

namespace OnlineBooksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger<CategoriesController> _logger;
        private readonly LibraryContext _context;

        public CategoriesController(IMapper mapper, ILogger<CategoriesController> logger, LibraryContext context)
        {
            _mapper = mapper;
            _logger = logger;
            _context = context;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetCategories()
        {
            try
            {
                var categories = await LoadCategoriesAsync();

                var categoriesDTO = _mapper.Map<IEnumerable<CategoryDTO>>(categories);

                return Ok(categoriesDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Methode GetCategories was throw exception");
                return BadRequest();
            }
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDTO>> GetCategory(int id)
        {
            try
            {
                var category = await LoadCategoryAsync(id);

                var categoryDTO = _mapper.Map<CategoryDTO>(category);

                return Ok(categoryDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Methode GetCategory was throw exception");
                return BadRequest();
            }
        }

        // PUT: api/Categories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, CategoryDTO categoryDTO)
        {
            try
            {
                var category = await _context.Categories.FindAsync(id);

                if (category == null)
                {
                    return NotFound();
                }

                var categories = await _context.Categories.ToListAsync();

                if (categoryDTO.Name != null && categories.Any(x => x.Name == categoryDTO.Name && x.Id != id))
                {
                    return BadRequest("This category has been existed already");
                }

                _mapper.Map<CategoryDTO, Category>(categoryDTO, category);

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException) when (!CategoryExists(id))
                {
                    return NotFound();
                }

                category = await LoadCategoryAsync(id);

                categoryDTO = _mapper.Map<CategoryDTO>(category);

                return Ok(categoryDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Methode PutCategory was throw exception");
                return BadRequest();
            }
        }

        // POST: api/Categories
        [HttpPost]
        public async Task<ActionResult<CategoryDTO>> PostCategory(CategoryDTO categoryDTO)
        {
            try
            {
                var categories = await _context.Categories.ToListAsync();

                if (categoryDTO.Name != null && categories.Any(x => x.Name == categoryDTO.Name))
                {
                    return BadRequest("This category has been existed already");
                }

                var category = _mapper.Map<Category>(categoryDTO);

                _context.Categories.Add(category);
                await _context.SaveChangesAsync();

                category = await LoadCategoryAsync(category.Id);

                categoryDTO = _mapper.Map<CategoryDTO>(category);

                return CreatedAtAction("GetCategory", new { id = category.Id }, categoryDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Methode PostCategory was throw exception");
                return BadRequest();
            }
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CategoryDTO>> DeleteCategory(int id)
        {
            try
            {
                var category = await _context.Categories.FindAsync(id);

                if (category == null)
                {
                    return NotFound();
                }

                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();

                var categoryDTO = _mapper.Map<CategoryDTO>(category);

                return Ok(categoryDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Methode DeleteCategory was throw exception");
                return BadRequest();
            }
        }

        private bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.Id == id);
        }

        private async Task<IEnumerable<Category>> LoadCategoriesAsync()
        {
            return await _context.Categories
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
                                       .Include(x => x.Subcategories)
                                            .ThenInclude(x => x.Subcategory)
                                       .ToListAsync();
        }

        private async Task<Category> LoadCategoryAsync(int id)
        {
            return await _context.Categories
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
                                       .Include(x => x.Subcategories)
                                            .ThenInclude(x => x.Subcategory)
                                       .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
