using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Teknoroma.Application.Exceptions.Extensions;
using Teknoroma.Application.Exceptions.HttpProblemDetails;
using Teknoroma.Application.Exceptions.Types;
using ValidationProblemDetails = Teknoroma.Application.Exceptions.HttpProblemDetails.ValidationProblemDetails;

namespace Teknoroma.Application.Exceptions.Handlers
{
    public class HttpExceptionHandler : ExceptionHandler
    {
        private HttpResponse? _response;

        public HttpResponse Response 
        {
            get => _response ?? throw new ArgumentException(nameof(_response));

            set => _response = value;
        }
        protected override Task HandleException(BusinessException businessException)
        {
            Response.StatusCode = StatusCodes.Status400BadRequest;
            string details = new BusinessProblemDetails(businessException.Message).AsJson();
            return Response.WriteAsync(details);
        }

        protected override Task HandleException(Exception exception)
        {
            Response.StatusCode = StatusCodes.Status500InternalServerError;
            string details = new BusinessProblemDetails(exception.Message).AsJson();
            return Response.WriteAsync(details);
        }

		protected override Task HandleException(ValidationException validationException)
		{
			Response.StatusCode = StatusCodes.Status400BadRequest;
			string details = new ValidationProblemDetails(validationException.Message).AsJson();
			return Response.WriteAsync(details);
		}
	}
}
