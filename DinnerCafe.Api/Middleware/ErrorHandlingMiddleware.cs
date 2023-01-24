using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DinnerCafe.Api.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext Context)
        {
            try
            {
                await _next(Context);
            }
            catch(Exception ex)
            {
                await HandelExceptionAsync(Context, ex);
            }
        }

        public Task HandelExceptionAsync( HttpContext Context , Exception Ex)
        {
            Context.Response.StatusCode =(int)HttpStatusCode.InternalServerError; // 500 if unexpexted 
            Context.Response.ContentType = "application/json";
            var Error = new {Error = "An Error occur while processing your request" };
            var result = JsonSerializer.Serialize(Error);
            return Context.Response.WriteAsync(result);
        }
    }
}
