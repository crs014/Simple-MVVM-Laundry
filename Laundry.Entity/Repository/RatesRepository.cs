using Laundry.Entity.Context;
using Laundry.Entity.Models;
using Laundry.Entity.Repository.Interfaces;

namespace Laundry.Entity.Repository
{
    public class RatesRepository : Repository<Rates>, IRatesRepository
    {
        public RatesRepository(IDbLaundry dbLaundry) : base(dbLaundry)
        {

        }
    }
}
