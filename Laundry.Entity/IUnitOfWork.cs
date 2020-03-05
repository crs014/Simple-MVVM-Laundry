using Laundry.Entity.Repository.Interfaces;
using System;

namespace Laundry.Entity
{
    public interface IUnitOfWork : IDisposable
    {
        int Complete();

        IRatesRepository RatesRepository { get; }

        IServiceRepository ServiceRepository { get; }

        IShirtRepository ShirtRepository { get; }

        ITransactionRepository TransactionRepository { get; }

        ITransactionDetailRepository TransactionDetailRepository { get; }
    }
}
