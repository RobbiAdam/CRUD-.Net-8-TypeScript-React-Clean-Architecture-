using Employees.Contract.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace dotNet.React.Handlers
{
    public class ExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            var problemDetails = CreateProblemDetails(exception);
            httpContext.Response.StatusCode = problemDetails.Status ?? StatusCodes.Status500InternalServerError;

            await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

            return true;
        }

        private static ProblemDetails CreateProblemDetails(Exception exception)
        {
            ProblemDetails problemDetails = exception switch
            {                
                 NotFoundException => CreateProblemDetails(StatusCodes.Status404NotFound,
                 "Not Found", exception.Message),
                CustomValidationException => CreateProblemDetails(StatusCodes.Status400BadRequest,
                "Validation Error", "One or more validation errors occurred"),
                _ => CreateProblemDetails(StatusCodes.Status500InternalServerError,
                "Internal Server Error", "An error occurred while processing your request")
            };

            if(exception is CustomValidationException customValidationException)
            {
                problemDetails.Extensions["errors"] = customValidationException.ValidationErrors;

            }
            return problemDetails;

        }

        private static ProblemDetails CreateProblemDetails(int status, string title, string detail)
        {
            return new ProblemDetails
            {
                Status = status,
                Title = title,
                Detail = detail
            };
        }
    }
}
