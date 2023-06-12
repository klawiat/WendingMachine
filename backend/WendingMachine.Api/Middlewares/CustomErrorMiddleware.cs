using FluentValidation;
using Microsoft.Data.SqlClient;
using System.Net;
using System.Text.Json;

namespace WendingMachine.Api.Middlewares
{
    public class CustomErrorMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        public CustomErrorMiddleware(RequestDelegate next, ILoggerFactory factory)
        {
            _next = next;
            _logger = factory.CreateLogger<CustomErrorMiddleware>();
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                _next?.Invoke(context);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Ошибка произошла по маршруту: {context.Request.Path.Value}");
                await ExceptionHandler(context, ex);
            }
        }
        public async Task ExceptionHandler(HttpContext context, Exception exception)
        {
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
            string responce = string.Empty;
            switch (exception)
            {
                case ArgumentNullException:
                    statusCode = HttpStatusCode.BadRequest;
                    responce = JsonSerializer.Serialize(new { message = "Необходимо заполнить все поля" });
                    break;
                case ValidationException ex:
                    statusCode = HttpStatusCode.BadRequest;
                    responce = JsonSerializer.Serialize(ex.Errors.Select(error => new { property = error.PropertyName, message = error.ErrorMessage }));
                    break;
                case SqlException ex:
                    statusCode = HttpStatusCode.BadRequest;
                    responce = JsonSerializer.Serialize(new { message = "Неверно заполнены поля" });
                    break;
                case Exception:
                    statusCode = HttpStatusCode.InternalServerError;
                    responce = JsonSerializer.Serialize(new { message = "Необработанная ошибка!" });
                    break;
            }
            context.Response.StatusCode = (int)statusCode;
            await context.Response.WriteAsJsonAsync(responce);
        }
    }
    public static class ErrorExtention
    {
        public static void UseCustomExceptionHandler(this WebApplication app)
        {
            app.UseMiddleware<CustomErrorMiddleware>();
        }
    }
}
