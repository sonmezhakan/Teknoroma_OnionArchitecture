using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teknoroma.Application.Exceptions.Types
{
	public class ValidationException:Exception
	{
		public IEnumerable<string> Errors { get; }

		public ValidationException()
			: base()
		{
			Errors = Array.Empty<string>();
		}

		public ValidationException(string? message)
			: base(message)
		{
			Errors = Array.Empty<string>();
		}

		public ValidationException(string? message, Exception? innerException)
			: base(message, innerException)
		{
			Errors = Array.Empty<string>();
		}

		public ValidationException(IEnumerable<string> errors)
			: base(BuildErrorMessage(errors))
		{
			Errors = errors;
		}

		private static string BuildErrorMessage(IEnumerable<string> errors)
		{
			return $"Validation failed: {string.Join(Environment.NewLine, errors)}";
		}
	}
}
