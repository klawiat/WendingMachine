using WendingMachine.Data.Entities;
using WendingMachine.Infrastructure.Interfaces;

namespace WendingMachine.Infrastructure.Repositories
{
    public class CoinRepository : BaseRepository<Coin>, ICoinRepository
    {
        public CoinRepository(WendingDbContext context) : base(context)
        {
        }
    }
}
