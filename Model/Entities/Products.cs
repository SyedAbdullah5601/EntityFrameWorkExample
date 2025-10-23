using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Emit;

namespace EntityFrameWorkExample.model.entities
{
    [Table("Products")] // optional but clearer
    public class Products
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("product_id")]
        public int ProductId { get; set; }

        [Column("product_name")]
        public string ProductName { get; set; }

        [Column("product_price")]
        public decimal Price { get; set; }

        [Column("stock")]
        public int Stock { get; set; }

        [Column("category")]
        public string Category { get; set; }
        public Products() { }
        public Products(string productName, decimal price, int stock, string category)
        {
            ProductName = productName;
            Price = price;
            Stock = stock;
            Category = category;
        }
    }
}
