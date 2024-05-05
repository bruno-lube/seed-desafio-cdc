using BookStore.Api.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Api.Repository.Context
{
    public class BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : DbContext(options)
    {
        public DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasKey(a => a.Id);
            modelBuilder.Entity<Author>().Property(a => a.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Author>().Property(a => a.Name).IsRequired();
            modelBuilder.Entity<Author>().Property(a => a.Email).IsRequired();
            modelBuilder.Entity<Author>().Property(a => a.Description).IsRequired()
                .HasMaxLength(400);
            modelBuilder.Entity<Author>().Property(a => a.CreatedAt).IsRequired();
        }
    }
}
