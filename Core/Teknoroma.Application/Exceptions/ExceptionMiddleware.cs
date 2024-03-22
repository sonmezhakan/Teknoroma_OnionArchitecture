using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoroma.Application.Exceptions.Handlers;

namespace Teknoroma.Application.Exceptions
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly HttpExceptionHandler _httpExceptionHandler;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
            _httpExceptionHandler = new HttpExceptionHandler();
        }
        //Kodlar Invoke metotu içerisinden geçerek hata kontrülü sağlanır. Eğer bu yöntemi uygulamasaydık. Tüm kodlarımız için ayrı ayrı try catch yapısı kurmak zorunda kalırdık.
        public async Task Invoke(HttpContext context)
        {
            try
            {
                //Gelen isteğin çalıştır.
                await _next(context);
            }
            catch (Exception exception)
            {
                await HandleExceptionAsync(context.Response, exception);
            }
        }

        private Task HandleExceptionAsync(HttpResponse response,Exception exception)
        {
            response.ContentType = "application/json";
            _httpExceptionHandler.Response = response;
            return _httpExceptionHandler.HandleExceptionAsync(exception);
        }
    }
}
