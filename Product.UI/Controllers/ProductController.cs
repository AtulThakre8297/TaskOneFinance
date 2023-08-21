using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Product.UI.DTO;
//using ProductAppAPI.Models;
using System.Net;
using System.Text;

namespace Product.UI.Controllers
{
    public class ProductController : Controller
    {
        private readonly HttpClient _httpClient;

        public ProductController()
        {
            _httpClient = new HttpClient();

        }

        [HttpGet]
        public async Task<ActionResult> GetAllProducts()
        {
            List<ProductDto> allProducts = new List<ProductDto>(); 

            using (var response = await _httpClient.GetAsync("https://localhost:7299/api/Product/GetAllProducts"))
            {
                string data = await response.Content.ReadAsStringAsync();
                allProducts = JsonConvert.DeserializeObject<List<ProductDto>>(data); 
            }

            return View(allProducts); 
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductDto product)
        {
            if (ModelState.IsValid)
            {
                string dtoJson = JsonConvert.SerializeObject(product);
                var content = new StringContent(dtoJson, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _httpClient.PostAsync("https://localhost:7299/api/Product/AddProduct", content);
                if (response.IsSuccessStatusCode)
                {
                    TempData["SuccessMessage"] = "Product Added successfully!";
                    return RedirectToAction("GetAllProducts");
                }
                else
                {
                    TempData["SuccessMessage"] = "Product Already Exists";
                    return RedirectToAction("AddProduct");
                }
            }
            return View(product);
        }

        [HttpGet]
        public async Task<IActionResult> GetProductById(int id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"https://localhost:7299/api/Product/GetProductById?id={id}");
            if (response.IsSuccessStatusCode) 
            {
                string content = await response.Content.ReadAsStringAsync();
                var product = JsonConvert.DeserializeObject<ProductDto>(content);
                return View(product);
            }
            return View(); 
        }


        [HttpGet]
        public async Task<IActionResult> UpdateProduct(int id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"https://localhost:7299/api/Product/GetProductById?id={id}");
            if (response.IsSuccessStatusCode) 
                {
                string content = await response.Content.ReadAsStringAsync();
                var product = JsonConvert.DeserializeObject<ProductDto>(content);
                return View(product);
            }
            return View(); 
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(ProductDto product)
        {
            if (ModelState.IsValid)
            {
                string dtoJson = JsonConvert.SerializeObject(product);
                var content = new StringContent(dtoJson, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _httpClient.PutAsync($"https://localhost:7299/api/Product", content);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("GetAllProducts");
                }
            }
            return View(product);
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"https://localhost:7299/api/Product/GetProductById?id={id}");
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var product = JsonConvert.DeserializeObject<ProductDto>(content);
                return View(product);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync($"https://localhost:7299/api/Product/{id}");

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("GetAllProducts");
            }
            else if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                ModelState.AddModelError(string.Empty, "Failed to delete the product.");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "An error occurred while processing your request.");
            }

            return View("GetAllProducts");
        }





    }
}
