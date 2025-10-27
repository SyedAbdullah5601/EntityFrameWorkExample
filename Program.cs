using EntityFrameWorkExample.model.entities;
using EntityFrameWorkExample.Model;
using EntityFrameWorkExample.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Client;

using var host = Host.CreateDefaultBuilder(args).ConfigureServices((context, services) =>
    {
        services.AddDbContext<DatabaseContext>(options =>
        options.UseSqlServer("Data Source=localhost\\SQLEXPRESS;Initial Catalog=AbdullahDatabase;Integrated Security=True;Trust Server Certificate=True"));
    }).Build();


//DESKTOP-VV71SPC
//"Data Source=DESKTOP-3DNLIDP\\SQLEXPRESS;Initial Catalog=AbdullahDatabase;Integrated Security=True;Trust Server Certificate=True"


using var scope = host.Services.CreateScope();
var DatabaseContext = scope.ServiceProvider.GetService<DatabaseContext>();


//to delete a record from the tables:
//var productToDelete = DatabaseContext.Products.Find(1);
//DatabaseContext.Products.Remove(productToDelete);
//DatabaseContext.SaveChanges();
//to add data to the tables:
while (true)
{
    Console.WriteLine("choose table to insert data.\n 1. Customer\n 2. Products.\n3. Employee.\n 4. Student\n5. Courses\n6. Enrollment");
    int choice = int.Parse(Console.ReadLine());

    //while (choice != 1 && choice != 2 && choice != 3)
    //{
    //    Console.WriteLine("invalid input, please select valid table.");
    //    choice = int.Parse(Console.ReadLine());
    //}

    switch (choice)
    {
        case 1:
            Console.WriteLine("Enter First Name:");
            string fname = Console.ReadLine();

            Console.WriteLine("Enter Last Name:");
            string lname = Console.ReadLine();

            Console.WriteLine("Enter Email:");
            string email = Console.ReadLine();

            Console.WriteLine("Enter Password:");
            string password = Console.ReadLine();

            Console.WriteLine("Enter Address:");
            string address = Console.ReadLine();

            Console.WriteLine("Enter Phone Number:");
            string phone = Console.ReadLine();
            Customer customer = new Customer(fname, lname, email, password, address, phone);
            DatabaseContext.Customers.Add(customer);
            DatabaseContext.SaveChanges();
            break;

        case 2:
            Console.WriteLine("Enter Product Name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter Product Price:");
            decimal price = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Enter Product Stock:");
            int stock = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Product Category:");
            string category = Console.ReadLine();
            Products product = new Products(name, price, stock, category);
            DatabaseContext.Products.Add(product);
            DatabaseContext.SaveChanges();
            break;

        case 3:
            Console.WriteLine("Enter Employee Name:");
            string empName = Console.ReadLine();

            Console.WriteLine("Enter Department:");
            string department = Console.ReadLine();

            Console.WriteLine("Enter Annual Salary:");
            decimal annualSalary = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Enter Years of Experience:");
            int yearsExperience = int.Parse(Console.ReadLine());
            Employee employee = new Employee(empName, department, annualSalary, yearsExperience);
            DatabaseContext.Employees.Add(employee);
            DatabaseContext.SaveChanges();
            break;
        case 4:
            Console.WriteLine("Enter Student Name:");
            string studentName = Console.ReadLine();

            Console.WriteLine("Enter Student Age:");
            int studentAge = int.Parse(Console.ReadLine());

            Students student = new Students { Name = studentName, Age = studentAge };
            DatabaseContext.Students.Add(student);
            DatabaseContext.SaveChanges();
            Console.WriteLine("✅ Student added successfully!");
            break;

        case 5:
            Console.WriteLine("Enter Course Title:");
            string courseTitle = Console.ReadLine();

            Console.WriteLine("Enter Course Credits:");
            int courseCredits = int.Parse(Console.ReadLine());

            Courses course = new Courses { Title = courseTitle, Credits = courseCredits };
            DatabaseContext.Courses.Add(course);
            DatabaseContext.SaveChanges();
            Console.WriteLine("✅ Course added successfully!");
            break;

        case 6:
            Console.WriteLine("Enter Student ID for Enrollment:");
            int enrollStudentId = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Course ID for Enrollment:");
            int enrollCourseId = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Grade (optional, press Enter to skip):");
            string grade = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(grade)) grade = null;

            Enrollment enrollment = new Enrollment
            {
                StudentId = enrollStudentId,
                CourseId = enrollCourseId,
                Grade = grade
            };

            DatabaseContext.Enrollments.Add(enrollment);
            DatabaseContext.SaveChanges();
            Console.WriteLine("✅ Enrollment added successfully!");
            break;

    }

}

////running the queries on the database:
//var electronics = from p in DatabaseContext.Products where p.ProductId == 2 select new { p.ProductId, p.ProductName, p.Price };
//foreach (var product in electronics)
//{
//    Console.WriteLine($"{product.ProductId} - {product.ProductName} - {product.Price}");
//}

//var count = (from p in DatabaseContext.Products where p.Category == "Electronics" select p).Count();
//Console.WriteLine(count);

//var productValue = from p in DatabaseContext.Products select p.Price * p.Stock;
//foreach (var product in productValue)
//{
//    Console.WriteLine(product);
//}

//var students = from s in DatabaseContext.Students select s;
//foreach(var s in students)
//{
//    Console.WriteLine($"{s.Id} - {s.Name} - {s.Age}");
//}

//var joinquery = from e in DatabaseContext.Enrollments
//                join s in DatabaseContext.Students on e.StudentId equals s.Id
//                join c in DatabaseContext.Courses on e.StudentId equals c.Id
//                select new { s.Name, s.Age, c.Title, e.Grade };

//foreach(var a in joinquery)
//{
//    Console.WriteLine($"{ a.Name}, { a.Age}, { a.Title}, { a.Grade}");
//}
