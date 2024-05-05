using BookStore.Api.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Api.ViewModels
{
    public class CreateAuthorRequest
    {
        [Required(ErrorMessage = "The Name field is required.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "The Email field is required.")]
        [EmailAddress(ErrorMessage = "The Email field is must be a valid email address.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "The Description field is required.")]
        [StringLength(400, ErrorMessage = "The Description field must have a maximum of {1} characters.")]
        public string? Description { get; set; }

        internal Author ToAuthor()
            => new Author(Name, Email, Description);
    }
}