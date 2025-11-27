using Microsoft.EntityFrameworkCore;

namespace Cs_DatabaseConnection.Model;

public class AppDbContext(DbContextOptions<AppDbContext> options): DbContext
{
    
    public DbSet<Parish> Parish { get; set; }
    
}