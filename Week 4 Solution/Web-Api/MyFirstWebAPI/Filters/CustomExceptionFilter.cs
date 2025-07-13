using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text.Json;

namespace MyFirstWebAPI.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var exception = context.Exception;
            
            var logEntry = new
            {
                TimeStamp = DateTime.Now,
                Message = exception.Message,
                StackTrace = exception.StackTrace,
                Source = exception.Source,
                InnerException = exception.InnerException?.Message
            };
            
            var logJson = JsonSerializer.Serialize(logEntry, new JsonSerializerOptions { WriteIndented = true });
            try
            {
                var logPath = Path.Combine(Directory.GetCurrentDirectory(), "exceptions.log");
                File.AppendAllText(logPath, logJson + Environment.NewLine + "---" + Environment.NewLine);
            }
            catch
            {
                // Ignore logging errors
            }
            
            context.Result = new ObjectResult(new
            {
                error = "An internal server error occurred",
                message = exception.Message,
                timestamp = DateTime.Now
            })
            {
                StatusCode = 500
            };
            
            context.ExceptionHandled = true;
        }
    }
}