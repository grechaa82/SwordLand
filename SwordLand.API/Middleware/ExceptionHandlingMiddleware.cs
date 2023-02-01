using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace SwordLand.API.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try 
            {
                await _next(context);
            }
            catch (ArgumentNullException exception)
            {
                var message = "This instance was not found";
                await HandleExceptionAsync(context, exception, message);
            }
            catch (Exception exception)
            {
                var message = "Found exception";
                await HandleExceptionAsync(context, exception, message);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception, string message)
        {
            var code = HttpStatusCode.InternalServerError;
            var statusCode = HttpStatusCode.InternalServerError;
            var result = JsonSerializer.Serialize(new 
            { 
                StatusCode = statusCode,
                Error = message,
                ErrorMessage = exception.Message,
            });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }
    }
}
