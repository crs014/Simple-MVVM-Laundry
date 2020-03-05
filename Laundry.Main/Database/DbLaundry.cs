using Laundry.Entity.Context;
using Laundry.Entity.Models;
using System.Data.Entity;

namespace Laundry.Main.Database
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
