using EntityFrameWorkExample.model.entities;
using EntityFrameWorkExample.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

using var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services.AddDbContext<DatabaseContext>(options =>
        options.UseSqlServer("Data Source=DESKTOP-3DNLIDP\\SQLEXPRESS;Initial Catalog=AbdullahDatabase;Integrated Security=True;Trust Server Certificate=True"));
    }).Build();


using var scope = host.Services.CreateScope();
var DatabaseContext = scope.ServiceProvider.GetService<DatabaseContext>();

//var productToDelete = DatabaseContext.Products.Find(1);
//DatabaseContext.Products.Remove(productToDelete);
//DatabaseContext.SaveChanges();

//while (true)
//{
//    Console.WriteLine("choose table to insert data.\n 1. Customer\n 2. Products.\n3. Employee.");
//    int choice = int.Parse(Console.ReadLine());

//    while (choice != 1 && choice != 2 && choice != 3)
//    {
//        Console.WriteLine("invalid input, please select valid table.");
//        choice = int.Parse(Console.ReadLine());
//    }

//    switch (choice)
//    {
//        case 1:
//            Console.WriteLine("Enter First Name:");
//            string fname = Console.ReadLine();

//            Console.WriteLine("Enter Last Name:");
//            string lname = Console.ReadLine();

//            Console.WriteLine("Enter Email:");
//            string email = Console.ReadLine();

//            Console.WriteLine("Enter Password:");
//            string password = Console.ReadLine();

//            Console.WriteLine("Enter Address:");
//            string address = Console.ReadLine();

//            Console.WriteLine("Enter Phone Number:");
//            string phone = Console.ReadLine();
//            Customer customer = new Customer(fname, lname, email, password, address, phone);
//            break;

//        case 2:
//            Console.WriteLine("Enter Product Name:");
//            string name = Console.ReadLine();

//            Console.WriteLine("Enter Product Price:");
//            decimal price = decimal.Parse(Console.ReadLine());

//            Console.WriteLine("Enter Product Stock:");
//            int stock = int.Parse(Console.ReadLine());

//            Console.WriteLine("Enter Product Category:");
//            string category = Console.ReadLine();
//            Products product = new Products(name, price, stock, category);
//            DatabaseContext.Products.Add(product);
//            DatabaseContext.SaveChanges();
//            break;

//        case 3:
//            Console.WriteLine("Enter Employee Name:");
//            string empName = Console.ReadLine();

//            Console.WriteLine("Enter Department:");
//            string department = Console.ReadLine();

//            Console.WriteLine("Enter Annual Salary:");
//            decimal annualSalary = decimal.Parse(Console.ReadLine());

//            Console.WriteLine("Enter Years of Experience:");
//            int yearsExperience = int.Parse(Console.ReadLine());
//            Employee employee = new Employee(empName, department, annualSalary, yearsExperience);
//            DatabaseContext.Employees.Add(employee);
//            DatabaseContext.SaveChanges();
//            break;
//    }

//}

var electronics = from p in DatabaseContext.Products where p.Price>900 select p;
foreach (var product in electronics)
{
    Console.WriteLine($"{product.ProductName} - {product.Price}");
}