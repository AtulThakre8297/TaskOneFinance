using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductAppAPI.Models;
using TaskOneFinance.Context;
using TaskOneFinance.Models;

namespace ProductAppAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        readonly ProductDbContext _productDbcontext;
        readonly IMapper _mapper;
        public ProductRepository(ProductDbContext productDbcontext, IMapper mapper)
        {
            _productDbcontext = productDbcontext;
            _mapper = mapper;
        }

        public void AddProduct(ProductDTO product)
        {
            var prod=_mapper.Map<Product>(product);
            _productDbcontext.Products.Add(prod);

            _productDbcontext.SaveChanges();
            
        }

        public bool DeleteById(int id)
        {
            int result;
            var product = _productDbcontext.Products.FirstOrDefault(u => u.ProductId == id);
            if (product != null)
            {
                _productDbcontext.Products.Remove(product);
                result = _productDbcontext.SaveChanges();
                if (result > 0)
                {
                    return true;
                }
            }
            return false;

        }

        public async Task<List<ProductDTO>> GetAllproducts()
        {
           
            var a = await _productDbcontext.Products.ToListAsync();
            var prod = _mapper.Map<List<ProductDTO>>(a);
            return prod;
        }

        public async Task<ProductDTO> GetProductById(int id)
        {
            var ak = _productDbcontext.Products.FirstOrDefault(u => u.ProductId == id);
            ProductDTO product=new ProductDTO();
            product.ProductId = ak.ProductId;
            product.ProductName= ak.ProductName;
            product.Price= ak.Price;
            product.Quantity= ak.Quantity;
            product.CategoryId = ak.CategoryId;
            //var prod = _mapper.Map<ProductDTO>(a);
             return product;

        }

        public bool UpdateProduct(Product product)
        {
            int result;
            var pro = _productDbcontext.Products.FirstOrDefault(u => u.ProductId == product.ProductId);
            if (pro != null)
            {
                _productDbcontext.Products.Remove(pro);
                _productDbcontext.Products.Add(product);
                result = _productDbcontext.SaveChanges();
                if (result > 0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
