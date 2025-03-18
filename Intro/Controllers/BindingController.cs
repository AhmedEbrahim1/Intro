using Intro.Models;
using Microsoft.AspNetCore.Mvc;

namespace Intro.Controllers
{
    public class BindingController : Controller
    {
        //Primnitive , Collections , user Defiend 
        //Url ==> http://localhost:1235/Binding/TESTPrimnitive?age=22&name=ALI ==> queryString
        public IActionResult TESTPrimnitive(string[] color)
        {
            return View();
        }

        //Url==> http://localhost:1235/Binding/TESTCollections?phone[Ahmed]=123&phone[Ali]=567
        public IActionResult TESTCollections(Dictionary<string, int> phone)
        {
            return View();
        }
        //Url ==> http://localhost:1235/Binding/TESTCustomObj?department.Id=1,department.Name=Ahmed,department.ManagerName=Ali
        //Url ==> http://localhost:1235/Binding/TESTCustomObj?Employees[0].Nam=Ahmed
        public IActionResult TESTCustomObj(Department department)
        {
            return Ok("OK");
        }

    }
}
