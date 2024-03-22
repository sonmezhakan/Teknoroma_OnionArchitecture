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
            //_response var ise döndür yok ise hatayı oluştur ve döndür
            get => _response ?? throw new ArgumentException(nameof(_response));

            set => _response = value;
        }
        protected override Task HandleException(BusinessException businessException)
        {
            Response.StatusCode = StatusCodes.Status400BadRequest;
            string details = new BusinessProblemDetails(businessException.Message).AsJson();//Normalde ProblemDetails classından iherit ederek burada da işlemler gerçekleştirebilirdik. Fakat ilerleyen aşamalarda geri döndürülen hataya ekstra bilgiler eklemek istersek yani özelleştirmek istersek diye farklı bir class içerisinde bu işlemler yapıldı.Hatayı geriye json formatında döndürebilmek için Extensions metot oluşturup orada json formatına dönüştürebilmek için gerekli kod yazılarak burada kullanılıyor.
            
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
