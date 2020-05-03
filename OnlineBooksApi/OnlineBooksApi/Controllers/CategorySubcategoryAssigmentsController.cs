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
using OnlineBooksApi.Models.DTO.CategorySubcategoryAssigment;

namespace OnlineBooksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategorySubcategoryAssigmentsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger<CategorySubcategoryAssigmentsController> _logger;
        private readonly LibraryContext _context;

        public CategorySubcategoryAssigmentsController(IMapper mapper, ILogger<CategorySubcategoryAssigmentsController> logger, LibraryContext context)
        {
            _mapper = mapper;
            _logger = logger;
            _context = context;
        }

        // GET: api/CategorySubcategoryAssigments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategorySubcategoryAssigmentDTO>>> GetCategorySubcategoryAssigments()
        {
            try
            {
                var categorySubcategoryAssigments = await LoadCategorySubcategoryAssigmentsAsync();

                if (categorySubcategoryAssigments == null)
                {
                    return NotFound();
                }

                var categorySubcategoryAssigmentsDTO = _mapper.Map<IEnumerable<CategorySubcategoryAssigmentDTO>>(categorySubcategoryAssigments);

                return Ok(categorySubcategoryAssigmentsDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Methode GetCategorySubcategoryAssigments was throw exception");
                return BadRequest();
            }
        }

        // GET: api/CategorySubcategoryAssigments/5&5
        [HttpGet("{categoryId}&{subcategoryId}")]
        public async Task<ActionResult<CategorySubcategoryAssigmentDTO>> GetCategorySubcategoryAssigment(int categoryId, int subcategoryId)
        {
            try
            {
                var categorySubcategoryAssigment = await LoadCategorySubcategoryAssigmentAsync(categoryId, subcategoryId);

                if (categorySubcategoryAssigment == null)
                {
                    return NotFound();
                }

                var categorySubcategoryAssigmentDTO = _mapper.Map<CategorySubcategoryAssigmentDTO>(categorySubcategoryAssigment);

                return Ok(categorySubcategoryAssigmentDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Methode GetCategorySubcategoryAssigment was throw exception");
                return BadRequest();
            }
        }

        // POST: api/CategorySubcategoryAssigments
        [HttpPost]
        public async Task<ActionResult<CategorySubcategoryAssigmentDTO>> PostCategorySubcategoryAssigment(POSTCategorySubcategoryAssigmentDTO pOSTCategorySubcategoryAssigmentDTO)
        {
            try
            {
                var categorySubcategoryAssigment = await LoadCategorySubcategoryAssigmentAsync(pOSTCategorySubcategoryAssigmentDTO.CategoryId, pOSTCategorySubcategoryAssigmentDTO.SubcategoryId);

                if (categorySubcategoryAssigment != null)
                {
                    return BadRequest("This CategorySubcategoryAssigment has been existed already");
                }

                var category = await _context.Categories.FindAsync(pOSTCategorySubcategoryAssigmentDTO.CategoryId);

                if (category == null)
                {
                    return NotFound();
                }

                var subcategory = await _context.Subcategories.FindAsync(pOSTCategorySubcategoryAssigmentDTO.SubcategoryId);

                if (category == null)
                {
                    return NotFound();
                }

                categorySubcategoryAssigment = new CategorySubcategoryAssigment { CategoryId = pOSTCategorySubcategoryAssigmentDTO.CategoryId, SubcategoryId = pOSTCategorySubcategoryAssigmentDTO.SubcategoryId };

                _context.CategorySubcategoryAssigments.Add(categorySubcategoryAssigment);
                await _context.SaveChangesAsync();

                categorySubcategoryAssigment = await LoadCategorySubcategoryAssigmentAsync(pOSTCategorySubcategoryAssigmentDTO.CategoryId, pOSTCategorySubcategoryAssigmentDTO.SubcategoryId);

                var categorySubcategoryAssigmentDTO = _mapper.Map<CategorySubcategoryAssigmentDTO>(categorySubcategoryAssigment);

                return CreatedAtAction("GetCategorySubcategoryAssigment", new { pOSTCategorySubcategoryAssigmentDTO.CategoryId, pOSTCategorySubcategoryAssigmentDTO.SubcategoryId }, categorySubcategoryAssigmentDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Methode PostCategorySubcategoryAssigment was throw exception");
                return BadRequest();
            }
        }

        // DELETE: api/CategorySubcategoryAssigments/5&5
        [HttpDelete("{categoryId}&{subcategoryId}")]
        public async Task<ActionResult<CategorySubcategoryAssigmentDTO>> DeleteCategorySubcategoryAssigment(int categoryId, int subcategoryId)
        {
            try
            {
                var categorySubcategoryAssigment = await LoadCategorySubcategoryAssigmentAsync(categoryId, subcategoryId);

                if (categorySubcategoryAssigment == null)
                {
                    return NotFound();
                }

                _context.CategorySubcategoryAssigments.Remove(categorySubcategoryAssigment);
                await _context.SaveChangesAsync();

                var categorySubcategoryAssigmentDTO = _mapper.Map<CategorySubcategoryAssigmentDTO>(categorySubcategoryAssigment);

                return Ok(categorySubcategoryAssigmentDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Methode DeleteCategorySubcategoryAssigment was throw exception");
                return BadRequest();
            }
        }

        private async Task<IEnumerable<CategorySubcategoryAssigment>> LoadCategorySubcategoryAssigmentsAsync()
        {
            return await _context.CategorySubcategoryAssigments
                                         .Include(x => x.Category)
                                         .Include(x => x.Subcategory)
                                         .AsNoTracking()
                                         .ToListAsync();
        }

        private async Task<CategorySubcategoryAssigment> LoadCategorySubcategoryAssigmentAsync(int categoryId, int subcategoryId)
        {
            return await _context.CategorySubcategoryAssigments
                                        .Include(x => x.Category)
                                        .Include(x => x.Subcategory)
                                        .AsNoTracking()
                                        .FirstOrDefaultAsync(x => x.CategoryId == categoryId && x.SubcategoryId == subcategoryId);
        }
    }
}
