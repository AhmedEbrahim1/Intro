using Microsoft.AspNetCore.Mvc;

namespace Intro.Controllers
{
    public class PassDataController : Controller
    {
        string message = "No Content";
        public IActionResult First()
        {
            message = "Hello From First";
            TempData["msg"] = message;
            return Content($"Request1 : {message}");
        }
        public IActionResult Second()
        {
            string n = message;
            //n = TempData["msg"]?.ToString();

            //if (TempData.ContainsKey("msg"))
            //{
            //    message = TempData["msg"].ToString();
            //    TempData.Keep("msg");
            //}

            if (TempData.ContainsKey("msg"))
            {
                message = TempData.Peek("msg").ToString();
            }

            return Content("Request2");
        }


        public IActionResult SetSession()
        {
            HttpContext.Session.SetString("name", "ahmed");
            HttpContext.Session.SetInt32("Salary", 1000);
            return Content("Session Saved");
        }

        public IActionResult GetSession()
        {
            string n = HttpContext.Session.GetString("name");
            int s = HttpContext.Session.GetInt32("Salary").Value;
            //ViewBag.Name = HttpContext.Session.GetString("name"); //leha shakl tany f el view 
            return Content("Session Saved");
        }

        public IActionResult SetCookie()
        {
            //my app added it and saved on the server
            //Session cookie
            HttpContext.Response.Cookies.Append("name", "Ramy");//Expired After 20 M


            //Presistent cookie
            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddDays(1);
            HttpContext.Response.Cookies.Append("color", "red",options);
            return Content("Session Saved");
        }

        public IActionResult GetCookie()
        {
            //my app added it and saved on the server
            string name = HttpContext.Request.Cookies["name"];
            string color = HttpContext.Request.Cookies["color"];
            return Content($"Get cookies name ={name} , color = {color}");
        }
    }
}
