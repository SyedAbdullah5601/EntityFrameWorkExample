using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameWorkExample.model.entities
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("customer_id")]
        public int customer_id { get; set; }
        [Column("first_name")]
        public string first_name { get; set; }
        [Column("last_name")]
        public string last_name { get; set; }
        [Column("email")]
        public string email { get; set; }
        [Column("password")]
        public string password { get; set; }
        [Column("address")]
        public string address { get; set; }
        [Column("phone_number")]
        public string phone_number { get; set; }

        public Customer() { }
        public Customer(string first_name, string last_name, string email, string password, string address, string phone_number)
        {

            this.first_name = first_name;
            this.last_name = last_name;
            this.email = email;
            this.password = password;
            this.address = address;
            this.phone_number = phone_number;
        }
    }
}