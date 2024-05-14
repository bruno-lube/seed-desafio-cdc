using BookStore.Api.Domain.Models;
using BookStore.Api.Repository.Context;
using BookStore.Api.Services.Interfaces;
using BookStore.Api.ValueObjects;
using BookStore.Api.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Api.Services
{
    public class AuthorService(BookStoreDbContext dbContext) : IAuthorService
    {
        private readonly BookStoreDbContext _dbContext = dbContext;

        public async Task<Result<Author>> CreateAuthor(CreateAuthorRequest request)
        {
            bool alreadyExists = await _dbContext.Authors.AnyAsync(a => a.Email == request.Email);
            if (alreadyExists)
                return new Result<Author>("Email", ["The email address is already in use."]);

            Author author = request.ToAuthor();
            await _dbContext.Authors.AddAsync(author);
            await _dbContext.SaveChangesAsync();
            return new Result<Author>(author);
        }
    }
}
