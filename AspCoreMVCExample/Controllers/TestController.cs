using Microsoft.AspNetCore.Mvc;

namespace AspCoreMVCExample.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
