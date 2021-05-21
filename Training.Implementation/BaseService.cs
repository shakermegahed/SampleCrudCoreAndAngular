using AutoMapper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using Training.Core;
using Training.Domain.Enums;
using Training.Domain.ViewModel;
using Training.Interface;

namespace Training.Implementation
{
    public /*abstract*/ class BaseService<TModel, TEntity> : IBaseService<TModel, TEntity> where TEntity : class
    {
        #region Declaration And Constructor
        public readonly IUnitOfWork _unitOfWork;
        public readonly IMapper _mapper;

        public IUnitOfWork MyUnitOfWork => _unitOfWork;

        public BaseService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        #endregion

        #region CRUD
        public virtual async Task<TModel> InsertAsync(TModel model)
        {
            if (model.GetType().GetProperty("Id") == null) return model;

            TEntity tble = _mapper.Map<TEntity>(model);
            //tble.GetType().GetProperty("IsStem").SetValue(tble, true);
            var resultEntity = await _unitOfWork.GetRepository<TEntity>().
                InsertAsync(tble);
            if (resultEntity != null)
            {
                var resultofsave = await _unitOfWork.SaveChangesAsync();
                model = _mapper.Map<TModel>(resultEntity);
                //Debug.WriteLineIf(resultofsave != 0, $"UpdatePatchAsync for {typeof(TEntity)?.FullName}: {resultofsave}");
            }
            return model;
        }
        public virtual async Task<List<TModel>> BulkInsertAsync(IQueryable<TModel> models)
        {
            try
            {
                if (models.Count() <= 0) return models.ToList();

                var entityList = _mapper.Map<List<TEntity>>(models.ToList());

                var resultEntities = await _unitOfWork.GetRepository<TEntity>().
                    BulkInsertAsync(entityList.AsQueryable());
                List<TModel> transactionModels = null;
                if (resultEntities != null)
                {
                    var resultofsaves = await _unitOfWork.SaveChangesAsync();
                    transactionModels = _mapper.Map<List<TModel>>(resultEntities);
                    //Debug.WriteLineIf(resultofsaves != 0, $"UpdatePatchAsync for {typeof(TEntity)?.FullName}: {resultofsaves}");
                }
                return transactionModels;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public virtual async Task<IQueryable<TEntity>> BulkInsertEntitiesAsync(IQueryable<TEntity> entities)
        {
            return await _unitOfWork.GetRepository<TEntity>().
                BulkInsertAsync(entities);
        }

        public virtual async Task<TEntity> UpdateEntityAsync(TEntity entity)
        {
            if (entity.GetType().GetProperty("Id") == null) return entity;
            var resultofupdate = await _unitOfWork.GetRepository<TEntity>().
                UpdateAsync(entity);

            return resultofupdate;
        }
        public virtual async Task<TModel> UpdateAsync(TModel model)
        {
            if (model.GetType().GetProperty("Id") == null) return model;
            var TransactionEntity = _mapper.Map<TEntity>(model);
            var resultofupdate = await _unitOfWork.GetRepository<TEntity>().
                UpdateAsync(TransactionEntity);

            TModel transactionModel = default(TModel);
            int resultSave = 0;
            if (resultofupdate != null)
            {
                resultSave = await _unitOfWork.SaveChangesAsync();
                //Debug.WriteLineIf(resultSave != 0, $"UpdatePatchAsync for {typeof(TEntity)?.FullName}: {resultSave}");
                transactionModel = _mapper.Map<TModel>(resultofupdate);
            }

            return transactionModel;
        }
        public virtual async Task<List<TModel>> UpdatePatchAsync(IQueryable<TModel> models)
        {
            if (models.Count() <= 0) return models.ToList();

            var entityList = _mapper.Map<List<TEntity>>(models);

            var resultofupdates = await _unitOfWork.GetRepository<TEntity>().
                PatchUpdateAsync(entityList.AsQueryable());

            List<TModel> transactionModels = null;
            int resultSave = 0;
            if (resultofupdates != null)
            {
                resultSave = await _unitOfWork.SaveChangesAsync();
                //Debug.WriteLineIf(resultSave != 0, $"UpdatePatchAsync for {typeof(TEntity)?.FullName}: {resultSave}");
                transactionModels = _mapper.Map<List<TModel>>(resultofupdates);
            }

            return transactionModels;
        }
        public virtual async Task<bool> DeleteEntityAsync(TEntity entity)
        {
            return (entity.GetType().GetProperty("Id") == null) ? false : await _unitOfWork.GetRepository<TEntity>().DeleteAsync(entity);
        }
        public virtual async Task<bool> DeleteAsync(TModel model)
        {
            try
            {
                if (model.GetType().GetProperty("Id") == null) return false;
                var TransactionEntity = _mapper.Map<TEntity>(model);
                var res = await _unitOfWork.GetRepository<TEntity>().
                    DeleteAsync(TransactionEntity);
                int resultSave = 0;
                if (res)
                {
                    resultSave = await _unitOfWork.SaveChangesAsync();
                    //Debug.WriteLineIf(resultSave != 0, $"UpdatePatchAsync for {typeof(TEntity)?.FullName}: {resultSave}");
                }
                return (resultSave > 0 ? true : false);
            }
            catch (Exception ex)
            {
                //return false;
                throw;
            }

        }
        public virtual async Task<bool> DeleteAsync(long id)
        {
            var TransactionEntity = await _unitOfWork.GetRepository<TEntity>().GetByIdAsync(id);
            var res = await _unitOfWork.GetRepository<TEntity>().DeleteAsync(TransactionEntity);

            int resultSave = 0;
            if (res)
            {
                resultSave = await _unitOfWork.SaveChangesAsync();
                //Debug.WriteLineIf(resultSave != 0, $"UpdatePatchAsync for {typeof(TEntity)?.FullName}: {resultSave}");
            }
            return (resultSave > 0 ? true : false);
        }

        public virtual async Task<bool> DeleteActivityAsync(long id)
        {
            //if (model.GetType().GetProperty("ActiveYN") == null) return false;
            //long id = (long)model.GetType().GetProperty("Id").GetValue(model);
            var TransactionEntity = await _unitOfWork.GetRepository<TEntity>().GetByIdAsync(id);
            if (TransactionEntity.GetType().GetProperty("ActiveYN", BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance) == null) return false;
            TransactionEntity.GetType().GetProperty("ActiveYN", BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance).SetValue(TransactionEntity, false);
            var res = await _unitOfWork.GetRepository<TEntity>().UpdateAsync(TransactionEntity);

            int resultSave = 0;
            if (res != null)
            {
                resultSave = await _unitOfWork.SaveChangesAsync();
                //Debug.WriteLineIf(resultSave != 0, $"UpdatePatchAsync for {typeof(TEntity)?.FullName}: {resultSave}");
            }
            return (resultSave > 0 ? true : false);
        }
        public virtual async Task<bool> BulkDeleteAsync(List<TModel> models)
        {
            if (models.Count <= 0) return true;

            var entityList = _mapper.Map<List<TEntity>>(models).AsQueryable();
            var res = await _unitOfWork.GetRepository<TEntity>().BulkDeleteAsync(entityList);
            int resultSave = 0;
            if (res)
            {
                resultSave = await _unitOfWork.SaveChangesAsync();
                //Debug.WriteLineIf(resultSave != 0, $"UpdatePatchAsync for {typeof(TEntity)?.FullName}: {resultSave}");
            }
            return (resultSave > 0 ? true : false);
        }

        public virtual async Task<bool> BulkDeleteEntitiesAsync(IQueryable<TEntity> entities)
        {
            if (entities == null || entities.Count() <= 0) return true;

            return await _unitOfWork.GetRepository<TEntity>().BulkDeleteAsync(entities);
        }

        #endregion

        #region GetData
        public virtual async Task<TModel> GetByIdAsync(long id)
        {
            var resultEntity = await _unitOfWork.GetRepository<TEntity>().GetByIdAsync(id);
            var _tModel = _mapper.Map<TModel>(resultEntity);
            //Debug.WriteLine($"GetByIdAsync for {typeof(TEntity)?.FullName} id: {id}");
            return _tModel;
        }


        public virtual async Task<(int Total, List<TModel> ModelList)> GetAllAsync(FilterDTO filter,
            IQueryable<TEntity> query = null, string includes = "")
        {
            int Total = 0;
            List<TModel> transactionModels = null;

            if (query == null)
            {
                //Debug.WriteLine($"GetAllAsync for {typeof(TEntity)?.FullName} includes: {includes}");
                int countForSkip = (filter.PageIndex) * filter.PageSize;
                var (total, entityList) = await _unitOfWork.GetRepository<TEntity>().GetWithIncludesAsync(countForSkip, filter.PageSize, includes);

                Total = total;
                if (total != 0 && entityList != null && entityList?.Count() > 0)
                {
                    //resultSave = await _unitOfWork.SaveChangesAsync();
                    //Debug.WriteLineIf(resultSave != 0, $"UpdatePatchAsync for {typeof(TEntity)?.FullName}: {resultSave}");
                    transactionModels = _mapper.Map<List<TModel>>(entityList);
                    //transactionModels.ForEach(x =>
                    //{
                    //    if (x.GetType().GetProperty("Name") != null)
                    //    {
                    //        x.GetType().GetProperty("Name").SetValue(x, filter.Lang.ToLower() == "ar" ? x.GetType().GetProperty("NameAr").GetValue(x) : x.GetType().GetProperty("NameEn").GetValue(x));
                    //    }

                    //});
                }
            }
            else
            {
                int countForSkip = (filter.PageIndex) * filter.PageSize;
                //Debug.WriteLine($"GetAllAsync for {typeof(TEntity)?.FullName} countForSkip: {countForSkip}");
                var entityList = await _unitOfWork.GetRepository<TEntity>().GetAllAsync(query, countForSkip, filter.PageSize);

                Total = entityList.Total;
                if (entityList.EntityList != null && entityList.EntityList?.Count() > 0)
                {
                    //Debug.WriteLineIf(resultSave != 0, $"UpdatePatchAsync for {typeof(TEntity)?.FullName}: {resultSave}");
                    transactionModels = _mapper.Map<List<TModel>>(entityList.EntityList);
                    //transactionModels.ForEach(x =>
                    //{
                    //    if (x.GetType().GetProperty("Name") != null)
                    //    {
                    //        x.GetType().GetProperty("Name").SetValue(x, filter.Lang.ToLower() == "ar" ? x.GetType().GetProperty("NameAr").GetValue(x) : x.GetType().GetProperty("NameEn").GetValue(x));
                    //    }

                    //});
                }
            }
            return (Total, transactionModels);
        }

        public virtual async Task<(int Total, List<TModel> ModelList)> GetAllAsync(FilterDTO filter,
            IQueryable<TEntity> query = null, params Expression<Func<TEntity, object>>[] includesPara)
        {
            int Total = 0;
            List<TModel> transactionModels = null;

            if (query == null)
            {
                //Debug.WriteLine($"GetAllAsync for {typeof(TEntity)?.FullName} includes: {includesPara}");
                int countForSkip = (filter.PageIndex) * filter.PageSize;
                var (total, entityList) = await _unitOfWork.GetRepository<TEntity>().GetWithIncludesAsync(countForSkip, filter.PageSize, includesPara);

                Total = total;
                if (total != 0 && entityList != null && entityList?.Count() > 0)
                {
                    //resultSave = await _unitOfWork.SaveChangesAsync();
                    //Debug.WriteLineIf(resultSave != 0, $"UpdatePatchAsync for {typeof(TEntity)?.FullName}: {resultSave}");
                    transactionModels = _mapper.Map<List<TModel>>(entityList);
                    transactionModels.ForEach(x =>
                    {
                        if (x.GetType().GetProperty("Name") != null)
                        {
                            x.GetType().GetProperty("Name").SetValue(x,  x.GetType().GetProperty("NameEn").GetValue(x));
                        }

                    });
                }
            }
            else
            {
                int countForSkip = (filter.PageIndex) * filter.PageSize;
                //Debug.WriteLine($"GetAllAsync for {typeof(TEntity)?.FullName} countForSkip: {countForSkip}");
                var entityList = await _unitOfWork.GetRepository<TEntity>().GetAllAsync(query, countForSkip, filter.PageSize);

                //int resultSave = 0;
                Total = entityList.Total;
                if (entityList.EntityList != null && entityList.EntityList?.Count() > 0)
                {
                    //  Debug.WriteLineIf(resultSave != 0, $"UpdatePatchAsync for {typeof(TEntity)?.FullName}: {resultSave}");
                    transactionModels = _mapper.Map<List<TModel>>(entityList.EntityList);
                    transactionModels.ForEach(x =>
                    {
                        if (x.GetType().GetProperty("Name") != null)
                        {
                            x.GetType().GetProperty("Name").SetValue(x, x.GetType().GetProperty("NameEn").GetValue(x));
                        }

                    });
                }
            }
            return (Total, transactionModels);
        }

        public virtual async Task<(int Total, List<TModel> ModelList)> GetAll2Async(int pageIndex = 0, int pageSize = 0, int pageCount = 0, string where = "", string order = "", string includes = "")
        {
            try
            {
                int Total = 0;
                List<TModel> transactionModels = null;
                int countForSkip = (pageIndex) * pageSize;

                Debug.WriteLine($"GetAllAsync for {typeof(TEntity)?.FullName} countForSkip: {countForSkip}");
                var entityList = await _unitOfWork.GetRepository<TEntity>().GetByQueryAsync(where, order, pageIndex, pageSize, includes);

                int resultSave = 0;
                Total = entityList.total;
                if (entityList.List != null && entityList.List?.Count() > 0)
                {
                    Debug.WriteLineIf(resultSave != 0, $"UpdatePatchAsync for {typeof(TEntity)?.FullName}: {resultSave}");
                    transactionModels = _mapper.Map<List<TModel>>(entityList.List);
                }

                return (Total, transactionModels);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public virtual async Task<(int Total, IQueryable<TEntity> EntityList)> GetEntityByCustomConditionAsync(Expression<Func<TEntity, bool>> expression, string order = "Id", int pageIndex = 0, int pageSize = 0, params Expression<Func<TEntity, object>>[] includes )
        {
            try
            {
                var entityList = await _unitOfWork.GetRepository<TEntity>()
                    .GetByConditionAsync(new RepositoryFilterDTO<TEntity>
                    {
                        expression = expression,
                        OrderBy = order,
                        PageIndex = pageIndex,
                        PageSize = pageSize
                    }, includes);
                Debug.WriteLine($"GetByCustomConditionAsync for {typeof(TEntity)?.FullName} expression: {expression.ToString()}");

                return (entityList.total, entityList.List);
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }

        }

        #region CutomConditions
        //public virtual async Task<(int Total, List<TModel> ModelList)> GetByCustomConditionAsync(Expression<Func<TEntity, bool>> expression, string order = "", int pageIndex = 0, int pageSize = 0, string includes = "")
        //{
        //    try
        //    {
        //        var entityList = await _unitOfWork.GetRepository<TEntity>()
        //            .GetByConditionAsync(expression, order, pageIndex, pageSize, includes);
        //        Debug.WriteLine($"GetByCustomConditionAsync for {typeof(TEntity)?.FullName} expression: {expression.ToString()}");
        //        List<TModel> result = null;
        //        if (entityList.List != null && entityList.List?.Count() > 0)
        //        {
        //            result = _mapper.Map<List<TModel>>(entityList.List);
        //        }
        //        return (entityList.total, result);
        //    }
        //    catch (Exception ex)
        //    {

        //        throw new NotImplementedException(ex.ToString());
        //    }

        //}

        public virtual async Task<(int Total, List<TModel> ModelList)> GetByCustomConditionAsync(Expression<Func<TEntity, bool>> expression, string order = "", int pageIndex = 0, int pageSize = 0, params Expression<Func<TEntity, object>>[] includesPara)
        {
            try
            {
                var entityList = await _unitOfWork.GetRepository<TEntity>().
                    GetByConditionAsync(new RepositoryFilterDTO<TEntity>
                    {
                        expression = expression,
                        OrderBy = order,
                        PageIndex = pageIndex,
                        PageSize = pageSize,
                        includeUser = true,
                        withTraking = false

                    }, includesPara);
                Debug.WriteLine($"GetByCustomConditionAsync for {typeof(TEntity)?.FullName} expression: {expression.ToString()}");
                List<TModel> result = null;
                if (entityList.List != null && entityList.List?.Count() > 0)
                {
                    result = _mapper.Map<List<TModel>>(entityList.List);
                }
                return (entityList.total, result);
            }
            catch (Exception ex)
            {

                throw new NotImplementedException(ex.ToString());
            }

        }

        public virtual async Task<(int Total, List<TModel> ModelList)> GetByCustomConditionAsync(Expression<Func<TEntity, bool>> expression, Expression<Func<TEntity, DateTime?>> order = null, OrderTypeEnum orderType = OrderTypeEnum.Asc, int pageIndex = 0, int pageSize = 0, params Expression<Func<TEntity, object>>[] includesPara)
        {
            try
            {
                var entityList = await _unitOfWork.GetRepository<TEntity>().GetByConditionAsync(expression, order, orderType, pageIndex, pageSize, true, includesPara);
                Debug.WriteLine($"GetByCustomConditionAsync for {typeof(TEntity)?.FullName} expression: {expression.ToString()}");
                List<TModel> result = null;
                if (entityList.List != null && entityList.List?.Count() > 0)
                {
                    result = _mapper.Map<List<TModel>>(entityList.List);
                }
                return (entityList.total, result);
            }
            catch (Exception ex)
            {

                throw new NotImplementedException(ex.ToString());
            }

        }

        public virtual async Task<(int Total, List<TModel> ModelList)> GetByCustomConditionAsync(Expression<Func<TEntity, bool>> expression, Expression<Func<TEntity, string>> order = null, OrderTypeEnum orderType = OrderTypeEnum.Asc, int pageIndex = 0, int pageSize = 0, params Expression<Func<TEntity, object>>[] includesPara)
        {
            try
            {
                var entityList = await _unitOfWork.GetRepository<TEntity>().GetByConditionAsync(expression, order, orderType, pageIndex, pageSize, true, includesPara);
                Debug.WriteLine($"GetByCustomConditionAsync for {typeof(TEntity)?.FullName} expression: {expression.ToString()}");
                List<TModel> result = null;
                if (entityList.List != null && entityList.List?.Count() > 0)
                {
                    result = _mapper.Map<List<TModel>>(entityList.List);
                }
                return (entityList.total, result);
            }
            catch (Exception ex)
            {

                throw new NotImplementedException(ex.ToString());
            }

        }

        public virtual async Task<(int Total, List<TModel> ModelList)> GetByCustomConditionAsync(Expression<Func<TEntity, bool>> expression, Expression<Func<TEntity, long?>> order = null, OrderTypeEnum orderType = OrderTypeEnum.Asc, int pageIndex = 0, int pageSize = 0, params Expression<Func<TEntity, object>>[] includesPara)
        {
            try
            {
                var entityList = await _unitOfWork.GetRepository<TEntity>().GetByConditionAsync(expression, order, orderType, pageIndex, pageSize, true, includesPara);
                Debug.WriteLine($"GetByCustomConditionAsync for {typeof(TEntity)?.FullName} expression: {expression.ToString()}");
                List<TModel> result = null;
                if (entityList.List != null && entityList.List?.Count() > 0)
                {
                    result = _mapper.Map<List<TModel>>(entityList.List);
                }
                return (entityList.total, result);
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        } 
        
        public virtual async Task<(int Total, List<TModel> ModelList)> GetByCustomConditionAsync(Expression<Func<TEntity, bool>> expression, string order = null, OrderTypeEnum orderType = OrderTypeEnum.Asc, int pageIndex = 0, int pageSize = 0, params Expression<Func<TEntity, object>>[] includesPara)
        {
            try
            {
                var entityList = await _unitOfWork.GetRepository<TEntity>().GetByConditionAsync(expression, order, orderType, pageIndex, pageSize, true, includesPara);
                Debug.WriteLine($"GetByCustomConditionAsync for {typeof(TEntity)?.FullName} expression: {expression.ToString()}");
                List<TModel> result = null;
                if (entityList.List != null && entityList.List?.Count() > 0)
                {
                    result = _mapper.Map<List<TModel>>(entityList.List);
                }
                return (entityList.total, result);
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public virtual async Task<(int Total, List<TModel> ModelList)> GetByCustomConditionAsync(Expression<Func<TEntity, bool>> expression, Expression<Func<TEntity, bool?>> order = null, OrderTypeEnum orderType = OrderTypeEnum.Asc, int pageIndex = 0, int pageSize = 0, params Expression<Func<TEntity, object>>[] includesPara)
        {
            try
            {
                var entityList = await _unitOfWork.GetRepository<TEntity>().GetByConditionAsync(expression, order, orderType, pageIndex, pageSize, true, includesPara);
                Debug.WriteLine($"GetByCustomConditionAsync for {typeof(TEntity)?.FullName} expression: {expression.ToString()}");
                List<TModel> result = null;
                if (entityList.List != null && entityList.List?.Count() > 0)
                {
                    result = _mapper.Map<List<TModel>>(entityList.List);
                }
                return (entityList.total, result);
            }
            catch (Exception ex)
            {

                throw new NotImplementedException(ex.ToString());
            }

        }
        #endregion

        public virtual async Task<(int Total, List<TModel> ModelList)> GetByQueryAsync(string where, string order, int pageIndex, int pageSize, string includes = "")
        {
            var entities = await _unitOfWork.GetRepository<TEntity>().GetByQueryAsync(where, order, pageIndex, pageSize, includes);

            List<TModel> models = null;

            if (entities.List != null)
            {
                models = _mapper.Map<List<TModel>>(entities.List);
            }

            return (entities.total, models);
        }

        public virtual async Task<(int Total, List<TModel> ModelList)> GetAllAsync()
        {
            return await GetAllAsync(new FilterDTO { });
        }

        public virtual async Task<IQueryable<TEntity>> GetEntityAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params Expression<Func<TEntity, object>>[] includes)
        {
            return await _unitOfWork.GetRepository<TEntity>().GetAsync(filter, orderBy, includes);
        }

        public virtual async Task<IQueryable<TEntity>> QueryEntitiesAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            return await _unitOfWork.GetRepository<TEntity>().QueryAsync(filter, orderBy);
        }

        public virtual async Task<TEntity> GetByIdAsync(object id)
        {
            return await _unitOfWork.GetRepository<TEntity>().GetByIdAsync(id);
        }

        public virtual async Task<TEntity> GetEntityFirstOrDefaultAsync(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes)
        {
            return await _unitOfWork.GetRepository<TEntity>().GetFirstOrDefaultAsync(filter, includes);
        }
        public virtual async Task<TModel> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes)
        {
            var entity = await _unitOfWork.GetRepository<TEntity>().GetFirstOrDefaultAsync(filter, includes);
            return _mapper.Map<TModel>(entity);
        }

        public virtual async Task<TEntity> GetEntityByIdAsync(object id)
        {
            return await _unitOfWork.GetRepository<TEntity>().GetByIdAsync(id);
        }

        public virtual async Task<(int Total, List<TModel> ModelList)> GetAll3Async(
            int pageIndex = 0,
            int pageSize = 0,
            int pageCount = 0,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Expression<Func<TEntity, bool>> filter = null,
            params Expression<Func<TEntity, object>>[] includes)
        {
            int Total = 0;
            List<TModel> transactionModels = null;
            int countForSkip = (pageIndex) * pageSize;
            Debug.WriteLine($"GetAllAsync for {typeof(TEntity)?.FullName} countForSkip: {countForSkip}");

            var entityList = await _unitOfWork.GetRepository<TEntity>()
                .GetByQueryAsync(pageIndex, pageSize, pageCount, filter, orderBy, includes);

            int resultSave = 0;
            Total = entityList.total;
            if (entityList.List != null && entityList.List?.Count() > 0)
            {
                Debug.WriteLineIf(resultSave != 0, $"UpdatePatchAsync for {typeof(TEntity)?.FullName}: {resultSave}");
                transactionModels = _mapper.Map<List<TModel>>(entityList.List);
            }

            return (Total, transactionModels);
        }

        #endregion


    }

}
