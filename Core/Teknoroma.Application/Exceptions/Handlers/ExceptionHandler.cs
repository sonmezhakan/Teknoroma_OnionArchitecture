using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoroma.Application.Exceptions.Types;

namespace Teknoroma.Application.Exceptions.Handlers
{
    public abstract class ExceptionHandler
    {
        public Task HandleExceptionAsync(Exception exception)=>
            exception switch
            {
                //Gelen exception bussinesException ise bunu çalıştıracak
                BusinessException businessException => HandleException(businessException),
                //Gelen exception ValidationException ise bunu çalıştıracak
                ValidationException validationException => HandleException(validationException),
                _ => HandleException(exception)//her ikisi de değil ise bunu çalıştıracak
            };
        
        protected abstract Task HandleException(BusinessException businessException);

		protected abstract Task HandleException(ValidationException validationException);

		protected abstract Task HandleException(Exception exception);
    }
}
