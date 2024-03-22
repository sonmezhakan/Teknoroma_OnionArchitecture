using MediatR;
using System.Transactions;

namespace Teknoroma.Application.Pipelines.Transaction
{
    public class TransactionScopeBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>, ITransactionalRequest
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            using TransactionScope transactionScope = new(TransactionScopeAsyncFlowOption.Enabled);
            TResponse response;
            try
            {
                response = await next();
                transactionScope.Complete();//Eğer işlem başarılı ise işlemi tamamla.
            }
            catch (Exception)
            {
                transactionScope.Dispose();//Eğer işlem başarısız ise işlemi geri al.
                throw;
            }
            return response;
        }
    }
}
