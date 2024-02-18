using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoroma.Application.Exceptions.Types;
using ValidationException = Teknoroma.Application.Exceptions.Types.ValidationException;

namespace Teknoroma.Application.Pipelines.Validation
{
	public class RequestValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
		where TRequest : IRequest<TResponse>
	{
		private readonly IEnumerable<IValidator<TRequest>> _validators;

		public RequestValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
		{
			_validators = validators;
		}

		public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
		{
			ValidationContext<object> context = new(request);

			IEnumerable<string> errors = _validators
	   .Select(validator => validator.Validate(context))
	   .SelectMany(result => result.Errors)
	   .Where(failure => failure != null)
	   .Select(e => e.ErrorMessage)
	   .ToList();

			if (errors.Any())
				throw new ValidationException(string.Join(Environment.NewLine, errors));

			TResponse response = await next();
			return response;
		}
	}
}
