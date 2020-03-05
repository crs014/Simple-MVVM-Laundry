using Laundry.Entity.Context;
using Laundry.Entity.Models;
using Laundry.Entity.Repository.Interfaces;

namespace Laundry.Entity.Repository
{
    public class TransactionDetailRepository : Repository<TransactionDetail>, ITransactionDetailRepository
    {
        public TransactionDetailRepository(IDbLaundry dbLaundry) : base(dbLaundry)
        {
        }
    }
}
