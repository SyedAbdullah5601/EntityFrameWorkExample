using EntityFrameWorkExample.model.entities;
using EntityFrameWorkExample.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

using var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) => {
        services.AddDbContext<DatabaseContext>(options =>
        options.UseSqlServer("Data Source=DESKTOP-3DNLIDP\\SQLEXPRESS;Initial Catalog=AbdullahDatabase;Integrated Security=True;Trust Server Certificate=True"));
    }).Build();

using var scope = host.Services.CreateScope();
var DatabaseContext = scope.ServiceProvider.GetService<DatabaseContext>();

try
{
    await DatabaseContext.Database.EnsureCreatedAsync();
    if (!DatabaseContext.Products.Any())
    {
        var newProduct = new Products
        { ProductName = "Laptop", Price = 1000, Category = "Computers", Stock = 15 };

        DatabaseContext.Products.Add(newProduct);
        await DatabaseContext.SaveChangesAsync();
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
} 