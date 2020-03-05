using Laundry.Entity.Models;
using System;
using System.Data.Entity;

namespace Laundry.Entity.Context
{
    public interface IDbLaundry : IDisposable
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbSet<Shirt> Shirts { get; set; }

        DbSet<Service> Services { get; set; }

        DbSet<Rates> Rates { get; set; }

        DbSet<Transaction> Transactions { get; set; }

        DbSet<TransactionDetail> TransactionDetails { get; set; }

        int SaveChanges();
    }
}
