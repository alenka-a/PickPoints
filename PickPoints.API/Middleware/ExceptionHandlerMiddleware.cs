using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using PickPoints.Core.Exceptions;
using System.Net;
using Microsoft.Extensions.Logging;

namespace PickPoints.API.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private const string JsonContentType = "application/json";
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;

        public ExceptionHandlerMiddleware(
            RequestDelegate next,
            ILogger<ExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;            
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await InvokeAsync(context, ex, _logger);
            }
        }

        private async Task InvokeAsync(
            HttpContext context,
            Exception exception,
            ILogger<ExceptionHandlerMiddleware> logger)
        {
            var statusCode = GetStatusCode(exception);

            if (statusCode < 500)
                _logger.LogWarning(exception, exception.Message);
            else
                _logger.LogError(exception, "Unhandled Exception");

            context.Response.StatusCode = statusCode;                        
            context.Response.ContentType = JsonContentType;
            var message = exception.Message;
            await context.Response.WriteAsync(message);
        }
        private static int GetStatusCode(Exception exception)
        {
            var httpStatusCode = exception switch
            {
                NotFoundException _ => (int)HttpStatusCode.NotFound,
                ForbiddenOperationException _ => (int)HttpStatusCode.Forbidden,
                ValidationException _ => (int)HttpStatusCode.BadRequest,
                FluentValidation.ValidationException _ => (int)HttpStatusCode.BadRequest,
                _ => (int)HttpStatusCode.InternalServerError,
            };
            return httpStatusCode;
        }
    }    
}
