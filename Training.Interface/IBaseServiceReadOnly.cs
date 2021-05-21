using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Training.Interface
{
    public interface IBaseServiceReadOnly<TModel, TEntity>
    {
       
        #region CRUD
        Task<TModel> InsertAsync(TModel _tModel);
        Task<bool> DeleteAsync(long Id);
        Task<List<TModel>> BulkInsertAsync(IQueryable<TModel> _tModelList);
        Task<TModel> UpdateAsync(TModel _tModel);
        Task<List<TModel>> UpdatePatchAsync(IQueryable
            <TModel> _tEntityList);
        Task<bool> DeleteAsync(TModel model);
        Task<bool> DeleteActivityAsync(long id);
        Task<bool> BulkDeleteAsync(List<TModel> models);
        #endregion
               
    }
}
