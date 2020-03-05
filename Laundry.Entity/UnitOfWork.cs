using Laundry.Entity.Context;
using Laundry.Entity.Repository;
using Laundry.Entity.Repository.Interfaces;

namespace Laundry.Entity
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbLaundry _dbLaundry;
        
        public UnitOfWork(IDbLaundry dbLaundry)
        {
            _dbLaundry = dbLaundry;
        }

        public IRatesRepository RatesRepository => new RatesRepository(_dbLaundry);

        public IServiceRepository ServiceRepository => new ServiceRepository(_dbLaundry);

        public IShirtRepository ShirtRepository => new ShirtRepository(_dbLaundry);

        public ITransactionRepository TransactionRepository => new TransactionRepository(_dbLaundry);

        public ITransactionDetailRepository TransactionDetailRepository => new TransactionDetailRepository(_dbLaundry);
        
        public int Complete()
        {
            return _dbLaundry.SaveChanges();
        }

        public void Dispose()
        {
            _dbLaundry.Dispose();
        }
    }
}
