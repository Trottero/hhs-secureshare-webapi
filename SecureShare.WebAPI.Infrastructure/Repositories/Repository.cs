using System.Threading.Tasks;
using SecureShare.WebAPI.Core.Entities;
using SecureShare.WebAPI.Core.Interfaces;

namespace SecureShare.WebAPI.Infrastructure.Repositories
{
    public class Repository<TEntity> : ReadOnlyRepository<TEntity>, IRepository<TEntity> where TEntity : Entity
    {
        public Repository(SecureShareWebAPIContext context) : base(context)
        {
        }

        public async Task<TEntity> AddAsync(TEntity obj)
        {
            await _dbSet.AddAsync(obj);
            await SaveAsync();
            return obj;
        }

        public async Task<TEntity> DeleteAsync(object id)
        {
            TEntity objectToDelete = await _dbSet.FindAsync(id);
            _dbSet.Remove(objectToDelete);
            await SaveAsync();
            return objectToDelete;
        }

        public async Task<TEntity> DeleteAsync(TEntity obj)
        {
            _dbSet.Remove(obj);
            await SaveAsync();
            return obj;
        }

        public async Task<TEntity> UpdateAsync(TEntity obj)
        {
            _dbSet.Update(obj);
            await SaveAsync();
            return obj;
        }

        private async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}