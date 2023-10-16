using Microsoft.EntityFrameworkCore;
using TodoApi.Infra;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseInMemoryDatabase("TodoList"));

        builder.Services.AddControllers();

        var app = builder.Build();
        
        app.MapControllers();

        app.Run();
    }
}