using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SecureShare.WebAPI.Core.Entities;
using SecureShare.WebAPI.Core.Interfaces;
using SecureShare.WebAPI.Infrastructure.Interfaces;

namespace SecureShare.WebAPI.Services.Services
{
    public class EntityService<TEntity> : IEntityService<TEntity> where TEntity : Entity
    {
        private readonly IRepository<TEntity> _entityRepository;

        public EntityService(IRepository<TEntity> entityRepository)
        {
            _entityRepository = entityRepository;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            return await _entityRepository.AddAsync(entity);
        }

        public Task DeleteAsync(object entityId)
        {
            return _entityRepository.DeleteAsync(entityId);
        }

        public Task DeleteAsync(TEntity entity)
        {
            return _entityRepository.DeleteAsync(entity);
        }

        public Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return _entityRepository.GetAllAsync();
        }

        public Task<TEntity> GetByIdAsync(object id)
        {
            return _entityRepository.GetByIdAsync(id);
        }

        public Task<TEntity> GetByMultipleIdsAsync(object id1, object id2)
        {
            return _entityRepository.GetByMultipleIdsAsync(id1, id2);
        }

        public async Task<bool> GetExistsAsync(object id)
        {
            return await GetByIdAsync(id) != null;
        }

        public async Task<bool> GetExistsMultipleAsync(object id1, object id2)
        {
            return await GetByMultipleIdsAsync(id1, id2) != null;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            await _entityRepository.UpdateAsync(entity);
            return entity;
        }

    }
}
