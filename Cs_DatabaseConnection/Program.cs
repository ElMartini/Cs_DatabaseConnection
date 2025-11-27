using Cs_DatabaseConnection.Model;
using Microsoft.EntityFrameworkCore;

namespace Cs_DatabaseConnection;

public class Program
{
    public static void Main()
    {
        var builder = WebApplication.CreateBuilder();
        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseInMemoryDatabase("MyDatabase"));
        builder.Services.AddSwaggerGen();
        builder.Services.AddControllers();
        var app = builder.Build();
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        
        app.MapControllers();
        
        app.Run();
    }
}