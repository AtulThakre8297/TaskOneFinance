using System.ComponentModel.DataAnnotations;

namespace TaskOneFinance.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public string CategoryDescription { get; set; }

        public List<Product>Products { get; set;}
        
    }
}
