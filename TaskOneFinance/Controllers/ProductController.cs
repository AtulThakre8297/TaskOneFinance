using AutoMapper;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductAppAPI.Models;
using ProductAppAPI.Repository;
using System.Collections.Generic;
using TaskOneFinance.Models;

namespace ProductAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        readonly IProductRepository _productRepository;
        readonly IMapper _mapper;

        public ProductController(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }


        [HttpGet]
        [Route("GetAllProducts")]

        public async Task<ActionResult> GetAllProducts()
        {

            List<ProductDTO> allproducts = await _productRepository.GetAllproducts();
            return Ok(allproducts);
        }



        [HttpGet]
        [Route("GetProductById")]
        public async Task<ActionResult> GetProductById(int id)
        {
            var prod =await _productRepository.GetProductById(id);
            if (prod != null)
            {
                return Ok(prod);
            }
            return BadRequest();
        }




        [HttpPost]
        [Route("AddProduct")]
        public async Task<ActionResult> AddProduct(ProductDTO product)
        {
            _productRepository.AddProduct(product);
            return Ok("New product Added");
        }




        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            bool result = _productRepository.DeleteById(id);
            if (result)
            {
                return Ok(result);
            }
            return BadRequest(new { message = "Failed to delete the product." });
        }

//        [HttpPut("updateProduct{id}")]
//        public async Task<IActionResult> UpdateProduct(int id, ProductDTO product)
//        {
//            var existingProduct = await _productRepository.GetProductById(id)
//;
//            if (existingProduct == null)
//            {
//                return NotFound("Product Not Exist!!!");
//            }
//            else
//            {
//                var input = _mapper.Map<Product>(product);
//                await _productRepository.UpdateProduct(input);
//                return Ok("Product updated successfully");
//            }

//        }


        [HttpPut]
        public async Task<IActionResult> UpdateProduct(ProductDTO pro)
        {
            Product product = _mapper.Map<Product>(pro);
            bool result =  _productRepository.UpdateProduct(product);
            if (result)
            {
                return Ok(result);
            }
            return BadRequest();
        }








    }
}
