using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OnlineBooksApi.Data;
using OnlineBooksApi.Models;
using OnlineBooksApi.Models.DTO.AuthorCategoryAssigment;

namespace OnlineBooksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorCategoryAssigmentsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger<AuthorCategoryAssigmentsController> _logger;
        private readonly LibraryContext _context;

        public AuthorCategoryAssigmentsController(IMapper mapper, ILogger<AuthorCategoryAssigmentsController> logger, LibraryContext context)
        {
            _mapper = mapper;
            _logger = logger;
            _context = context;
        }

        // GET: api/AuthorCategoryAssigments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorCategoryAssigmentDTO>>> GetAuthorCategoryAssigments()
        {
            try
            {
                var authorCategoryAssigments = await LoadAuthorCategoryAssigmentsAsync();

                var authorCategoryAssigmentsDTO = _mapper.Map<IEnumerable<AuthorCategoryAssigmentDTO>>(authorCategoryAssigments);

                return Ok(authorCategoryAssigmentsDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Methode GetAuthorCategoryAssigments was throw exception");
                return BadRequest();
            }
        }

        // GET: api/AuthorCategoryAssigments/5&5
        [HttpGet("{authorId}&{categoryId}")]
        public async Task<ActionResult<AuthorCategoryAssigmentDTO>> GetAuthorCategoryAssigment(int authorId, int categoryId)
        {
            try
            {
                var authorCategoryAssigment = await LoadAuthorCategoryAssigmentAsync(authorId, categoryId);

                var authorCategoryAssigmentDTO = _mapper.Map<AuthorCategoryAssigmentDTO>(authorCategoryAssigment);

                return Ok(authorCategoryAssigmentDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Methode GetAuthorCategoryAssigment was throw exception");
                return BadRequest();
            }
        }
     
        // POST: api/AuthorCategoryAssigments
        [HttpPost]
        public async Task<ActionResult<AuthorCategoryAssigmentDTO>> PostAuthorCategoryAssigment(POSTAuthorCategoryAssigmentDTO pOSTAuthorCategoryAssigmentDTO)
        {
            try
            {
                var authorCategoryAssigment = await LoadAuthorCategoryAssigmentAsync(pOSTAuthorCategoryAssigmentDTO.AuthorId, pOSTAuthorCategoryAssigmentDTO.CategoryId);

                if (authorCategoryAssigment != null)
                {
                    return BadRequest("This AuthorCategoryAssigment has been existed already");
                }

                var author = await _context.Authors.FindAsync(pOSTAuthorCategoryAssigmentDTO.AuthorId);

                if (author == null)
                {
                    return NotFound();
                }

                var category = await _context.Categories.FindAsync(pOSTAuthorCategoryAssigmentDTO.CategoryId);

                if (category == null)
                {
                    return NotFound();
                }

                authorCategoryAssigment = new AuthorCategoryAssigment { AuthorId = pOSTAuthorCategoryAssigmentDTO.AuthorId, CategoryId = pOSTAuthorCategoryAssigmentDTO.CategoryId };

                _context.AuthorCategoryAssigments.Add(authorCategoryAssigment);
                await _context.SaveChangesAsync();

                authorCategoryAssigment = await LoadAuthorCategoryAssigmentAsync(pOSTAuthorCategoryAssigmentDTO.AuthorId, pOSTAuthorCategoryAssigmentDTO.CategoryId);

                var authorCategoryAssigmentDTO = _mapper.Map<AuthorCategoryAssigmentDTO>(authorCategoryAssigment);

                return CreatedAtAction("GetAuthorCategoryAssigment", new { pOSTAuthorCategoryAssigmentDTO.AuthorId, pOSTAuthorCategoryAssigmentDTO.CategoryId }, authorCategoryAssigmentDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Methode PostAuthorCategoryAssigment was throw exception");
                return BadRequest();
            }
        }

        // DELETE: api/AuthorCategoryAssigments/5&5
        [HttpDelete("{authorId}&{categoryId}")]
        public async Task<ActionResult<AuthorCategoryAssigmentDTO>> DeleteAuthorCategoryAssigment(int authorId, int categoryId)
        {
            try
            {
                var authorCategoryAssigment = await LoadAuthorCategoryAssigmentAsync(authorId, categoryId);

                if (authorCategoryAssigment == null)
                {
                    return NotFound();
                }

                _context.AuthorCategoryAssigments.Remove(authorCategoryAssigment);
                await _context.SaveChangesAsync();

                var authorCategoryAssigmentDTO = _mapper.Map<AuthorCategoryAssigmentDTO>(authorCategoryAssigment);

                return Ok(authorCategoryAssigmentDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Methode DeleteAuthorCategoryAssigment was throw exception");
                return BadRequest();
            }
        }

        private async Task<IEnumerable<AuthorCategoryAssigment>> LoadAuthorCategoryAssigmentsAsync()
        {
            return await _context.AuthorCategoryAssigments
                                         .Include(x => x.Author)                                              
                                         .Include(x => x.Category)
                                         .AsNoTracking()
                                         .ToListAsync();
        }

        private async Task<AuthorCategoryAssigment> LoadAuthorCategoryAssigmentAsync(int authorId, int categoryId)
        {
            return await _context.AuthorCategoryAssigments
                                        .Include(x => x.Author)
                                        .Include(x => x.Category)
                                        .AsNoTracking()
                                        .FirstOrDefaultAsync(x => x.AuthorId == authorId && x.CategoryId == categoryId);
        }
    }
}
