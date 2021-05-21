using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using Training.Interface;
using Training.Core;
using Training.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Training.Domain.Enums;
using System.Linq.Dynamic;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;

namespace Training.Implementation
{
    public class Repository<T> : IRepository<T> where T : class
    {
        #region Declaration And Constructor
        public TrainingDbContext Context { get; set; }
        protected DbSet<T> DbSet;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public Repository(TrainingDbContext context)
        {
            Context = context;
            DbSet = Context.Set<T>();
          //  _httpContextAccessor = httpContextAccessor;
        }

        #endregion

        #region GetData
        public async Task<(int Total, IQueryable<T> EntityList)> GetWithIncludesAsync(int countForSkip,
            int PageSize, string includes = "")
        {
            int Total = 0;
            IQueryable<T> query = Context.Set<T>();
            Total = await query.CountAsync();

            if (includes == "")
            {
                query = (PageSize == 0)
                    ? await Task.Run(() => query.AsNoTracking())
                    : await Task.Run(() => query.Skip(countForSkip).Take(PageSize).AsNoTracking());
            }
            else
            {
                if (!string.IsNullOrEmpty(includes))
                {
                    string[] splitIcludes = includes.Split(",");

                    foreach (var item in splitIcludes)
                        query = query.Include(item.Trim());
                }

                //string str = query.ToSql();
                //Debug.WriteLine($"GetWithIncludesAsync ({typeof(T).Name}) query.ToSql(): ", "");

                query = (PageSize > 0 && Total > 0) ? await Task.Run(() => query.Skip(countForSkip).Take(PageSize).AsNoTracking()) : await Task.Run(() => query.Skip(countForSkip).Take(Total).AsNoTracking());
            }

            return (Total, query);
        }

        public async Task<(int Total, IQueryable<T> EntityList)> GetWithIncludesAsync(int countForSkip,
            int PageSize, params Expression<Func<T, object>>[] includesPar)
        {
            int Total = 0;
            IQueryable<T> query = Context.Set<T>();
            Total = await query.CountAsync();

            if (includesPar == null)
            {
                query = (PageSize == 0)
                    ? await Task.Run(() => query.AsNoTracking())
                    : await Task.Run(() => query.Skip(countForSkip).Take(PageSize).AsNoTracking());
            }
            else
            {

                foreach (Expression<Func<T, object>> include in includesPar)
                    query = query.Include(include.AsPath());
                //string str = query.ToSql();
                //Debug.WriteLine($"GetWithIncludesAsync ({typeof(T).Name}) query.ToSql(): ", "");
                query = (PageSize > 0 && Total > 0) ? await Task.Run(() => query.Skip(countForSkip).Take(PageSize).AsNoTracking()) : await Task.Run(() => query.Skip(countForSkip).Take(Total).AsNoTracking());
            }
            return (Total, query);
        }

        public async Task<(int Total, IQueryable<T> EntityList)> GetAllAsync(IQueryable<T> query = null, int countForSkip = 0,
            int PageSize = 0)
        {
            IQueryable<T> res;
            int Total;
            if (query == null)
            {
                query = DbSet;
                Total = await query.CountAsync();
            }
            else
            {
                Total = await query.CountAsync();
            }

            if (PageSize == 0)
            {
                res = await Task.Run(() => query.AsNoTracking());
            }
            else
            {
                //await query.CountAsync();
                res = await Task.Run(() => query.Skip(countForSkip).Take(PageSize).AsNoTracking());
                Type myType = res.GetType();
                foreach (var item in myType.GetProperties())
                {

                }
            }

            return (Total, res);
        }

        public async Task<T> GetByIdAsync(long id)
        {
            if (PropertyIsExisted("CreatedByNavigation", "ModifiedByNavigation"))
            {
                var result = DbSet.Include("CreatedByNavigation").Include("ModifiedByNavigation").Where($" Id == {id}").FirstOrDefault();
                return result;
            }
            else
            {
                var result = await DbSet.FindAsync(id);
                return result;
            }
        }

        public long GetCount()
        {
            if (PropertyIsExisted("CreatedByNavigation", "ModifiedByNavigation"))
            {
                var result = DbSet.Include("CreatedByNavigation").Include("ModifiedByNavigation").Count();
                return result;
            }
            else
            {
                var result = DbSet.Count();
                return result;
            }
        }

        public async Task<T> GetByIdAsync(object id)
        {
            if (PropertyIsExisted("CreatedByNavigation", "ModifiedByNavigation"))
            {
                var r = DbSet.Include("CreatedByNavigation").Include("ModifiedByNavigation")
                .Where($"x=> x.Id == {id}").FirstOrDefault();
                return r;
            }
            else
            {
                var r = await DbSet.FindAsync(id);
                return r;
            }
        }

        public async Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includes)
        {
            try
            {
                IQueryable<T> query = DbSet;

                foreach (Expression<Func<T, object>> include in includes)
                    query = query.Include(include.AsPath()).AsNoTracking();

                //string str = query.ToSql();

                var r = await query.AsNoTracking().FirstOrDefaultAsync(filter);
                return r;

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                throw;
            }
        }

        public async Task<IQueryable<T>> GetAsync(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, params Expression<Func<T, object>>[] includes)
        {
            try
            {
                IQueryable<T> query = DbSet;

                await Task.Run(() =>
                {
                    foreach (Expression<Func<T, object>> include in includes)
                        query = query.Include(include.AsPath());

                    if (filter != null)
                        query = query.Where(filter);

                    if (orderBy != null)
                        query = orderBy(query);
                });

                return query;
            }
            catch (Exception ex)
            {
                throw;
            }

        }


        //public async Task<(int total, IQueryable<T> List)> GetByConditionAsync(Expression<Func<T, bool>> expression,
        //    string order, int pageIndex, int PageSize, string includes = "", bool includeUser = true)
        //{
        //    try
        //    {
        //        IQueryable<T> query = Context.Set<T>();

        //        int countForSkip = (pageIndex) * PageSize;

        //        int Total = expression != null ? await query.Where(expression).AsNoTracking().CountAsync() : await query.AsNoTracking().CountAsync();

        //        if (PageSize == 0 && Total > 0)
        //        {
        //            PageSize = Total;
        //        }
        //        else if (Total == 0)
        //        {
        //            return (0, null);
        //        }

        //        var res = await Task.Run(() => expression == null ? Context.Set<T>()
        //           .Skip(countForSkip).Take(PageSize) :
        //           query.Where(expression).Skip(countForSkip).Take(PageSize));
        //        //
        //        //var result = res.Include(includes);

        //        if (!string.IsNullOrEmpty(includes))
        //        {
        //            string[] splitIcludes = includes.Split(",");

        //            if (splitIcludes.Count() != 0 && splitIcludes[0] != "")
        //            {
        //                foreach (var item in splitIcludes)
        //                    res = res.Include(item.Trim());
        //            }
        //        }
        //        string name = typeof(T).Name;

        //        if (PropertyIsExisted("CreatedByNavigation", "ModifiedByNavigation") && includeUser)
        //        {
        //            res = res.AsNoTracking().Include("CreatedByNavigation").AsNoTracking();
        //            res = res.AsNoTracking().Include("ModifiedByNavigation").AsNoTracking();
        //        }
        //        //string str = res.ToSql();

        //        return (Total, res);
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine($"GetByConditionAsync err : {ex.ToString()}");
        //        throw;
        //    }

        //}

        //public async Task<(int total, IQueryable<T> List)> GetByConditionAsync(Expression<Func<T, bool>> expression, FilterDTO filterModel)
        //{
        //    try
        //    {

        //        IQueryable<T> query = Context.Set<T>().AsNoTracking();

        //        int countForSkip = (filterModel.PageIndex) * filterModel.PageSize;

        //        int Total = expression != null ? await query.Where(expression).AsNoTracking().CountAsync() : await query.AsNoTracking().CountAsync();

        //        if (filterModel.PageSize == 0 && Total > 0)
        //        {
        //            filterModel.PageSize = Total;
        //        }
        //        else if (Total == 0)
        //        {
        //            return (0, null);
        //        }

        //        var res = await Task.Run(() => expression == null ? Context.Set<T>().AsNoTracking()
        //           .Skip(countForSkip).Take(filterModel.PageSize).AsNoTracking() :
        //           query.Where(expression).Skip(countForSkip).Take(filterModel.PageSize).AsNoTracking());
        //        //
        //        //var result = res.Include(includes);

        //        //if (!string.IsNullOrEmpty(filterModel.includes))
        //        //{
        //        //    string[] splitIcludes = filterModel.includes.Split(",");

        //        //    if (splitIcludes.Count() != 0 && splitIcludes[0] != "")
        //        //    {
        //        //        foreach (var item in splitIcludes)
        //        //            res = res.Include(item.Trim());
        //        //    }
        //        //}
        //        string name = typeof(T).Name;

        //        //var tblProperties = Context
        //        //    .GetType()
        //        //    .GetProperties()
        //        //    .Where(p =>
        //        //        p.PropertyType.IsGenericType &&
        //        //        p.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>))
        //        //    .Select(p => p.PropertyType.GetGenericArguments()[0])
        //        //    .Where(t => t.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
        //        //    .SelectMany(t => t.GetProperties())
        //        //    .ToArray();

        //        //if (tblProperties.Any(x => x.Name == "CreatedByNavigation") &&
        //        //    tblProperties.Any(x => x.Name == "ModifiedByNavigation"))
        //        //if (PropertyIsExisted("CreatedByNavigation", "ModifiedByNavigation") && filterModel.includeUser)
        //        //{
        //        //    res = res.AsNoTracking().Include("CreatedByNavigation").AsNoTracking();
        //        //    res = res.AsNoTracking().Include("ModifiedByNavigation").AsNoTracking();
        //        //} 

        //        //string str = res.ToSql();

        //        return (Total, res.AsNoTracking());
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine($"GetByConditionAsync err : {ex.ToString()}");
        //        throw;
        //    }

        //}

        //public async Task<(int total, IQueryable<T> List)> GetByConditionAsync(Expression<Func<T, bool>> expression, string order,
        //    int pageIndex, int PageSize, 
        //    bool includeUser = true, bool withTraking = false, params Expression<Func<T, object>>[] includes)
        //{
        //    try
        //    {

        //        IQueryable<T> query = Context.Set<T>();

        //        int countForSkip = (pageIndex) * PageSize;

        //        int Total = expression == null ? await query.CountAsync() : await query.Where(expression).CountAsync();

        //        if (PageSize == 0 && Total > 0)
        //        {
        //            PageSize = Total;
        //        }
        //        else if (Total == 0)
        //        {
        //            return (0, null);
        //        }


        //        var res = await Task.Run(() => expression == null ? query
        //            .Skip(countForSkip).Take(PageSize) : query
        //            .Where(expression).Skip(countForSkip).Take(PageSize));

        //        foreach (Expression<Func<T, object>> include in includes)
        //            res = res.Include(include.AsPath());

        //        if (PropertyIsExisted("CreatedByNavigation", "ModifiedByNavigation") && includeUser)
        //        {
        //            res = res.Include("CreatedByNavigation");
        //            res = res.Include("ModifiedByNavigation");
        //        }
        //        //string str = res.ToSql();

        //        return (Total, (withTraking == true) ? res : res.AsNoTracking());
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine($"GetByConditionAsync err : {ex.ToString()}");
        //        throw;
        //    }
        //}
        //public async Task<(int total, IQueryable<T> List)> GetByConditionAsync(Expression<Func<T, bool>> expression, FilterDTO filterModel, params Expression<Func<T, object>>[] includes)
        //{
        //    try
        //    {
        //        IQueryable<T> query = Context.Set<T>();

        //        int countForSkip = (filterModel.PageIndex) * filterModel.PageSize;

        //        int Total = expression == null ? await query.CountAsync() : await query.Where(expression).CountAsync();

        //        if (filterModel.PageSize == 0 && Total > 0)
        //        {
        //            filterModel.PageSize = Total;
        //        }
        //        else if (Total == 0)
        //        {
        //            return (0, null);
        //        }

        //        if (filterModel.OrderBy == null)
        //        {
        //            var res = await Task.Run(() => expression == null ? query
        //           .Skip(countForSkip).Take(filterModel.PageSize) : query
        //           .Where(expression).Skip(countForSkip).Take(filterModel.PageSize));
        //            foreach (Expression<Func<T, object>> include in includes)
        //                res = res.Include(include.AsPath());
        //            if (PropertyIsExisted("CreatedByNavigation", "ModifiedByNavigation"))
        //            {
        //                res = res.Include("CreatedByNavigation");
        //                res = res.Include("ModifiedByNavigation");
        //            }
        //            //string str = res.ToSql();

        //            return (Total, res);
        //        }
        //        else
        //        {
        //            var res = await Task.Run(() => expression == null ? query
        //          .Skip(countForSkip).Take(filterModel.PageSize) : query
        //          .Where(expression).Skip(countForSkip).Take(filterModel.PageSize));
        //            foreach (Expression<Func<T, object>> include in includes)
        //                res = res.Include(include.AsPath());
        //            if (PropertyIsExisted("CreatedByNavigation", "ModifiedByNavigation"))
        //            {
        //                res = res.Include("CreatedByNavigation");
        //                res = res.Include("ModifiedByNavigation");
        //            }
        //            //string str = res.ToSql();

        //            return (Total, res);
        //        }



        //        //string name = typeof(T).Name;



        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine($"GetByConditionAsync err : {ex.ToString()}");
        //        throw;
        //    }
        //}


        public async Task<(int total, IQueryable<T> List)> GetByQueryAsync(string where, string order, int pageIndex, int PageSize, string includes = "")
        {
            try
            {
                //string stemValue = _httpContextAccessor.HttpContext.Session.GetString("IsStem");
                string all = "";
                IQueryable<T> query = Context.Set<T>().AsNoTracking();

                all = where;


                int count = string.IsNullOrEmpty(all) ? await query.CountAsync() : await query.Where(all).CountAsync();


                int countForSkip = (pageIndex) * PageSize;

                if (PageSize == 0)
                {
                    query = await Task.Run(() => query);
                    if (!string.IsNullOrEmpty(all))
                    {
                        query = query.Where(all).AsNoTracking();
                    }
                }
                else
                {
                    if (order == "")
                    {
                        query = string.IsNullOrEmpty(all) ? await Task.Run(() =>
                        query.Skip(countForSkip).Take(PageSize).AsNoTracking())
                        : await Task.Run(() =>
                        Context.Set<T>().Where(all).Skip(countForSkip).Take(PageSize).AsNoTracking());
                    }
                    else
                    {

                        query = string.IsNullOrEmpty(all) ? await Task.Run(() =>
                        query.Skip(countForSkip).Take(PageSize).
                        OrderBy(order).AsNoTracking()) : await Task.Run(() =>
                        query.Where(all).Skip(countForSkip).Take(PageSize).
                        OrderBy(order).AsNoTracking());
                    }

                }

                if (!string.IsNullOrEmpty(includes))
                {
                    string[] splitIcludes = includes.Split(",");

                    foreach (var item in splitIcludes)
                        query = query.Include(item.Trim());

                }

                //string str = query.AsNoTracking().ToSql();

                return (count, query);
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public async Task<(int total, IQueryable<T> List)> GetByQueryAsync(
                int pageIndex, int PageSize, int pageCount, Expression<Func<T, bool>> filter, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = Context.Set<T>().AsNoTracking();

            int count = filter == null ? await query.CountAsync() : await query.Where(filter).CountAsync();

            await Task.Run(() =>
            {
                int countForSkip = (pageIndex) * PageSize;

                if (filter != null && PageSize == 0)
                {
                    query = query.Where(filter);
                }
                else if (filter != null && PageSize > 0)
                {
                    query = query.Where(filter).Skip(countForSkip).Take(PageSize).AsNoTracking();
                }
                else if (filter == null && PageSize > 0)
                {
                    query = query.Skip(countForSkip).Take(PageSize).AsNoTracking();
                }

                if (orderBy != null)
                    query = orderBy(query);

                foreach (Expression<Func<T, object>> include in includes)
                    query = query.Include(include.AsPath());

                //string str = query.AsNoTracking().ToSql();
            });

            return (count, query);
        }


        public async Task<IQueryable<T>> QueryAsync(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
        {
            IQueryable<T> query = DbSet;

            await Task.Run(() =>
            {
                if (filter != null)
                    query = query.Where(filter);

                if (orderBy != null)
                    query = orderBy(query);
            });

            return query;
        }

        #endregion

        #region ordering
        public async Task<(int total, IQueryable<T> List)> GetByConditionAsync(Expression<Func<T, bool>> expression,
            Expression<Func<T, DateTime?>> order, OrderTypeEnum OrderType, int pageIndex, int PageSize,
            bool includeUser = true, params Expression<Func<T, object>>[] includes)
        {
            try
            {
                IQueryable<T> query = Context.Set<T>().AsNoTracking();

                int countForSkip = (pageIndex) * PageSize;

                int Total = expression == null ? await query.CountAsync() : await query.Where(expression).CountAsync();

                if (PageSize == 0 && Total > 0)
                {
                    PageSize = Total;
                }
                else if (Total == 0)
                {
                    return (0, null);
                }

                if (order == null)
                {
                    var res = await Task.Run(() => expression == null ? query
                   .Skip(countForSkip).Take(PageSize).AsNoTracking() : query
                   .Where(expression).Skip(countForSkip).Take(PageSize).AsNoTracking());
                    if (includes != null && includes.Length > 0)
                        foreach (Expression<Func<T, object>> include in includes)
                            res = res.Include(include.AsPath()).AsNoTracking();
                    if (PropertyIsExisted("CreatedByNavigation", "ModifiedByNavigation"))
                    {
                        res = res.Include("CreatedByNavigation");
                        res = res.Include("ModifiedByNavigation");
                    }
                    //string str = res.ToSql();

                    return (Total, res.AsNoTracking());
                }
                else
                {
                    if (OrderType == OrderTypeEnum.Asc)
                    {
                        var res = await Task.Run(() => expression == null ? query.OrderBy(order)
                                 .Skip(countForSkip).Take(PageSize).AsNoTracking() : query.OrderBy(order)
                                 .Where(expression).Skip(countForSkip).Take(PageSize).AsNoTracking());
                        if (includes != null && includes.Length > 0)
                            foreach (Expression<Func<T, object>> include in includes)
                                res = res.Include(include.AsPath()).AsNoTracking();
                        if (PropertyIsExisted("CreatedByNavigation", "ModifiedByNavigation") && includeUser)
                        {
                            res = res.Include("CreatedByNavigation");
                            res = res.Include("ModifiedByNavigation");
                        }
                        //string str = res.ToSql();

                        return (Total, res.AsNoTracking());
                    }
                    else
                    {
                        var res = await Task.Run(() => expression == null ? query.OrderByDescending(order)
                 .Skip(countForSkip).Take(PageSize).AsNoTracking() : query.OrderByDescending(order)
                 .Where(expression).Skip(countForSkip).Take(PageSize).AsNoTracking());
                        if (includes != null && includes.Length > 0)
                            foreach (Expression<Func<T, object>> include in includes)
                                res = res.Include(include.AsPath()).AsNoTracking();
                        if (PropertyIsExisted("CreatedByNavigation", "ModifiedByNavigation") && includeUser)
                        {
                            res = res.Include("CreatedByNavigation");
                            res = res.Include("ModifiedByNavigation");
                        }
                        //string str = res.ToSql();

                        return (Total, res.AsNoTracking());
                    }
                }



                //string name = typeof(T).Name;



            }
            catch (Exception ex)
            {
                Debug.WriteLine($"GetByConditionAsync err : {ex.ToString()}");
                throw;
            }
        }

        public async Task<(int total, IQueryable<T> List)> GetByConditionAsync(Expression<Func<T, bool>> expression,
            Expression<Func<T, long?>> order, OrderTypeEnum OrderType, int pageIndex, int PageSize, bool includeUser = true, params Expression<Func<T, object>>[] includes)
        {
            try
            {

                IQueryable<T> query = Context.Set<T>().AsNoTracking();

                int countForSkip = (pageIndex) * PageSize;

                int Total = expression == null ? await query.CountAsync() : await query.Where(expression).CountAsync();

                if (PageSize == 0 && Total > 0)
                {
                    PageSize = Total;
                }
                else if (Total == 0)
                {
                    return (0, null);
                }

                if (order == null)
                {
                    var res = await Task.Run(() => expression == null ? query
                   .Skip(countForSkip).Take(PageSize).AsNoTracking() : query
                   .Where(expression).Skip(countForSkip).Take(PageSize).AsNoTracking());
                    if (includes != null && includes.Length > 0)
                        foreach (Expression<Func<T, object>> include in includes)
                            res = res.Include(include.AsPath()).AsNoTracking();
                    if (PropertyIsExisted("CreatedByNavigation", "ModifiedByNavigation"))
                    {
                        res = res.Include("CreatedByNavigation");
                        res = res.Include("ModifiedByNavigation");
                    }
                    //string str = res.ToSql();

                    return (Total, res.AsNoTracking());
                }
                else
                {
                    if (OrderType == OrderTypeEnum.Asc)
                    {
                        var res = await Task.Run(() => expression == null ? query.OrderBy(order)
                                 .Skip(countForSkip).Take(PageSize).AsNoTracking() : query.OrderBy(order)
                                 .Where(expression).Skip(countForSkip).Take(PageSize).AsNoTracking());

                        if (includes != null && includes.Length > 0)
                            foreach (Expression<Func<T, object>> include in includes)
                                res = res.Include(include.AsPath()).AsNoTracking();
                        if (PropertyIsExisted("CreatedByNavigation", "ModifiedByNavigation") && includeUser)
                        {
                            res = res.Include("CreatedByNavigation");
                            res = res.Include("ModifiedByNavigation");
                        }
                        //string str = res.ToSql();

                        return (Total, res.AsNoTracking());
                    }
                    else
                    {
                        var res = await Task.Run(() => expression == null ? query.OrderByDescending(order)
                 .Skip(countForSkip).Take(PageSize).AsNoTracking() : query.OrderByDescending(order)
                 .Where(expression).Skip(countForSkip).Take(PageSize).AsNoTracking());
                        if (includes != null && includes.Length > 0)
                            foreach (Expression<Func<T, object>> include in includes)
                                res = res.Include(include.AsPath()).AsNoTracking();
                        if (PropertyIsExisted("CreatedByNavigation", "ModifiedByNavigation") && includeUser)
                        {
                            res = res.Include("CreatedByNavigation");
                            res = res.Include("ModifiedByNavigation");
                        }
                        //string str = res.ToSql();

                        return (Total, res.AsNoTracking());
                    }

                }



                //string name = typeof(T).Name;



            }
            catch (Exception ex)
            {
                Debug.WriteLine($"GetByConditionAsync err : {ex.ToString()}");
                throw;
            }
        }
        public async Task<(int total, IQueryable<T> List)> GetByConditionAsync(Expression<Func<T, bool>> expression,
                 string order, OrderTypeEnum OrderType, int pageIndex, int PageSize, bool includeUser = true, params Expression<Func<T, object>>[] includes)
        {
            try
            {

                IQueryable<T> query = Context.Set<T>().AsNoTracking();

                int countForSkip = (pageIndex) * PageSize;

                int Total = expression == null ? await query.CountAsync() : await query.Where(expression).CountAsync();

                if (PageSize == 0 && Total > 0)
                {
                    PageSize = Total;
                }
                else if (Total == 0)
                {
                    return (0, null);
                }

                if (string.IsNullOrEmpty(order))
                {
                    var res = await Task.Run(() => expression == null ? query
                   .Skip(countForSkip).Take(PageSize).AsNoTracking() : query
                   .Where(expression).Skip(countForSkip).Take(PageSize).AsNoTracking());
                    foreach (Expression<Func<T, object>> include in includes)
                        res = res.Include(include.AsPath()).AsNoTracking();
                    if (PropertyIsExisted("CreatedByNavigation", "ModifiedByNavigation"))
                    {
                        res = res.Include("CreatedByNavigation");
                        res = res.Include("ModifiedByNavigation");
                    }
                    //string str = res.ToSql();

                    return (Total, res.AsNoTracking());
                }
                else
                {

                    IQueryable<T> res = null;
                    if (OrderType == OrderTypeEnum.Asc)
                    {
                        res = await Task.Run(
                        () => expression == null ? query.OrderBy(order)
                             .Skip(countForSkip).Take(PageSize).AsNoTracking() : query.OrderBy(order)
                             .Where(expression).Skip(countForSkip).Take(PageSize).AsNoTracking()
                             );

                    }
                    else
                    {
                        try
                        {
                            res = await Task.Run(
                        () => expression == null ? query.OrderBy(order + " descending")
                             .Skip(countForSkip).Take(PageSize).AsNoTracking() : query.OrderBy(order + " descending")
                             .Where(expression).Skip(countForSkip).Take(PageSize).AsNoTracking()
                             );
                        }
                        catch
                        {
                            res = await Task.Run(
                        () => expression == null ? query
                             .Skip(countForSkip).Take(PageSize).AsNoTracking() : query
                             .Where(expression).Skip(countForSkip).Take(PageSize).AsNoTracking()
                             );
                        }


                    }

                    foreach (Expression<Func<T, object>> include in includes)
                        res = res.Include(include.AsPath()).AsNoTracking();
                    if (PropertyIsExisted("CreatedByNavigation", "ModifiedByNavigation") && includeUser)
                    {
                        res = res.Include("CreatedByNavigation");
                        res = res.Include("ModifiedByNavigation");
                    }
                    //string str = res.ToSql();

                    return (Total, res.AsNoTracking());

                    //   if (OrderType == OrderTypeEnum.Asc)
                    //   {
                    //       var res = await Task.Run(() => expression == null ? query.OrderBy(order)
                    //                .Skip(countForSkip).Take(PageSize).AsNoTracking() : query.OrderBy(order)
                    //                .Where(expression).Skip(countForSkip).Take(PageSize).AsNoTracking());

                    //       foreach (Expression<Func<T, object>> include in includes)
                    //           res = res.Include(include.AsPath()).AsNoTracking();
                    //       if (PropertyIsExisted("CreatedByNavigation", "ModifiedByNavigation") && includeUser)
                    //       {
                    //           res = res.Include("CreatedByNavigation");
                    //           res = res.Include("ModifiedByNavigation");
                    //       }
                    //       //string str = res.ToSql();

                    //       return (Total, res.AsNoTracking());
                    //   }
                    //   else
                    //   {
                    //       var res = await Task.Run(() => expression == null ? query.OrderByDescending(order)
                    //.Skip(countForSkip).Take(PageSize).AsNoTracking() : query.OrderByDescending(order)
                    //.Where(expression).Skip(countForSkip).Take(PageSize).AsNoTracking());
                    //       foreach (Expression<Func<T, object>> include in includes)
                    //           res = res.Include(include.AsPath()).AsNoTracking();
                    //       if (PropertyIsExisted("CreatedByNavigation", "ModifiedByNavigation") && includeUser)
                    //       {
                    //           res = res.Include("CreatedByNavigation");
                    //           res = res.Include("ModifiedByNavigation");
                    //       }
                    //       //string str = res.ToSql();

                    //       return (Total, res.AsNoTracking());
                    //   }

                }



                //string name = typeof(T).Name;



            }
            catch (Exception ex)
            {
                Debug.WriteLine($"GetByConditionAsync err : {ex.ToString()}");
                throw;
            }
        }

        public async Task<(int total, IQueryable<T> List)> GetByConditionAsync(Expression<Func<T, bool>> expression,
            Expression<Func<T, bool?>> order, OrderTypeEnum OrderType, int pageIndex, int PageSize, bool includeUser = true, params Expression<Func<T, object>>[] includes)
        {
            try
            {

                IQueryable<T> query = Context.Set<T>().AsNoTracking();

                int countForSkip = (pageIndex) * PageSize;

                int Total = expression == null ? await query.CountAsync() : await query.Where(expression).CountAsync();

                if (PageSize == 0 && Total > 0)
                {
                    PageSize = Total;
                }
                else if (Total == 0)
                {
                    return (0, null);
                }

                if (order == null)
                {
                    var res = await Task.Run(() => expression == null ? query
                   .Skip(countForSkip).Take(PageSize).AsNoTracking() : query
                   .Where(expression).Skip(countForSkip).Take(PageSize).AsNoTracking());
                    foreach (Expression<Func<T, object>> include in includes)
                        res = res.Include(include.AsPath()).AsNoTracking();
                    if (PropertyIsExisted("CreatedByNavigation", "ModifiedByNavigation"))
                    {
                        res = res.Include("CreatedByNavigation");
                        res = res.Include("ModifiedByNavigation");
                    }
                    //string str = res.ToSql();

                    return (Total, res.AsNoTracking());
                }
                else
                {
                    if (OrderType == OrderTypeEnum.Asc)
                    {
                        var res = await Task.Run(() => expression == null ? query.OrderBy(order)
                                 .Skip(countForSkip).Take(PageSize).AsNoTracking() : query.OrderBy(order)
                                 .Where(expression).Skip(countForSkip).Take(PageSize).AsNoTracking());

                        foreach (Expression<Func<T, object>> include in includes)
                            res = res.Include(include.AsPath()).AsNoTracking();
                        if (PropertyIsExisted("CreatedByNavigation", "ModifiedByNavigation") && includeUser)
                        {
                            res = res.Include("CreatedByNavigation");
                            res = res.Include("ModifiedByNavigation");
                        }
                        //string str = res.ToSql();

                        return (Total, res.AsNoTracking());
                    }
                    else
                    {
                        var res = await Task.Run(() => expression == null ? query.OrderByDescending(order)
                 .Skip(countForSkip).Take(PageSize).AsNoTracking() : query.OrderByDescending(order)
                 .Where(expression).Skip(countForSkip).Take(PageSize).AsNoTracking());
                        foreach (Expression<Func<T, object>> include in includes)
                            res = res.Include(include.AsPath()).AsNoTracking();
                        if (PropertyIsExisted("CreatedByNavigation", "ModifiedByNavigation") && includeUser)
                        {
                            res = res.Include("CreatedByNavigation");
                            res = res.Include("ModifiedByNavigation");
                        }
                        //string str = res.ToSql();

                        return (Total, res.AsNoTracking());
                    }

                }



                //string name = typeof(T).Name;



            }
            catch (Exception ex)
            {
                Debug.WriteLine($"GetByConditionAsync err : {ex.ToString()}");
                throw;
            }
        }

        public async Task<(int total, IQueryable<T> List)> GetByConditionAsync(Expression<Func<T, bool>> expression,
            Expression<Func<T, string>> order, OrderTypeEnum OrderType, int pageIndex, int PageSize, bool includeUser = true, params Expression<Func<T, object>>[] includes)
        {
            try
            {
                IQueryable<T> query = Context.Set<T>().AsNoTracking();

                int countForSkip = (pageIndex) * PageSize;

                int Total = expression == null ? await query.CountAsync() : await query.Where(expression).CountAsync();

                if (PageSize == 0 && Total > 0)
                {
                    PageSize = Total;
                }
                else if (Total == 0)
                {
                    return (0, null);
                }

                if (order == null)
                {
                    var res = await Task.Run(() => expression == null ? query
                   .Skip(countForSkip).Take(PageSize).AsNoTracking() : query
                   .Where(expression).Skip(countForSkip).Take(PageSize).AsNoTracking());
                    if (includes != null && includes.Length > 0)
                        foreach (Expression<Func<T, object>> include in includes)
                            res = res.Include(include.AsPath()).AsNoTracking();
                    if (PropertyIsExisted("CreatedByNavigation", "ModifiedByNavigation"))
                    {
                        res = res.Include("CreatedByNavigation");
                        res = res.Include("ModifiedByNavigation");
                    }
                    //string str = res.ToSql();

                    return (Total, res.AsNoTracking());
                }
                else
                {

                    if (OrderType == OrderTypeEnum.Asc)
                    {
                        var res = await Task.Run(() => expression == null ?
                        query.OrderBy(order)
                       .Skip(countForSkip).Take(PageSize).AsNoTracking() :

                        query.OrderBy(order)
                       .Where(expression).Skip(countForSkip).Take(PageSize).AsNoTracking());

                        if (includes != null && includes.Length > 0)
                            foreach (Expression<Func<T, object>> include in includes)
                                res = res.Include(include.AsPath()).AsNoTracking();
                        if (PropertyIsExisted("CreatedByNavigation", "ModifiedByNavigation") && includeUser)
                        {
                            res = res.Include("CreatedByNavigation");
                            res = res.Include("ModifiedByNavigation");
                        }
                        //string str = res.ToSql();

                        return (Total, res.AsNoTracking());
                    }
                    else
                    {
                        var res = await Task.Run(() => expression == null ?
                        query.OrderByDescending(order)
                       .Skip(countForSkip).Take(PageSize).AsNoTracking() :

                        query.OrderByDescending(order)
                       .Where(expression).Skip(countForSkip).Take(PageSize).AsNoTracking());

                        if (includes != null && includes.Length > 0)
                            foreach (Expression<Func<T, object>> include in includes)
                                res = res.Include(include.AsPath()).AsNoTracking();
                        if (PropertyIsExisted("CreatedByNavigation", "ModifiedByNavigation") && includeUser)
                        {
                            res = res.Include("CreatedByNavigation");
                            res = res.Include("ModifiedByNavigation");
                        }
                        //string str = res.ToSql();

                        return (Total, res.AsNoTracking());
                    }

                }



                //string name = typeof(T).Name;



            }
            catch (Exception ex)
            {
                Debug.WriteLine($"GetByConditionAsync err : {ex.ToString()}");
                throw;
            }
        }


        #endregion

        #region[factor]
        public async Task<(int total, IQueryable<T> List)> GetByConditionAsync(RepositoryFilterDTO<T> repositoryFilterDTO, params Expression<Func<T, object>>[] includes)
        {
            try
            {
                IQueryable<T> query = Context.Set<T>();

                int countForSkip = (repositoryFilterDTO.PageIndex) * repositoryFilterDTO.PageSize;

                int Total = repositoryFilterDTO.expression != null ? await query.Where(repositoryFilterDTO.expression).AsNoTracking().CountAsync() : await query.AsNoTracking().CountAsync();

                if (repositoryFilterDTO.PageSize == 0 && Total > 0)
                {
                    repositoryFilterDTO.PageSize = Total;
                }
                else if (Total == 0)
                {
                    return (0, null);
                }

                var res = await Task.Run(() => repositoryFilterDTO.expression == null ? Context.Set<T>()
                   .Skip(countForSkip).Take(repositoryFilterDTO.PageSize) :
                   query.Where(repositoryFilterDTO.expression).Skip(countForSkip).Take(repositoryFilterDTO.PageSize));
                //
                //var result = res.Include(includes);
                if (includes != null)
                    foreach (Expression<Func<T, object>> include in includes)
                        res = res.Include(include.AsPath());

                string name = typeof(T).Name;

                if (PropertyIsExisted("CreatedByNavigation", "ModifiedByNavigation") && repositoryFilterDTO.includeUser)
                {
                    res = res.AsNoTracking().Include("CreatedByNavigation").AsNoTracking();
                    res = res.AsNoTracking().Include("ModifiedByNavigation").AsNoTracking();
                }
                //string str = res.ToSql();

                return (Total, (repositoryFilterDTO.withTraking == true) ? res : res.AsNoTracking());
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"GetByConditionAsync err : {ex.ToString()}");
                throw;
            }
        }

        #endregion

        #region CRUD
        public async Task<T> InsertAsync(T entity)
        {
            // Context.Entry(entity).State = EntityState.Detached;
            if (PropertyIsExisted("CreatedByNavigation"))
            {
                entity.GetType().GetProperty("CreatedByNavigation").SetValue(entity, null);
                entity.GetType().GetProperty("CreatedDate").SetValue(entity, DateTime.Now);
            }
            if (PropertyIsExisted("ModifiedByNavigation"))
            {
                entity.GetType().GetProperty("ModifiedByNavigation").SetValue(entity, null);
            }
            if (PropertyIsExisted("ModifiedBy"))
            {
                entity.GetType().GetProperty("ModifiedBy").SetValue(entity, null);
            }
            if (PropertyIsExisted("ModifiedDate"))
            {
                entity.GetType().GetProperty("ModifiedDate").SetValue(entity, null);
            }

            var result = await Context.AddAsync(entity);
            return entity;
        }

        public async Task<IQueryable<T>> BulkInsertAsync(IQueryable<T> entitities)
        {
            try
            {
                await Context.AddRangeAsync(entitities.AsNoTracking());
                return entitities.AsQueryable();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<T> UpdateAsync(T entity, params Expression<Func<T, object>>[] Excludes)
        {
            //if (PropertyIsExisted("CreatedByNavigation"))
            //{
            //    entity.GetType().GetProperty("CreatedByNavigation").SetValue(entity, null);
            //}
            if (PropertyIsExisted("ModifiedByNavigation"))
            {
                entity.GetType().GetProperty("ModifiedDate").SetValue(entity, DateTime.Now);
            }
            //if (PropertyIsExisted("ModifiedBy"))
            //{
            //    entity.GetType().GetProperty("ModifiedBy").SetValue(entity, null);
            //}
            //if (PropertyIsExisted("ModifiedDate"))
            //{
            //    entity.GetType().GetProperty("ModifiedDate").SetValue(entity, null);
            //}
            if (PropertyIsExisted("CreatedBy"))
            {
                Context.Entry(entity).Property("CreatedBy").IsModified = false;
            }

            await Task.Run(() => Context.Set<T>().Attach(entity));

            Context.Entry(entity).State = EntityState.Modified;
            foreach (var Exclude in Excludes)
            {
                Context.Entry(entity).Property(Exclude.AsPath()).IsModified = false;
            }

            return entity;
        }
        public async Task<T> UpdateAsync(T entity)
        {
            //if (PropertyIsExisted("CreatedByNavigation"))
            //{
            //    entity.GetType().GetProperty("CreatedByNavigation").SetValue(entity, null);
            //}
            if (PropertyIsExisted("ModifiedByNavigation"))
            {
                entity.GetType().GetProperty("ModifiedDate").SetValue(entity, DateTime.Now);
            }
            //if (PropertyIsExisted("ModifiedBy"))
            //{
            //    entity.GetType().GetProperty("ModifiedBy").SetValue(entity, null);
            //}
            //if (PropertyIsExisted("ModifiedDate"))
            //{
            //    entity.GetType().GetProperty("ModifiedDate").SetValue(entity, null);
            //}
            if (PropertyIsExisted("CreatedBy"))
            {
                Context.Entry(entity).Property("CreatedBy").IsModified = false;
            }

            await Task.Run(() => Context.Set<T>().Attach(entity));

            Context.Entry(entity).State = EntityState.Modified;


            return entity;
        }

        public async Task<IQueryable<T>> PatchUpdateAsync(IQueryable<T> entitities)
        {
            try
            {
                await Task.Run(() => Context.Set<T>().UpdateRange(entitities.AsNoTracking().ToList()));
                Context.Entry(entitities.ToList()).State = EntityState.Modified;
                return entitities.AsQueryable();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            await Task.Run(() => Context.Remove(entity));
            return true;
        }

        public async Task<bool> BulkDeleteAsync(IQueryable<T> entitities)
        {
            await Task.Run(() => Context.RemoveRange(entitities.AsNoTracking()));
            return true;
        }

        #endregion


        private bool PropertyIsExisted(params string[] propertyNames)
        {
            string name = typeof(T).Name;

            var tblProperties = Context
                .GetType()
                .GetProperties()
                .Where(p =>
                    p.PropertyType.IsGenericType &&
                    p.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>))
                .Select(p => p.PropertyType.GetGenericArguments()[0])
                .Where(t => t.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                .SelectMany(t => t.GetProperties())
                .ToArray();
            bool[] array = new bool[propertyNames.Count()];
            int index = 0;
            foreach (var item in propertyNames)
            {
                array[index] = tblProperties.Any(x => x.Name == item);
                if (array[index] == false)
                {
                    break;
                }
                index++;
            }
            if (array.Contains(false))
                return false;
            else return true;
        }

        public async Task<IQueryable<T>> ReadStored(params KeyValuePair<string, string>[] Params)
        {
            string StoredName = typeof(T).Name;
            string Parameters = "";
            string Comma = ",";
            string Value;
            foreach (var item in Params)
            {
                Value = item.Value;
                if (string.IsNullOrEmpty(Value))
                {
                    Value = "NULL";
                }
                Parameters += $" @{item.Key}={Value} {Comma}";
            }
            if ((!string.IsNullOrEmpty(Parameters))&&Parameters.Last() == ',')
            {
                Parameters=Parameters.Remove(Parameters.Length-1);
            }
            if (Params.Count() == 1)
            {
                Parameters = Parameters.Replace('"', ' ');
            }
            return  Context.Set<T>().FromSqlRaw($"EXECUTE [dbo].[{StoredName}] {Parameters}");
        }

        public void Detached(T entity)
        {
            Context.Entry(entity).State = EntityState.Detached;
            Context.Entry(entity).State = EntityState.Unchanged;
        }

        public void DetachAll()
        {
            EntityEntry[] entityEntries = Context.ChangeTracker.Entries().ToArray();

            foreach (EntityEntry entityEntry in entityEntries)
            {
                entityEntry.State = EntityState.Detached;
            }
        }

    }
}
