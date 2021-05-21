using System;
using System.Threading.Tasks;

namespace Training.Interface
{
    public interface IUnitOfWork :  IAsyncDisposable
    {
       // bool Disposetransaction { get; set; }

        IRepository<T> GetRepository<T>() where T : class;
        Task<int> SaveChangesAsync();
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollBackTransactionAsync();
    }
}
