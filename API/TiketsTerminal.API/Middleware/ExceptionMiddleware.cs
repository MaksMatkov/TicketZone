using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TiketsTerminal.API.Middleware.Models;
using TiketsTerminal.BusinessLogic.CustomeExceptions;

namespace TiketsTerminal.API.Middleware
{
    public class ExceptionMiddleware
    {
        public readonly RequestDelegate _next;
        public readonly ILogger<ExceptionMiddleware> _logger;
        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _logger = logger;
            _next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch(ArgumentNullException ex)
            {
                httpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                _logger.LogError($"NotFound: {ex}");
                await HandleExceptionAsync(httpContext, ex.Message);
            }
            catch(NotFoundDataException ex)
            {
                httpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                _logger.LogError($"NotFound: {ex}");
                await HandleExceptionAsync(httpContext, ex.Message);
            }
            catch(NotUniqueException ex)
            {
                httpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                _logger.LogError($"NotUniqueException: {ex}");
                await HandleExceptionAsync(httpContext, ex.Message);
            }
            catch(NotAllowException ex)
            {
                httpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                _logger.LogError($"NotAllowException: {ex}");
                await HandleExceptionAsync(httpContext, ex.Message);
            }
            catch(NotApprovedException ex)
            {
                httpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                _logger.LogError($"NotApprovedException UserID = [{ex.UserId}]: {ex}");
                await HandleExceptionAsync(httpContext, ex.Message);
            }
            catch (Exception ex)
            {
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                _logger.LogError($"InternalServerError: {ex}");
                await HandleExceptionAsync(httpContext, ex.Message);
            }

        }
        private async Task HandleExceptionAsync(HttpContext context, string msg)
        {
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(new ErrorDetails()
            {
                statusCode = context.Response.StatusCode,
                errorMessage = msg
            }.ToString());
        }
    }
}
