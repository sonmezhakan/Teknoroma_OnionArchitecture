using Teknoroma.Application.Repositories;
using Teknoroma.Domain.Entities;
using Teknoroma.Persistence.Context;

namespace Teknoroma.Persistence.Repositories
{
    public class StockRepository : BaseRepository<Stock>, IStockRepository
    {
        public StockRepository(TeknoromaContext context) : base(context)
        {

        }

    }
}
