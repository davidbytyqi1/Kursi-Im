
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KursiIm.Domain.SeedWork;
using KursiIm.SharedModel.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace KursiImSource.Helpers
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class ValidatorActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!filterContext.ModelState.IsValid)
            {
                filterContext.Result = new CustomBadRequestResult((int)PublicResultStatusCodes.ModelIsNotValid, 200);
            }
        }

        //public override 

        public override void OnActionExecuted(ActionExecutedContext filterContext)
      {

        }
    }

    public class CustomBadRequestError
    {
        public int Status { get; }

        public CustomBadRequestError(int message)
        {
            Status = message;
        }
    }

    public class CustomBadRequestResult : JsonResult
    {
        public CustomBadRequestResult(int message, int statusCode) : base(new CustomBadRequestError(message))
        {
            StatusCode = statusCode;
        }
    }
}
