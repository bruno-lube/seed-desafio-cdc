using BookStore.Api.Controllers;
using BookStore.Api.Domain.Models;
using BookStore.Api.Repository.Context;
using BookStore.Api.Services;
using BookStore.Api.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace BookStore.Api.UnitTests
{
    public class UnitTest1
    {
        private readonly BookStoreDbContext _context;
        private readonly AuthorService _authorService;
        private readonly AuthorsController _controller;

        public UnitTest1()
        {
            var dbContextOptions = new DbContextOptionsBuilder<BookStoreDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;
            _context = new BookStoreDbContext(dbContextOptions);
            SeedAuthors();
            _authorService = new AuthorService(_context);
            _controller = new AuthorsController(_authorService);
        }

        private void SeedAuthors()
        {
            var existingAuthor = new CreateAuthorRequest("John Doe", "john@doe.com", "Description for John");
            _context.Authors.Add(new Author(existingAuthor.Name, existingAuthor.Email, existingAuthor.Description));
            _context.SaveChanges();
        }

        [Fact(DisplayName = "Should not create Author when email address already exists")]
        [Trait("Services", "AuthorService")]
        public async void Test1()
        {
            var existingAuthor = new CreateAuthorRequest("John Doe", "john@doe.com", "Description for John");
            var createResult = await _authorService.CreateAuthor(existingAuthor);
            
            Assert.False(createResult.IsSuccess);
            Assert.Contains("Email", createResult.Errors.Keys);
            Assert.Contains("The email address is already in use.", createResult.Errors["Email"]);
        }

        [Fact(DisplayName = "Should create Author when email address does not exist in the database")]
        [Trait("Services", "AuthorService")]
        public async void Test2()
        {
            var newAuthor = new CreateAuthorRequest("Joseph Doe", "joseph@doe.com", "Description for Joseph");
            var createResult = await _authorService.CreateAuthor(newAuthor);
            
            Assert.True(createResult.IsSuccess);
        }
    }
}