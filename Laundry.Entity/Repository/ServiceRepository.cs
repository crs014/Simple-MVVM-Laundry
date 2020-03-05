using Laundry.Entity.Context;
using Laundry.Entity.Models;
using Laundry.Entity.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laundry.Entity.Repository
{
    public class ServiceRepository : Repository<Service>, IServiceRepository
    {
        public ServiceRepository(IDbLaundry dbLaundry) : base(dbLaundry)
        {

        }
    }
}
