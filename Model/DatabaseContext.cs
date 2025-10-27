using EntityFrameWorkExample.model.entities;
using EntityFrameWorkExample.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameWorkExample.Model
{
    internal class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options){ }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<Students> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

    }
}
