using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Training.Core;
using Training.Domain.Enums;

namespace Training.Interface
{
    public interface IBaseService<TModel, TEntity> : IBaseServiceReadOnly<TModel, TEntity>
    {
        #region Declaration
        IUnitOfWork MyUnitOfWork { get; }
        
        #endregion

        #region GetData
        Task<(int Total, List<TModel> ModelList)> GetAllAsync(FilterDTO filter, IQueryable<TEntity> query = null, string includes = "");

        Task<(int Total, List<TModel> ModelList)> GetAllAsync(FilterDTO filter, IQueryable<TEntity> query = null, params Expression<Func<TEntity, object>>[] includesPara);
        Task<(int Total, List<TModel> ModelList)> GetAllAsync();
        Task<(int Total, List<TModel> ModelList)> GetAll2Async(int pageIndex = 0, int pageSize = 0, int pageCount = 0, string where = "", string order = "", string includes = "");

        Task<(int Total, List<TModel> ModelList)> GetAll3Async(
            int pageIndex = 0,
            int pageSize = 0,
            int pageCount = 0,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Expression<Func<TEntity, bool>> filter = null,
            params Expression<Func<TEntity, object>>[] includes);

        

        Task<TModel> GetByIdAsync(long id);



        #region customcondition

      //  Task<(int Total, List<TModel> ModelList)> GetByCustomConditionAsync(Expression<Func<TEntity, bool>> expression, string order="", int pageIndex=0, int pageSize=0, params Expression<Func<TEntity, object>>[] includes );
        Task<(int Total, List<TModel> ModelList)> GetByCustomConditionAsync(Expression<Func<TEntity, bool>> expression, string order="", int pageIndex=0, int pageSize=0, params Expression<Func<TEntity, object>>[] includesPara);

        Task<(int Total, List<TModel> ModelList)> GetByCustomConditionAsync(Expression<Func<TEntity, bool>> expression, Expression<Func<TEntity, DateTime?>> order = null, OrderTypeEnum orderType=OrderTypeEnum.Asc, int pageIndex = 0, int pageSize = 0, params Expression<Func<TEntity, object>>[] includesPara);
        
        Task<(int Total, List<TModel> ModelList)> GetByCustomConditionAsync(Expression<Func<TEntity, bool>> expression, Expression<Func<TEntity, string>> order = null, OrderTypeEnum orderType = OrderTypeEnum.Asc, int pageIndex = 0, int pageSize = 0, params Expression<Func<TEntity, object>>[] includesPara);
        
        Task<(int Total, List<TModel> ModelList)> GetByCustomConditionAsync(Expression<Func<TEntity, bool>> expression, Expression<Func<TEntity, long?>> order = null,  OrderTypeEnum orderType = OrderTypeEnum.Asc, int pageIndex = 0, int pageSize = 0, params Expression<Func<TEntity, object>>[] includesPara);
        
        Task<(int Total, List<TModel> ModelList)> GetByCustomConditionAsync(Expression<Func<TEntity, bool>> expression, Expression<Func<TEntity, bool?>> order = null,  OrderTypeEnum orderType = OrderTypeEnum.Asc, int pageIndex = 0, int pageSize = 0, params Expression<Func<TEntity, object>>[] includesPara);
        #endregion

        Task<(int Total, List<TModel> ModelList)> GetByQueryAsync(string where, string order, int pageIndex, int pageSize, string includes = "");


       
        Task<(int Total, IQueryable<TEntity> EntityList)> GetEntityByCustomConditionAsync(Expression<Func<TEntity, bool>> expression, string order = "Id", int pageIndex = 0, int pageSize = 0, params Expression<Func<TEntity, object>>[] includes);
       
        Task<IQueryable<TEntity>> GetEntityAsync(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            params Expression<Func<TEntity, object>>[] includes);
        
        Task<IQueryable<TEntity>> QueryEntitiesAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);
       
        Task<TEntity> GetEntityByIdAsync(object id);
        
        Task<TEntity> GetEntityFirstOrDefaultAsync(
            Expression<Func<TEntity, bool>> filter = null,
            params Expression<Func<TEntity, object>>[] includes);

        Task<TModel> GetFirstOrDefaultAsync(
            Expression<Func<TEntity, bool>> filter = null,
            params Expression<Func<TEntity, object>>[] includes);

        #endregion

        #region CRUD
        Task<IQueryable<TEntity>> BulkInsertEntitiesAsync(IQueryable<TEntity> entities);
        Task<TEntity> UpdateEntityAsync(TEntity entity);
        Task<bool> DeleteEntityAsync(TEntity entity);
        Task<bool> BulkDeleteEntitiesAsync(IQueryable<TEntity> entities);

        #endregion

    }
}
