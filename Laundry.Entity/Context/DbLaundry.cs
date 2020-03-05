using Laundry.Entity.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laundry.Entity.Context
{
    public class DbLaundry : DbContext, IDbLaundry
    {
        public DbSet<Shirt> Shirts { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Rates> Rates { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<TransactionDetail> TransactionDetails { get; set; }
    }
}
