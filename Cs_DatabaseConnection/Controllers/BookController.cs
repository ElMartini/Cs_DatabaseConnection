using Cs_DatabaseConnection.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cs_DatabaseConnection.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class BookController(AppDbContext db) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await db.Books.ToListAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var book = await db.Books.FindAsync(id);
        if (book == null) return NotFound();
        return Ok(book);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Book book)
    {
        db.Books.Add(book);
        await db.SaveChangesAsync();
        return Ok(book);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var book = await db.Books.FindAsync(id);
        if (book == null) return NotFound();
        db.Books.Remove(book);
        await db.SaveChangesAsync();
        return Ok();
    }
}