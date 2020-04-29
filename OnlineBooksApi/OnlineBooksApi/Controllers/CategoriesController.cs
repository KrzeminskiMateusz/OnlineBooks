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
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return category;
        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, Category category)
        {
            if (id != category.Id)
            {
                return BadRequest();
            }

            _context.Entry(category).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
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

        // POST: api/Categories
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategory", new { id = category.Id }, category);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Category>> DeleteCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return category;
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
