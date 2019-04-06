using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RentalPortal.Order.Persistence.Repository
{




    public class Repository<TEntity, TContext> where TEntity : class where TContext : DbContext, new()
    {
        protected TContext Context;

        private readonly DbSet<TEntity> _entitySet;

        protected Repository(TContext context)
        {
            Context = context;
            _entitySet = context.Set<TEntity>();

        }

        public TEntity Get(int entityId)
        {
            return _entitySet.Find(entityId);
        }

        public TEntity Get(Guid entityGuid)
        {
            return _entitySet.Find(entityGuid);
        }

        public Task<TEntity> GetAsync(int entityId)
        {
            return _entitySet.FindAsync(entityId);
        }

        public Task<TEntity> GetAsync(Guid entityGuid)
        {
            return _entitySet.FindAsync(entityGuid);
        }

        public Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return _entitySet.SingleOrDefaultAsync(predicate);
        }

        public void Remove(TEntity entity)
        {
            _entitySet.Remove(entity);
        }


        public void Add(TEntity entity)
        {
            _entitySet.Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _entitySet.AddRange(entities);
        }

        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _entitySet.Where(predicate).AsNoTracking();
        }

        public Task<List<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return _entitySet.Where(predicate).ToListAsync();
        }
        public Task<IQueryable<TEntity>> QueryAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return Task.Run(() => _entitySet.Where(predicate).AsQueryable());
        }




    }
}
