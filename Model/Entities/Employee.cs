using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameWorkExample.model.entities
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("employee_id")]
        public int employee_id { get; set; }
        [Column("name")]
        public string name { get; set; }
        [Column("department")]
        public string department { get; set; }
        [Column("annual_salary")]
        public decimal annual_salary { get; set; }
        [Column("years_experience")]
        public int years_experience { get; set; }

        public Employee() { }
        public Employee(string name, string department, decimal annualSalary, int yearsExperience)
        {
            this.name = name;
            this.department = department;
            this.annual_salary = annualSalary;
            this.years_experience = yearsExperience;
        }
    }
  
}