using Exam.Application.ResponseModels.Pagination;
using Exam.Domain.Entites.Common;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Exam.Persistence.Contexts;
using Exam.Application.RequestParameters;
using Exam.Application.Extensions;
using Exam.Application.Repositories.Base;

namespace Exam.Persistence.Repositories.Base;
public class EfRepository<T, TPk> : IRepository<T, TPk> where T : class, IEntity<TPk>, new()
{
    private readonly ExamDbContext _context;
    public DbSet<T> Table => _context.Set<T>();

    public EfRepository(ExamDbContext context)
    {
        _context = context;
    }

    #region Read 
    public IQueryable<T> GetAll(bool tracking = false)
    {
        return tracking ? Table : Table.AsNoTracking();
    }

    public IQueryable<T> GetAll(Expression<Func<T, bool>> method, bool tracking = false, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
    {
        var query = tracking
            ? Table.Where(method)
            : Table.AsNoTracking().Where(method);

        if (orderBy != null)
            query = orderBy(query);

        return query;
    }

    public IQueryable<T> GetAll(Expression<Func<T, bool>> method, bool tracking = false, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, params Expression<Func<T, object>>[] includes)
    {
        var query = tracking
            ? Table.Where(method)
            : Table.AsNoTracking().Where(method);

        if (orderBy != null)
            query = orderBy(query);

        return includes
            .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
    }

    public async Task<PaginatedList<T>> GetAllWithPaginationAsync(
       bool tracking = false,
       Pagination pagination = default,
       Expression<Func<T, bool>> method = null,
       Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
    {
        IQueryable<T> query = tracking
            ? Table
            : Table.AsNoTracking();

        if (method != null)
            query = query.Where(method);

        if (orderBy != null)
            query = orderBy(query);

        return await query.PaginatedListAsync(pagination);
    }

    public async Task<PaginatedList<T>> GetAllWithPaginationAsync(
       bool tracking = false,
       Pagination pagination = default,
       Expression<Func<T, bool>> method = null,
       Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
       params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = tracking
            ? Table
            : Table.AsNoTracking();

        if (method != null)
            query = query.Where(method);

        if (orderBy != null)
            query = orderBy(query);

        query = includes
            .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

        return await query.PaginatedListAsync(pagination);
    }
    #endregion

    #region GetSingle 
    public async Task<T?> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = false)
    {
        return tracking
            ? await Table.FirstOrDefaultAsync(method)
            : await Table.AsNoTracking().FirstOrDefaultAsync(method);
    }

    public async Task<T?> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = false, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, params Expression<Func<T, object>>[] includes)
    {
        var query = tracking
            ? Table.Where(method)
            : Table.AsNoTracking().Where(method);

        if (orderBy != null)
            query = orderBy(query);

        return await includes
            .Aggregate(query, (current, includeProperty) => current.Include(includeProperty))
            .FirstOrDefaultAsync();
    }

    public T? GetSingle(Expression<Func<T, bool>> method, bool tracking = false)
    {
        return tracking
            ? Table.FirstOrDefault(method)
            : Table.AsNoTracking().FirstOrDefault(method);
    }

    public T? GetSingle(Expression<Func<T, bool>> method, bool tracking = false, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, params Expression<Func<T, object>>[] includes)
    {
        var query = tracking
            ? Table.Where(method)
            : Table.AsNoTracking().Where(method);

        if (orderBy != null)
            query = orderBy(query);

        return includes
            .Aggregate(query, (current, includeProperty) => current.Include(includeProperty))
            .FirstOrDefault();
    }

    T? IRepository<T, TPk>.GetById(TPk id)
    {
        return Table.Find(id);
    }

    public async Task<T?> GetByIdAsync(TPk id)
    {
        return await Table.FindAsync(id);
    }
    #endregion

    #region Count  
    public async Task<int> CountAsync(Expression<Func<T, bool>> method)
    {
        return await Table.CountAsync(method);
    }

    public async Task<int> CountAsync()
    {
        return await Table.CountAsync();
    }

    public int Count(Expression<Func<T, bool>> method)
    {
        return Table.Count(method);
    }

    public int Count()
    {
        return Table.Count();
    }
    #endregion

    #region Exist
    public async Task<bool> ExistAsync(Expression<Func<T, bool>>? method = null)
    {
        return method == null ? await Table.AnyAsync() : await Table.AnyAsync(method);
    }

    public bool Exist(Expression<Func<T, bool>>? method = null)
    {
        return method == null ? Table.Any() : Table.Any(method);
    }

    #endregion

    #region Insert

    public async Task<T> AddAsync(T model, dynamic dynamicProperties = null)
    {
        SetDynamicProperties(model, dynamicProperties);
        var entityEntry = await Table.AddAsync(model);
        return entityEntry.State == EntityState.Added
            ? entityEntry.Entity
            : null;
    }

    public T Add(T model, dynamic dynamicProperties = null)
    {
        SetDynamicProperties(model, dynamicProperties);
        var entityEntry = Table.Add(model);
        return entityEntry.State == EntityState.Added
            ? entityEntry.Entity
            : null;
    }

    public async Task<bool> AddRangeAsync(IEnumerable<T> entities, dynamic dynamicProperties = null)
    {
        if (dynamicProperties != null)
        {
            foreach (T entity in entities)
            {
                SetDynamicProperties(entity, dynamicProperties);
            }
        }
        await Table.AddRangeAsync(entities);
        return true;
    }

    public bool AddRange(IEnumerable<T> entities, dynamic dynamicProperties = null)
    {
        if (dynamicProperties != null)
        {
            foreach (T entity in entities)
            {
                SetDynamicProperties(entity, dynamicProperties);
            }
        }
        Table.AddRange(entities);
        return true;
    }

    #endregion

    #region Remove

    public bool Remove(T model)
    {
        var entityEntry = Table.Remove(model);
        return entityEntry.State == EntityState.Deleted;
    }

    public bool RemoveRange(IEnumerable<T> entities)
    {
        Table.RemoveRange(entities);
        return true;
    }

    public void RemoveRange(Expression<Func<T, bool>> filter = null)
    {
        IQueryable<T> query = Table.AsQueryable();
        query = ApplyFilterToQuery(filter, query);
        List<T> entityToDelete = query.ToList();
        Table.RemoveRange(entityToDelete);
    }

    public async Task RemoveRangeAsync(Expression<Func<T, bool>> filter = null)
    {
        IQueryable<T> query = Table.AsQueryable();
        query = ApplyFilterToQuery(filter, query);
        List<T> entityToDelete = await query.ToListAsync();
        Table.RemoveRange(entityToDelete);
    }
    public void Remove(Expression<Func<T, bool>> filter = null)
    {
        IQueryable<T> query = Table.AsQueryable();
        query = ApplyFilterToQuery(filter, query);
        T entityToDelete = query.FirstOrDefault();
        if (entityToDelete != null)
            Table.RemoveRange(entityToDelete);
    }

    #endregion

    #region Update

    public T Update(T model)
    {
        var entityEntry = Table.Update(model);
        return entityEntry.State == EntityState.Modified
            ? entityEntry.Entity
            : null;
    }

    public T UpdateDeleted(object id, dynamic obj = null)
    {
        T newEntity = Table.Find(id);
        SetDynamicProperties(newEntity, obj);
        _context.Entry(newEntity).State = EntityState.Detached;
        return Update(newEntity);
    }

    public async Task<T> UpdateDeletedAsync(object id, dynamic obj = null)
    {
        T newEntity = await Table.FindAsync(id);
        SetDynamicProperties(newEntity, obj);
        _context.Entry(newEntity).State = EntityState.Detached;
        return Update(newEntity);
    }


    #endregion

    #region Save

    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public int Save()
    {
        return _context.SaveChanges();
    }

    #endregion

    #region Helper Methods  
    private void SetDynamicProperties(T entity, dynamic dynamicProperties)
    {
        if (dynamicProperties != null)
        {
            var entityType = typeof(T);

            var properties = dynamicProperties.GetType().GetProperties();

            foreach (var property in properties)
            {
                dynamic prop = entityType.GetProperty(property.Name);
                dynamic value = dynamicProperties.GetType().GetProperty(property.Name).GetValue(dynamicProperties, null);
                if (prop != null)
                    prop.SetValue(entity, value);
            }
        }
    }
    private IQueryable<T> ApplyFilterToQuery<T>(Expression<Func<T, bool>> filter, IQueryable<T> query) where T : class
    {
        if (filter != null)
        {
            query = query.Where(filter);
        }

        return query;
    }
    #endregion


}
public class EfRepository<T> : EfRepository<T, int> where T : class, IEntity<int>, new()
{
    public EfRepository(ExamDbContext context) : base(context)
    {
    }
}