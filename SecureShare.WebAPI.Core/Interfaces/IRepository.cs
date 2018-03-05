using System.Threading.Tasks;
using SecureShare.WebAPI.Core.Entities;

namespace SecureShare.WebAPI.Core.Interfaces
{
    public interface IRepository<TEntity> : IReadOnlyRepository<TEntity> where TEntity : Entity
    {
        Task<TEntity> AddAsync(TEntity obj);
        Task<TEntity> UpdateAsync(TEntity obj);
        Task<TEntity> DeleteAsync(object id);
        Task<TEntity> DeleteAsync(TEntity obj);
    }
}
