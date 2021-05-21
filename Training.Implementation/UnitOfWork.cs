using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Training.Interface;
using Training.Domain.Entities;
using System.Linq;

namespace Training.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        //public bool Disposetransaction { get; set; }

        #region Variables

        public TrainingDbContext Context;
        private Dictionary<Type, object> _repositories = new Dictionary<Type, object>();
        IDbContextTransaction _dbTransaction;
        //private readonly IHttpContextAccessor _httpContextAccessor;
        #endregion

        #region ctor
        public UnitOfWork(TrainingDbContext _context)
        {
            //Disposetransaction = false;
            Context = _context;
          //  _httpContextAccessor = httpContextAccessor;
        }

        #endregion
        
        #region Implementation
        public IRepository<T> GetRepository<T>()
        where T : class
        {
            if (this._repositories == null)
            {
                this._repositories = new Dictionary<Type, object>();
            }

            var type = typeof(T);
            if (!this._repositories.ContainsKey(type))
            {
                this._repositories[type] = new Repository<T>(Context);
            }

            return (IRepository<T>)this._repositories[type];
        }
        public async Task<int> SaveChangesAsync()
        {
            try
            {
                var result = await Context.SaveChangesAsync();
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLineIf(!string.IsNullOrEmpty(ex.Message), ex.ToString());
                throw ex;
            }
        }

        //_dbTransaction
        #region _dbTransaction functions
        public async Task BeginTransactionAsync()
        {
            _dbTransaction = await Context.Database.BeginTransactionAsync();
        }
        public async Task CommitTransactionAsync()
        {
            try
            {
                await _dbTransaction.CommitAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLineIf(!string.IsNullOrEmpty(ex.Message), ex.ToString());
            }
        }
        public async Task RollBackTransactionAsync()
        {
            await _dbTransaction.RollbackAsync();
        }
        #endregion

        public ValueTask DisposeAsync()
        {
            ValueTask valueTask = new ValueTask();

            try
            {
                //valueTask = Context.DisposeAsync();

                //TODO: test this try exception when using _dbTransaction
                //if (Disposetransaction)
                //{
                    #region MyRegion
                    //try
                    //{
                    //    return _dbTransaction.DisposeAsync();

                    //}
                    //catch (Exception ex)
                    //{

                    //    //throw;
                    //}

                    #endregion
                //}
            }
            catch (Exception ex)
            {
                Debug.WriteLineIf(!string.IsNullOrEmpty(ex.Message), ex.ToString());
            }

            return valueTask;
        }
        #endregion
    }
}
