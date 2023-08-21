using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Product.UI.DTO;
using System.Text;
//using TaskOneFinance.Models;

namespace Product.UI.Controllers
{
    public class UserController : Controller
    {
       
            private readonly HttpClient _httpClient;

            public UserController(HttpClient httpClient)
            {
                _httpClient = httpClient;
            }


            [HttpGet]
            public IActionResult Register()
            {
                return View();
            }

            [HttpPost]
            public async Task<IActionResult> Register(DTO.RegisterDTO register)
            {
                var content = new StringContent(JsonConvert.SerializeObject(register), Encoding.UTF8, "application/json");

                using (var response = await _httpClient.PostAsync($"https://localhost:7299/api/User/RegisterUser", content))
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    if (response.IsSuccessStatusCode)
                    {
                        TempData["SuccessMessage"] = "User Registered  successfully!";
                        return RedirectToAction("Login");
                    }
                    else
                    {
                        TempData["SuccessMessage"] = "Registeration failed!";
                        return RedirectToAction("Register");
                    }
                }

                return View();
            }


            [HttpGet]
            public IActionResult Login()
            {
                return View();
            }


        [HttpPost]
        public async Task<IActionResult> Login(DTO.LoginDTO model)
        {
            var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

            using (var response = await _httpClient.PostAsync($"https://localhost:7299/api/User/LoginUser", content))
            {
                var data = response.Content.ReadAsStringAsync().Result;
                if (response.IsSuccessStatusCode)
                {
                    HttpContext.Session.SetString("_layout", "true");
                    TempData["SuccessMessage"] = "Login successfully!";
                    return RedirectToAction("GetAllProducts", "Product");
                }
                else
                {
                    TempData["SuccessMessage2"] = "Login failed!";
                    return RedirectToAction("Login");
                }
            }

            return View();
        }



        public async Task<IActionResult> LogOut()
            {
                return RedirectToAction("Login");
            }



        
    }
}
