using EntityFrameWorkExample.model.entities;
using EntityFrameWorkExample.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

using var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) => {
        services.AddDbContext<DatabaseContext>(options =>
        options.UseSqlServer("Data Source=DESKTOP-VV71SPC\\SQLEXPRESS;Initial Catalog=AbdullahDatabase;Integrated Security=True;Trust Server Certificate=True"));
    }).Build();

using var scope = host.Services.CreateScope();
var DatabaseContext = scope.ServiceProvider.GetService<DatabaseContext>();

try
{
    await DbContext.Database.EnsureCreatedAsync();
    if (!DbContext.Products.Any)
    {

        {
            new Products { ProductId = 1, ProductName = "Laptop", };
        

        }
    }
}
kkk