using Laundry.Entity.Context;
using Laundry.Entity.Models;
using Laundry.Entity.Repository.Interfaces;

namespace Laundry.Entity.Repository
{
    public class ShirtRepository : Repository<Shirt>, IShirtRepository
    {
        public ShirtRepository(IDbLaundry dbLaundry) : base(dbLaundry)
        {

        }
    }
}
