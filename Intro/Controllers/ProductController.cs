using Microsoft.AspNetCore.Mvc;

namespace Intro.Controllers
{
    public class ProductController : Controller
    {
        //string ==> ContentResult ==> Content()
        //HTML ==> ViewResult ==> View()
        //JSON ==> JsonResult ==> JSON()
        //JavaScript ==> JavaScriptResult ==> Javascript()
        //Facebook ==> RedirectResult ==> Redirect()
        //File ==> FileResult ==> File()


        //Product/GetMessage
        //public string GetMessage()
        //{
        //    return "Hello from My First Method";
        //}

        //public ContentResult GetMessage()
        //{
        //    //declare ContentResult Object
        //    //set data 
        //    //Return Object
        //    ContentResult result = new ContentResult();
        //    result.Content = "Hello from My First Method";
        //    return result;
        //}



        public ViewResult GetView()
        {
            //declare
            ViewResult result = new ViewResult();
            //set
            result.ViewName = "ShowView";
            //Search of this view in two places ==> (views folder , 

            //return 
            return result;

        }


        //public ViewResult GetMix(int id)
        //{
        //    //if (id % 2 == 0)
        //    //{
        //    //    ContentResult result = new ContentResult();
        //    //    result.Content = "TEST";
        //    //    return result;
        //    //}
        //    //else
        //    //{
        //        ViewResult result = new ViewResult();
        //        result.ViewName = "ShowView";
        //        return result;
        //    //}

        //}


        //public IActionResult GetMix(int id)
        //{

        //    if (id % 2 == 0)
        //    {
        //        ContentResult result = new ContentResult();
        //        result.Content = "TEST";
        //        return result;
        //    }
        //    else
        //    {
        //        ViewResult result = new ViewResult();
        //        result.ViewName = "ShowView";
        //        return result;
        //    }

        //}


        public IActionResult GetMix(int id)
        {

            if (id % 2 == 0)
            {
                return Content("TEST");
            }
            else
            {
                return View("ShowView");
            }

        }

        //Response types to action methods controllers

        public IActionResult Index()
        {
            return View();
        }
    }
}
