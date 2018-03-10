using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SecureShare.WebAPI.Core.Entities;

namespace SecureShare.WebAPI.Core.Interfaces
{
    public interface IReadOnlyRepository<TEntity> where TEntity : Entity
    {
        Task<TEntity> GetByIdAsync(object id);
        Task<TEntity> GetByMultipleIdsAsync(object id1, object id2);

        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<int> GetCountAsync(Expression<Func<TEntity, bool>> filter = null);

        Task<bool> GetExistsAsync(Expression<Func<TEntity, bool>> filter = null);
    }
}
