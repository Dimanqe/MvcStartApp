using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System;
using MvcStartApp.Models.Db;

namespace MvcStartApp.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private ILoggingRepository _loggingRepository;
        private BlogContext _blogContext;

        ///// <summary>
        /////  Middleware-компонент должен иметь конструктор, принимающий RequestDelegate
        ///// </summary>
        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, ILoggingRepository loggingRepository)
        {
            _loggingRepository = loggingRepository;

            Request request = new()
            {
                Url = $"http://{context.Request.Host.Value + context.Request.Path}",
                Date = DateTime.Now,
                Id = Guid.NewGuid()
            };

            _loggingRepository.AddRequest(request);

            // Передача запроса далее по конвейеру
            await _next.Invoke(context);
        }
    }
}