using Logbook.ExceptionHandler.Exceptions;
using System.Data.Common;
using System.Text.Json;

namespace Logbook.ExceptionHandler
{
    public class CustomExceptionHandler
    {
            private readonly RequestDelegate _next;
            private readonly ILogger<CustomExceptionHandler> _logger;

            private Dictionary<Type, (int StatusCode, string Message)> exceptionDictionary = new Dictionary<Type, (int, string)>
            {
                { typeof(UnauthorizedAccessException), (401, "Unauthorized access") },
                { typeof(UserNotFoundException), (500, "An error occured while processing your request") },
                { typeof(BadHttpRequestException), (400, "Bad HTTP Request") },
                { typeof(UserException), (500, "The requested operation could not be completed") },
                { typeof(DropzoneException), (500, "An error occured while processing your Dropzone request")},
                { typeof(AircraftException), (500, "An error occured while processing your Aircraft request")},
                { typeof(EquipmentException), (500, "An error occured while processing your Equipment request")},
                { typeof(JumpException), (500, "An error occured while processing your Jump request")},
                { typeof(WeatherException), (500, "An error occured while processing your Weather request")},
                { typeof(DbException), (500, "Internal Server Error. Please try again later")},
                { typeof(ArgumentNullException), (400, "Bad Request: Check for a null argument")},
                { typeof(ArgumentOutOfRangeException), (400, "Arguement out of range")},
                { typeof(TimeoutException), (408, "Request Timeout")}
            };

            public CustomExceptionHandler(RequestDelegate next, ILogger<CustomExceptionHandler> logger)
            {
                _next = next;
                _logger = logger;
            }

            public async Task InvokeAsync(HttpContext context)
            {
                try
                {
                    await _next(context);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "An error occurred while processing the request.");
                    await HandleExceptionAsync(context, ex);
                }
            }

            private async Task HandleExceptionAsync(HttpContext context, Exception exception)
            {
                context.Response.ContentType = "text/plain";
                var statusCodeAndMessage = exceptionDictionary.ContainsKey(exception.GetType()) ? exceptionDictionary[exception.GetType()] : (500, "An unexpected error occurred.");
                context.Response.StatusCode = statusCodeAndMessage.Item1;

                var errorDetails = new ErrorDetails
                {
                    StatusCode = statusCodeAndMessage.Item1,
                    Message = statusCodeAndMessage.Item2
                };

                await WriteErrorDetailsToResponse(context.Response, errorDetails);
            }

            private static async Task WriteErrorDetailsToResponse(HttpResponse response, ErrorDetails errorDetails)
            {
                string jsonString = JsonSerializer.Serialize(errorDetails);
                await response.WriteAsync(jsonString);
            }
    }

}

