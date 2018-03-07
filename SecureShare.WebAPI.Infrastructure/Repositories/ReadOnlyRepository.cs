using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SecureShare.WebAPI.Core.Entities;
using SecureShare.WebAPI.Core.Interfaces;

namespace SecureShare.WebAPI.Infrastructure.Repositories
{
    public class ReadOnlyRepository<TEntity> : IReadOnlyRepository<TEntity> where TEntity : Entity
    {
        protected readonly SecureShareWebAPIContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public ReadOnlyRepository(SecureShareWebAPIContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        protected virtual IQueryable<TEntity> GetQueryable(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IQueryable<TEntity>> includes = null,
            int? take = null,
            int? skip = null)
        {
            var query = _dbSet.AsQueryable();

            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (includes != null)
            {
                query = includes(query);
            }
            if (orderBy != null)
            {
                query = orderBy(query);
            }
            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }
            if (skip.HasValue)
            {
                query = query.Skip(skip.Value);
            }

            return query;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync(
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IQueryable<TEntity>> includes = null,
            int? take = null,
            int? skip = null)
        {
            return await GetQueryable(null, orderBy, includes, take, skip).ToListAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IQueryable<TEntity>> includes = null,
            int? take = null,
            int? skip = null)
        {
            return await GetQueryable(filter, orderBy, includes, take, skip).ToListAsync();
        }

        public virtual async Task<TEntity> GetOneAsync(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IQueryable<TEntity>> includes = null)
        {
            return await GetQueryable(filter, null, includes).SingleOrDefaultAsync();
        }

        public virtual async Task<TEntity> GetFirstAsync(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IQueryable<TEntity>> includes = null)
        {
            return await GetQueryable(filter, orderBy, includes).FirstOrDefaultAsync();
        }

        public virtual Task<TEntity> GetByIdAsync(object id)
        {
            return _dbSet.FindAsync(id);
        }

        public virtual Task<TEntity> GetByMultipleIdsAsync(object id1, object id2)
        {
            return _dbSet.FindAsync(id1, id2);
        }

        public virtual Task<int> GetCountAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            return GetQueryable(filter).CountAsync();
        }

        public virtual Task<bool> GetExistsAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            return GetQueryable(filter).AnyAsync();
        }
    }
}