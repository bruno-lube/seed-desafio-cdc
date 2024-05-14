using BookStore.Api.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Api.ViewModels
{
    public class CreateAuthorRequest(string name, string email, string description)
    {
        [Required(ErrorMessage = "The Name field is required.")]
        public string? Name { get; private set; } = name;

        [Required(ErrorMessage = "The Email field is required.")]
        [EmailAddress(ErrorMessage = "The Email field is must be a valid email address.")]
        public string? Email { get; private set; } = email;

        [Required(ErrorMessage = "The Description field is required.")]
        [StringLength(400, ErrorMessage = "The Description field must have a maximum of {1} characters.")]
        public string? Description { get; private set; } = description;

        internal Author ToAuthor()
            => new (Name, Email, Description);
    }
}