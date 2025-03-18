using Intro.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Intro.Controllers
{
    public class SerivcesController : Controller
    {
        private readonly IDepartmentRepository _departmentRepository;



        public IActionResult TESTAuth()
        {
            //Claims 
            if (User.Identity.IsAuthenticated)//////
            {

                var idClaim = User.Claims.FirstOrDefault(e => e.Type == ClaimTypes.NameIdentifier);
                var addressClaim = User.Claims.FirstOrDefault(e => e.Type == "userAddress");

                return Content(idClaim.Value);
            }
            else
            {
                return Content("Not Auth");
            }
        }

        public SerivcesController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        public IActionResult Index()
        {
            ViewBag.Haschode = _departmentRepository.GetHashCode();
            return View();
        }
    }
}
