using Teknoroma.Application.Services.Repositories;
using Teknoroma.Domain.Entities;
using Teknoroma.Persistence.Context;

namespace Teknoroma.Persistence.Repositories
{
    public class StockInputRepository : BaseRepository<StockInput>, IStockInputRepository
    {
        public StockInputRepository(TeknoromaContext context) : base(context)
        {
        }
    }
}
