using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Product.UI.DTO
{
    public class ProductDto
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Product Name is required.")]
        public string ProductName { get; set; }


        [Required(ErrorMessage = "Price is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Price must be greater than 0.")]
        public int Price { get; set; }

        [Required(ErrorMessage = "Quantity is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be a positive value.")]
        public int Quantity { get; set; }

        [DisplayName("Category")]
        public int CategoryId { get; set; }




    }
}
