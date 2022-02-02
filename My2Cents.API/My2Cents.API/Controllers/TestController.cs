using Microsoft.AspNetCore.Mvc;

namespace My2Cents.API.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
