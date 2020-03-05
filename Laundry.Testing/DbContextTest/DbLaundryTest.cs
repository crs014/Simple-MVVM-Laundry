using Laundry.Entity.Context;
using Laundry.Entity.Models;
using Laundry.Testing.DbSetTest;
using System;
using System.Collections.ObjectModel;
using System.Data.Entity;

namespace Laundry.Testing.DbContextTest
{
    public class DbLaundryTest : IDbLaundry
    {

        public DbLaundryTest()
        {
            Shirts = new TestDbSet<Shirt>();
            Services = new TestDbSet<Service>();
            Rates = new TestDbSet<Rates>();
            Transactions = new TestDbSet<Transaction>();
            TransactionDetails = new TestDbSet<TransactionDetail>();

            #region generate dummy data Shirts
            Shirts.Add(new Shirt() { Id = 1, Name = "T-Shirt" });
            Shirts.Add(new Shirt() { Id = 2, Name = "Jeans" });
            Shirts.Add(new Shirt() { Id = 3, Name = "Jacket" });
            #endregion

            #region generate dummy data Services
            Services.Add(new Service() { Id = 1, Name = "Wash" });
            Services.Add(new Service() { Id = 2, Name = "Dry" });
            Services.Add(new Service() { Id = 3, Name = "Rinse" });
            #endregion

            #region genereate dummy data Rates 
            Rates.Add(new Rates() { Id = 1, ShirtId = 1, ServiceId = 1, Price = 2000, Unit = "Kg" });
            Rates.Add(new Rates() { Id = 2, ShirtId = 1, ServiceId = 2, Price = 2500, Unit = "Kg" });
            Rates.Add(new Rates() { Id = 3, ShirtId = 1, ServiceId = 3, Price = 3000, Unit = "Kg" });
            #endregion

            #region generate dummy data Transaction 
            Transactions.Add(new Transaction()
            {
                Id = 1,
                Name = "Ucok",
                Address = "Jalan Bakpau",
                Phone = "012345678",
                TransactionDetails = new Collection<TransactionDetail>()
                {
                    new TransactionDetail()
                    {
                        RatesId = 1,
                        TransactionId = 1,
                        Quantity = 2
                    },
                     new TransactionDetail()
                    {
                        RatesId = 2,
                        TransactionId = 1,
                        Quantity = 1
                    }
                }
            });
            Transactions.Add(new Transaction()
            {
                Id = 2,
                Name = "Burhan",
                Address = "Jalan Tak Ada Harapan",
                Phone = "0696969",
                TransactionDetails = new Collection<TransactionDetail>()
                {
                    new TransactionDetail()
                    {
                        RatesId = 1,
                        TransactionId = 2,
                        Quantity = 3
                    },
                    new TransactionDetail()
                    {
                        RatesId = 3,
                        TransactionId = 2,
                        Quantity = 2
                    }
                }
            });
            Transactions.Add(new Transaction()
            {
                Id = 3,
                Name = "Goku",
                Address = "Planet Namek",
                Phone = "88888888",
                TransactionDetails = new Collection<TransactionDetail>()
                {
                    new TransactionDetail()
                    {
                        RatesId = 2,
                        TransactionId = 3,
                        Quantity = 4
                    },
                    new TransactionDetail()
                    {
                        RatesId = 3,
                        TransactionId = 3,
                        Quantity = 3
                    }
                }
            });
            #endregion
        }

        public DbSet<Shirt> Shirts { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Rates> Rates { get; set; }
        public DbSet<Transaction> Transactions { get; set ; }
        public DbSet<TransactionDetail> TransactionDetails { get; set; }

        public void Dispose()
        {
           
        }

        public int SaveChanges()
        {
            return 0;
        }

        public DbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            Type listType = typeof(TEntity);

            if (listType == typeof(Shirt)) 
            { 
                return Shirts as DbSet<TEntity>;
            }
            else if(listType == typeof(Service))
            {
                return Services as DbSet<TEntity>;
            }
            else if(listType == typeof(Rates))
            {
                return Rates as DbSet<TEntity>;
            }
            else if(listType == typeof(Transaction))
            {
                return Transactions as DbSet<TEntity>;
            }
            else if(listType == typeof(TransactionDetail))
            {
                return TransactionDetails as DbSet<TEntity>;
            }
            else
            {
                throw new Exception();
            }

        }
    }
}
