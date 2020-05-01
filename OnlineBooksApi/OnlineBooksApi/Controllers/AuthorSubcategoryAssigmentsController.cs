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
using OnlineBooksApi.Models.DTO.AuthorSubcategoryAssigment;

namespace OnlineBooksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorSubcategoryAssigmentsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger<AuthorSubcategoryAssigmentsController> _logger;
        private readonly LibraryContext _context;

        public AuthorSubcategoryAssigmentsController(IMapper mapper, ILogger<AuthorSubcategoryAssigmentsController> logger, LibraryContext context)
        {
            _mapper = mapper;
            _logger = logger;
            _context = context;
        }

        // GET: api/AuthorSubcategoryAssigments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorSubcategoryAssigmentDTO>>> GetAuthorSubcategoryAssigments()
        {
            try
            {
                var authorSubcategoryAssigments = await LoadAuthorSubcategoriesAssigmentsAsync();

                var authorSubcategoryAssigmentsDTO = _mapper.Map<IEnumerable<AuthorSubcategoryAssigmentDTO>>(authorSubcategoryAssigments);

                return Ok(authorSubcategoryAssigmentsDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Methode GetAuthorSubcategoryAssigments was throw exception");
                return BadRequest();
            }
        }

        // GET: api/AuthorSubcategoryAssigments/5&5
        [HttpGet("{authorId}&{subcategoryId}")]
        public async Task<ActionResult<AuthorSubcategoryAssigmentDTO>> GetAuthorSubcategoryAssigment(int authorId, int subcategoryId)
        {
            try
            {
                var authorSubcategoryAssigment = await LoadAuthorSubcategoryAssigmentAsync(authorId, subcategoryId);

                var authorSubcategoryAssigmentDTO = _mapper.Map<AuthorSubcategoryAssigmentDTO>(authorSubcategoryAssigment);

                return Ok(authorSubcategoryAssigmentDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Methode GetAuthorSubcategoryAssigment was throw exception");
                return BadRequest();
            }
        }

        // POST: api/AuthorSubcategoryAssigments
        [HttpPost]
        public async Task<ActionResult<AuthorSubcategoryAssigmentDTO>> PostAuthorSubcategoryAssigment(POSTAuthorSubcategoryAssigmentDTO pOSTAuthorSubcategoryAssigmentDTO)
        {
            try
            {
                var authorSubcategoryAssigment = await LoadAuthorSubcategoryAssigmentAsync(pOSTAuthorSubcategoryAssigmentDTO.AuthorId, pOSTAuthorSubcategoryAssigmentDTO.SubcategoryId);

                if (authorSubcategoryAssigment != null)
                {
                    return BadRequest("This AuthorSubcategoryAssigment has been existed already");
                }

                var author = await _context.Authors.FindAsync(pOSTAuthorSubcategoryAssigmentDTO.AuthorId);

                if (author == null)
                {
                    return NotFound();
                }

                var subcategory = await _context.Subcategories.FindAsync(pOSTAuthorSubcategoryAssigmentDTO.SubcategoryId);

                if (subcategory == null)
                {
                    return NotFound();
                }

                authorSubcategoryAssigment = new AuthorSubcategoryAssigment { AuthorId = pOSTAuthorSubcategoryAssigmentDTO.AuthorId, SubcategoryId = pOSTAuthorSubcategoryAssigmentDTO.SubcategoryId };

                _context.AuthorSubcategoryAssigments.Add(authorSubcategoryAssigment);
                await _context.SaveChangesAsync();

                authorSubcategoryAssigment = await LoadAuthorSubcategoryAssigmentAsync(pOSTAuthorSubcategoryAssigmentDTO.AuthorId, pOSTAuthorSubcategoryAssigmentDTO.SubcategoryId);

                var authorSubcategoryAssigmentDTO = _mapper.Map<AuthorSubcategoryAssigmentDTO>(authorSubcategoryAssigment);

                return CreatedAtAction("GetAuthorSubcategoryAssigment", new { pOSTAuthorSubcategoryAssigmentDTO.AuthorId, pOSTAuthorSubcategoryAssigmentDTO.SubcategoryId }, authorSubcategoryAssigmentDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Methode PostAuthorSubcategoryAssigment was throw exception");
                return BadRequest();
            }
        }

        // DELETE: api/AuthorSubcategoryAssigments/5
        [HttpDelete("{authorId}&{subcategoryId}")]
        public async Task<ActionResult<AuthorSubcategoryAssigmentDTO>> DeleteAuthorSubcategoryAssigment(int authorId, int subcategoryId)
        {
            try
            {
                var authorSubcategoryAssigment = await LoadAuthorSubcategoryAssigmentAsync(authorId, subcategoryId);

                if (authorSubcategoryAssigment == null)
                {
                    return NotFound();
                }

                _context.AuthorSubcategoryAssigments.Remove(authorSubcategoryAssigment);
                await _context.SaveChangesAsync();

                var authorSubcategoryAssigmentDTO = _mapper.Map<AuthorSubcategoryAssigmentDTO>(authorSubcategoryAssigment);

                return Ok(authorSubcategoryAssigmentDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Methode DeleteAuthorSubcategoryAssigment was throw exception");
                return BadRequest();
            }
        }

        private async Task<IEnumerable<AuthorSubcategoryAssigment>> LoadAuthorSubcategoriesAssigmentsAsync()
        {
            return await _context.AuthorSubcategoryAssigments
                                         .Include(x => x.Author)
                                         .Include(x => x.Subcategory)
                                         .AsNoTracking()
                                         .ToListAsync();
        }

        private async Task<AuthorSubcategoryAssigment> LoadAuthorSubcategoryAssigmentAsync(int authorId, int subcategoryId)
        {
            return await _context.AuthorSubcategoryAssigments
                                        .Include(x => x.Author)
                                        .Include(x => x.Subcategory)
                                        .AsNoTracking()
                                        .FirstOrDefaultAsync(x => x.AuthorId == authorId && x.SubcategoryId == subcategoryId);
        }
    }
}
