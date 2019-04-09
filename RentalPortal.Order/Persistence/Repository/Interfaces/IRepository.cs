using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RentalPortal.Order.Persistence.Repository.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        void Remove(TEntity entity);
        TEntity Get(int entityId);
        TEntity Get(Guid entityGuid);
        Task<TEntity> GetAsync(int entityId);
        Task<TEntity> GetAsync(Guid entityGuid);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        Task<List<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);
        Task<IQueryable<TEntity>> QueryAsync(Expression<Func<TEntity, bool>> predicate);

    }
}
