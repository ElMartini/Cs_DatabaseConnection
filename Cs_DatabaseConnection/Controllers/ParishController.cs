using Cs_DatabaseConnection.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cs_DatabaseConnection.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ParishController(AppDbContext db) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await db.Parish.ToListAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var parish = await db.Parish.FindAsync(id);
        if (parish == null) {
            return NotFound(); }
        return Ok(parish);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Parish parish)
    {
        db.Parish.Add(parish);
        await db.SaveChangesAsync();
        return Ok(parish);
    }

}