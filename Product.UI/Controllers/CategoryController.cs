using Microsoft.AspNetCore.Mvc;

namespace Product.UI.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
