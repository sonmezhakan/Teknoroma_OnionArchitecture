using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Teknoroma.Application.Exceptions.Types;

namespace Teknoroma.Application.Exceptions.HttpProblemDetails
{
	public class ValidationProblemDetails:ProblemDetails
	{
        public ValidationProblemDetails(string detail)
		{
			Title = "Validation error(s)";
			Detail = detail;
			Status = StatusCodes.Status400BadRequest;
			Type = "";
		}
	}
}
