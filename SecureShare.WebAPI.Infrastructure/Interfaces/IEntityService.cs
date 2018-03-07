using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SecureShare.WebAPI.Core.Entities;

namespace SecureShare.WebAPI.Infrastructure.Interfaces
{
    public interface IEntityService<TEntity> where TEntity : Entity
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IQueryable<TEntity>> includes = null,
            int? skip = null,
            int? take = null);
        Task<TEntity> GetByIdAsync(object entityId);
        Task<TEntity> GetByMultipleIdsAsync(object id1, object id2);

        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task DeleteAsync(object entityId);
        Task DeleteAsync(TEntity entity);
        Task<bool> GetExistsAsync(object id);
        Task<bool> GetExistsMultipleAsync(object id1, object id2);


    }
}
