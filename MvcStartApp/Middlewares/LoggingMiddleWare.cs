﻿using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using MvcStartApp.Models.Db;
using Microsoft.Extensions.DependencyInjection;

namespace CoreStartApp.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        private void LogConsole(HttpContext context)
        {
            Console.WriteLine($"[{DateTime.Now}]: New request to http://{context.Request.Host.Value + context.Request.Path}");
        }

        private async Task LogFile(HttpContext context)
        {
            string logMessage = $"[{DateTime.Now}]: New request to http://{context.Request.Host.Value + context.Request.Path}{Environment.NewLine}";
            string logFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Logs", "RequestLog.txt");

            await File.AppendAllTextAsync(logFilePath, logMessage);
        }

        public async Task InvokeAsync(HttpContext context)
        {
            //Access IBlogRepository using HttpContext.RequestServices
           //var blogRepository = context.RequestServices.GetRequiredService<IBlogRepository>();

           // string userAgent = context.Request.Headers["User-Agent"][0];
           // var newUser = new User
           // {
           //     Id = Guid.NewGuid(),
           //     JoinDate = DateTime.Now,
           //     FirstName = userAgent,
           //     LastName = userAgent,
           // };

           // // Use blogRepository to add a new user
           // await blogRepository.AddUser(newUser);

            //Log information
            LogConsole(context);
            await LogFile(context);

            // Continue processing the request pipeline
            await _next.Invoke(context);
        }


    }
}
