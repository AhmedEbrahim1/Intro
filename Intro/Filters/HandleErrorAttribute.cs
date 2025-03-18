using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Intro.Filters
{
    //public class HandleErrorAttribute : IFilterMetadata{}
    public class HandleErrorAttribute : Attribute, IExceptionFilter /*Attribute, IExceptionFilter*/
    {
        #region Exception Error Of Content
        //public void OnException(ExceptionContext context)
        //{
        //    //After any Exception Occured

        //    ContentResult contentResult = new ContentResult();
        //    contentResult.Content = "Some Exception Occured";
        //    context.Result = contentResult;
        //}
        #endregion

        #region Exception Error of View
        public void OnException(ExceptionContext context)
        {
            ViewResult viewResult = new ViewResult();
            viewResult.ViewName = "Error";
            context.Result = viewResult;
        }
        #endregion

    }
}
