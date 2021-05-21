
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Training.Interface
{
    public interface IRepositoryReadOnly<T> where T : class
    {        

        #region CRUD

        Task<T> InsertAsync(T Entity);
        Task<IQueryable<T>> BulkInsertAsync(IQueryable<T> Entitities);
        Task<T> UpdateAsync(T Entity);
        Task<T> UpdateAsync(T Entity, params Expression<Func<T, object>>[] Excludes);
        Task<IQueryable<T>> PatchUpdateAsync(IQueryable<T> Entitities);

        Task<bool> DeleteAsync(T Entity);
        Task<bool> BulkDeleteAsync(IQueryable<T> Entitities);


        #endregion

        //IQueryable<T> ExecWithStoreProcedure(string query, params object[] parameters);
    }
}