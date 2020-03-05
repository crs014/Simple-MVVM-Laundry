using Laundry.Entity;
using Laundry.Entity.Context;
using Laundry.Testing.DbContextTest;

namespace Laundry.Testing
{
    public abstract class BaseViewModelTest
    {
        private IDbLaundry _dbLaundry;
        protected IUnitOfWork _unitOfWork;

        public BaseViewModelTest()
        {
            _dbLaundry = new DbLaundryTest();
            _unitOfWork = new UnitOfWork(_dbLaundry);
        }
    }
}
