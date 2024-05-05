using BookStore.Api.Domain.Models;
using BookStore.Api.Repository.Context;
using BookStore.Api.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly BookStoreDbContext _dbContext;

        public AuthorsController(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAuthor([FromBody] CreateAuthorRequest request)
        {
            Author author = request.ToAuthor();
            await _dbContext.Authors.AddAsync(author);
            return Ok(author);
        }
    }
}
