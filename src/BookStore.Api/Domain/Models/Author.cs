namespace BookStore.Api.Domain.Models
{
    public class Author
    {
        public Author(string? name, string? email, string? description)
        {
            Name = name;
            Email = email;
            Description = description;
            CreatedAt = DateTime.Now;
        }

        public long Id { get; set; }
        public string? Name { get; }
        public string? Email { get; }
        public string? Description { get; }
        public DateTime CreatedAt { get; }
    }
}