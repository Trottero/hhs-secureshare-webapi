using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SecureShare.WebAPI.Core.Entities;

namespace SecureShare.WebAPI.Infrastructure.Interfaces
{
    public interface IUserService : IEntityService<User>
    {
        Task<User> GetUserWithSharedFilesAsync(Guid id);
        Task<IEnumerable<User>> GetAllUserWithSharedFilesAsync();
    }
}
