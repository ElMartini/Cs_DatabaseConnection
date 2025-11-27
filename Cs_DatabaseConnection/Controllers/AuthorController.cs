using Cs_DatabaseConnection.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cs_DatabaseConnection.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class AuthorController(AppDbContext db) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await db.Authors.ToListAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var author = await db.Authors.FindAsync(id);
        if (author == null)
        {
            return NotFound();
        }

        return Ok(author);
    }

    
    [HttpPost]
    public async Task<IActionResult> Create(Author author)
    {
        db.Authors.Add(author);
        await db.SaveChangesAsync();
        return Ok(author);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteById(int id)
    {
        var author = await db.Authors.FindAsync(id);
        if (author == null) return NotFound();
        db.Authors.Remove(author);
        await db.SaveChangesAsync();
        return Ok();
    }
    
    
}