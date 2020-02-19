using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace WEB_API_Task.Middleware
{
    public class AuthMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Headers["Authorization"] == "langit biru")
            {
                var startTime = DateTime.Now;
                await _next(context);
                var duration = DateTime.Now - startTime;
                Log1.SaveAllLog
                    (context.Response.StatusCode.ToString(),
                    context.Request.Method.ToString(),
                    context.Request.Path.ToString(),
                    context.Request.Host.ToString(),
                    duration.TotalMilliseconds.ToString());
            }

            var startTimeNotAuth = DateTime.Now;
            var text = "Not Authorize";
            var data = System.Text.Encoding.UTF8.GetBytes(text);
            await context.Response.Body.WriteAsync(data, 0, data.Length);
            var durationNotAuth = DateTime.Now - startTimeNotAuth;
            Log1.SaveAllLog
                    (context.Response.StatusCode.ToString(),
                    context.Request.Method.ToString(),
                    context.Request.Path.ToString(),
                    context.Request.Host.ToString(),
                    durationNotAuth.TotalMilliseconds.ToString());
        }

    }

    public static class AuthMiddlewareExtension
    {
        public static IApplicationBuilder UseAuthMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AuthMiddleware>();
        }
    }

   public class Log1
    {
        public static void SaveAllLog(string statusCode, string HTTPMethods, string RequestPath, string RequestHost, string runTime)
        {
            File.AppendAllText(@"/Users/user/Projects/WEB_API_Task/App.log",
                $"{DateTime.Now} Started {HTTPMethods} {RequestPath} for {RequestHost} \n");
            File.AppendAllText(@"/Users/user/Projects/WEB_API_Task/App.log",
                $"{DateTime.Now} Completed {statusCode} {RequestPath} in {runTime} ms \n");
        }
    }
}
