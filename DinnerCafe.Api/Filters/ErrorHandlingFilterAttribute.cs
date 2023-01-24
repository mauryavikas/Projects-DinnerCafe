using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace DinnerCafe.Api.Filters
{
    public class ErrorHandlingFilterAttribute : ExceptionFilterAttribute
    {
        //public override void OnException(ExceptionContext context)
        //{

        //    var Exception=context.Exception;

        //    context.Result = new ObjectResult(new { Error = "An Error occur while processing your request" })
        //    {
        //        StatusCode = 500
        //    };
        //    context.ExceptionHandled = true;
        //}

        // Global Exception handeling using ProblemDetailMethod

        public override void OnException(ExceptionContext context)
        {

            var Exception = context.Exception;

            var ProblemDetails = new ProblemDetails
            {
                Title = "An Error occur while processing your request",
                Status = (int?)HttpStatusCode.InternalServerError,
            };

            context.Result = new ObjectResult(ProblemDetails);
            context.ExceptionHandled = true;
        }
    }
}
