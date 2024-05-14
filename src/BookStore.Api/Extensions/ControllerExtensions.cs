using Microsoft.AspNetCore.Mvc;

namespace BookStore.Api.Extensions
{
    internal static class ControllerExtensions
    {
        public static IActionResult ToProblemDetails(
            this ControllerBase controller,
            Dictionary<string, string[]> errors,
            string detail = null!,
            int statusCode = StatusCodes.Status400BadRequest)
        {
            var problemDetails = new ValidationProblemDetails(errors)
            {
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
                Title = "One or more validation errors occurred.",
                Status = statusCode,
                Detail = detail ?? "See the errors property for details.",
                Instance = controller.HttpContext?.Request.Path
            };

            return new BadRequestObjectResult(problemDetails)
            {
                ContentTypes = { "application/problem+json" }
            };
        }
    }
}
