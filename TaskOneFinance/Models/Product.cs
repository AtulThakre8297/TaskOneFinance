using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskOneFinance.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public int Price { get; set; }


        public int Quantity { get; set; }

        [ForeignKey("Category")]
        public virtual int CategoryId { get; set; } //For foreign Key

        
        public virtual Category Category { get; set; } //Navigation property
    }
}
