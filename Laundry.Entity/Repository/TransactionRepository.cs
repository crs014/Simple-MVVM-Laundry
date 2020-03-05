using Laundry.Entity.Context;
using Laundry.Entity.Models;
using Laundry.Entity.Repository.Interfaces;

namespace Laundry.Entity.Repository
{
    public class TransactionRepository : Repository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(IDbLaundry dbLaundry) : base(dbLaundry)
        {

        }
    }
}
