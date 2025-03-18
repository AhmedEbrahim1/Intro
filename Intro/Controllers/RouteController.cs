using Microsoft.AspNetCore.Mvc;

namespace Intro.Controllers
{
    public class RouteController : Controller
    {
        public IActionResult Index(string xyz, int id)
        {
            return Content($"xyz = {xyz}");
        }

        public IActionResult TestFourSegment(string name, int age)
        {
            return Content($"age = {age}");
        }
    }
}
