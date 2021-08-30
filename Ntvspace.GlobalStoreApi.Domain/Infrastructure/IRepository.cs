using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Ntvspace.GlobalStoreApi.Web.Domain.Infrastructure
{
  /// <summary>
  /// Provides an abstraction oto manage generic entities.
  /// </summary>
  /// <typeparam name="TEntity"></typeparam>
  public interface IRepository<TEntity> where TEntity : class
  {
    IEnumerable<TEntity> GetAll();
    TEntity GetByKey(object key);
    IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

    void Add(TEntity entity);
    void AddRange(IEnumerable<TEntity> entities);

    void Remove(TEntity entity);
    void RemoveRange(IEnumerable<TEntity> entities);
    void SaveChanges();
  }
}
