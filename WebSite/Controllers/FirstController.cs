using Microsoft.AspNetCore.Mvc;

namespace WebSite.Controllers
{
    public class FirstController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
