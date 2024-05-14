using BookStore.Api.Domain.Models;
using BookStore.Api.ValueObjects;
using BookStore.Api.ViewModels;

namespace BookStore.Api.Services.Interfaces
{
    public interface IAuthorService
    {
        Task<Result<Author>> CreateAuthor(CreateAuthorRequest request);
    }
}