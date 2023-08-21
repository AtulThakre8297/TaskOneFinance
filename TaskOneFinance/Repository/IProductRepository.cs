using ProductAppAPI.Models;
using TaskOneFinance.Models;

namespace ProductAppAPI.Repository
{
    public interface IProductRepository
    {
        void AddProduct(ProductDTO product);
        bool DeleteById(int id);
        Task<List<ProductDTO>> GetAllproducts();
        Task<ProductDTO> GetProductById(int id);
        bool UpdateProduct(Product product);
    }
}
