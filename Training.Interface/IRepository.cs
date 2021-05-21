using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Training.Core;
using Training.Domain.Entities;
using Training.Domain.Enums;

namespace Training.Interface
{
    public interface IRepository<T> : IRepositoryReadOnly<T> where T : class
    {
        #region Get Data

        Task<(int Total, IQueryable<T> EntityList)> GetAllAsync(IQueryable<T> query=null, int countForSkip=0, int pageSize=0);
        Task<T> GetByIdAsync(long id);
        long GetCount();
        Task<(int total, IQueryable<T> List)> GetByConditionAsync(RepositoryFilterDTO<T> repositoryFilterDTO, params Expression<Func<T, object>>[] includes);
       // Task<(int total, IQueryable<T> List)> GetByConditionAsync(Expression<Func<T, bool>> expression, string order = "", int pageIndex = 0, int pageSize = 0, string Includes = "", bool includeUser = true);
        //Task<(int total, IQueryable<T> List)> GetByConditionAsync(Expression<Func<T, bool>> expression, FilterDTO filterModel);
       // Task<(int total, IQueryable<T> List)> GetByConditionAsync(Expression<Func<T, bool>> expression, string order, int pageIndex, int pageSize, bool includeUser = true, bool withTraking = false, params Expression<Func<T, object>>[] includesPara);

        Task<(int total, IQueryable<T> List)> GetByConditionAsync(Expression<Func<T, bool>> expression,
            Expression<Func<T, DateTime?>> order, OrderTypeEnum OrderType, int pageIndex, int pageSize, bool includeUser = true, params Expression<Func<T, object>>[] includesPara);

       // Task<(int total, IQueryable<T> List)> GetByConditionAsync(Expression<Func<T, bool>> expression, FilterDTO filterModel, params Expression<Func<T, object>>[] includesPara);

        #region[order]
        Task<(int total, IQueryable<T> List)> GetByConditionAsync(Expression<Func<T, bool>> expression,
            Expression<Func<T, string>> order, OrderTypeEnum OrderType, int pageIndex, int pageSize, bool includeUser = true,
            params Expression<Func<T, object>>[] includesPara);
 
        Task<(int total, IQueryable<T> List)> GetByConditionAsync(Expression<Func<T, bool>> expression,
            Expression<Func<T, long?>> order, OrderTypeEnum OrderType, int pageIndex, int pageSize, bool includeUser = true, params Expression<Func<T, object>>[] includesPara);       
        Task<(int total, IQueryable<T> List)> GetByConditionAsync(Expression<Func<T, bool>> expression,
            string order, OrderTypeEnum OrderType, int pageIndex, int pageSize, bool includeUser = true, params Expression<Func<T, object>>[] includesPara);
        Task<(int total, IQueryable<T> List)> GetByConditionAsync(Expression<Func<T, bool>> expression,
            Expression<Func<T, bool?>> order, OrderTypeEnum OrderType, int pageIndex, int pageSize, bool includeUser = true, params Expression<Func<T, object>>[] includesPara);
       #endregion

        //Task<(int total, IQueryable<T> List)> GetByQueryAsync(IQueryable<T> query, string includes = "");
        Task<(int total, IQueryable<T> List)> GetByQueryAsync(string where, string order, int pageIndex, int pageSize, string includes = "");

        Task<IQueryable<T>> GetAsync(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            params Expression<Func<T, object>>[] includes);


        Task<IQueryable<T>> QueryAsync(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null);


        Task<T> GetByIdAsync(object id);


        Task<T> GetFirstOrDefaultAsync(
            Expression<Func<T, bool>> filter = null,
            params Expression<Func<T, object>>[] includes);


        Task<(int Total, IQueryable<T> EntityList)> GetWithIncludesAsync(int countForSkip, int pageSize, string includes = "");
        Task<(int Total, IQueryable<T> EntityList)> GetWithIncludesAsync(int countForSkip, int pageSize, params Expression<Func<T, object>>[] includesPara);

        Task<(int total, IQueryable<T> List)> GetByQueryAsync(
                int pageIndex, int pageSize, int pageCount, Expression<Func<T, bool>> filter, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, params Expression<Func<T, object>>[] includes);

        Task<IQueryable<T>> ReadStored(params KeyValuePair<string, string>[] Params);
 
        void Detached(T entity);
        void DetachAll();
        #endregion
    }
}