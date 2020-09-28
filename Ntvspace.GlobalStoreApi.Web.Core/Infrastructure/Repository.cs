using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Ntvspace.GlobalStoreApi.Web.Core.Infrastructure
{
  public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
  {
    protected readonly DbContext _context;
    protected readonly DbSet<TEntity> _dbSet;

    public Repository(DbContext context)
    {
      _context = context;
      _dbSet = _context.Set<TEntity>();
    }

    public void Add(TEntity entity)
    {
      _dbSet.Add(entity);
    }

    public void AddRange(IEnumerable<TEntity> entities)
    {
      _dbSet.AddRange(entities);
    }

    public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
    {
      return _dbSet.Where(predicate);
    }

    public IEnumerable<TEntity> GetAll()
    {
      return _dbSet.Select(x => x).ToList();
    }

    public TEntity GetByKey(object key)
    {
      return _dbSet.Find(key);
    }

    public void Remove(TEntity entity)
    {
      _dbSet.Remove(entity);
    }

    public void RemoveRange(IEnumerable<TEntity> entities)
    {
      _dbSet.RemoveRange(entities);
    }

    public void SaveChanges()
    {
      _context.SaveChanges();
    }
  }
}
