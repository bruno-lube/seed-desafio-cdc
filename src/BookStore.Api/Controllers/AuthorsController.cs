using BookStore.Api.Extensions;
using BookStore.Api.Services.Interfaces;
using BookStore.Api.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAuthor([FromBody] CreateAuthorRequest request)
        {
            var createAuthorResponse = await _authorService.CreateAuthor(request);
            return createAuthorResponse.IsSuccess 
                ? Ok(createAuthorResponse.Data) 
                : this.ToProblemDetails(createAuthorResponse.Errors);
        }
    }
}
