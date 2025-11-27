using Cs_DatabaseConnection.Controllers;
using Cs_DatabaseConnection.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace UnitTests;

public class UnitTestsBooks
{
    [Fact]
    public async Task AddBookToDatabase()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase(databaseName: "TestDb")
            .Options;
        using (var context = new AppDbContext(options))
        {
            var controller = new BookController(context);
            var book = new Book
            {
                Title = "Book",
                Author = "Author",
                AuthorId = 123
            };

            var result = await controller.Create(book);

            var createdResult = Assert.IsType<OkObjectResult>(result);

            var bookInDb = await context.Books.FirstOrDefaultAsync(b => b.Title == "Book");

            Assert.NotNull(bookInDb);
            Assert.Equal("Author", bookInDb.Author);
        }
    }
}