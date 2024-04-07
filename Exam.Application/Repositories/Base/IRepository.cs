using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Exam.Application.ResponseModels.Pagination;
using Exam.Application.RequestParameters;
using Exam.Domain.Entites.Common;

namespace Exam.Application.Repositories.Base;
public interface IRepository<T, in TPk> where T : class, IEntity<TPk>, new()
{
    DbSet<T> Table { get; }

    #region Sync read methods
    IQueryable<T> GetAll(bool tracking = false);
    IQueryable<T> GetAll(Expression<Func<T, bool>> method, bool tracking = false, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null);
    IQueryable<T> GetAll(Expression<Func<T, bool>> method, bool tracking = false, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, params Expression<Func<T, object>>[] includes);

    T? GetSingle(Expression<Func<T, bool>> method, bool tracking = false);
    T? GetSingle(Expression<Func<T, bool>> method, bool tracking = false, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, params Expression<Func<T, object>>[] includes);

    T? GetById(TPk id);

    int Count(Expression<Func<T, bool>> method);
    int Count();

    bool Exist(Expression<Func<T, bool>>? method = null);

    #endregion

    #region Async read methods
    public Task<PaginatedList<T>> GetAllWithPaginationAsync(
       bool tracking = false,
       Pagination pagination = default,
       Expression<Func<T, bool>> method = null,
       Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null);

    public Task<PaginatedList<T>> GetAllWithPaginationAsync(
       bool tracking = false,
       Pagination pagination = default,
       Expression<Func<T, bool>> method = null,
       Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
       params Expression<Func<T, object>>[] includes);

    Task<T?> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = false);
    Task<T?> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = false, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, params Expression<Func<T, object>>[] includes);

    Task<T?> GetByIdAsync(TPk id);

    Task<int> CountAsync(Expression<Func<T, bool>> method);
    Task<int> CountAsync();

    Task<bool> ExistAsync(Expression<Func<T, bool>>? method = null);
    #endregion

    #region Sync write methods
    T Add(T model, dynamic dynamicProperties = null);
    bool AddRange(IEnumerable<T> entities, dynamic dynamicProperties = null);

    bool Remove(T model);
    bool RemoveRange(IEnumerable<T> entities);

    void RemoveRange(Expression<Func<T, bool>> filter = null);

    Task RemoveRangeAsync(Expression<Func<T, bool>> filter = null);

    void Remove(Expression<Func<T, bool>> filter = null);
    T Update(T model);
    T UpdateDeleted(object id, dynamic obj = null);

    Task<T> UpdateDeletedAsync(object id, dynamic obj = null);


    int Save();
    #endregion

    #region Async write methods
    Task<T> AddAsync(T model, dynamic dynamicProperties = null);
    Task<bool> AddRangeAsync(IEnumerable<T> entities, dynamic dynamicProperties = null);

    Task<int> SaveAsync();

    #endregion

}

public interface IRepository<T> : IRepository<T, int> where T : class, IEntity<int>, new()
{
}