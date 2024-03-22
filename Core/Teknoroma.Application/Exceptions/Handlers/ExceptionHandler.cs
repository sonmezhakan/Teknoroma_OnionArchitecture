using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoroma.Application.Exceptions.Types;

namespace Teknoroma.Application.Exceptions.Handlers
{
    //Gelen hataları handle(tetikleyecek) edecek yer
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
        
        //bu classın ve metotların abstract olmasının nedeni bu classı inherit edecek classların aşağıdaki metotları doldurması gerektiği zorunlu olması içindir.
        protected abstract Task HandleException(BusinessException businessException);

		protected abstract Task HandleException(ValidationException validationException);

		protected abstract Task HandleException(Exception exception);
    }
}
