using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SecureShare.WebAPI.Core.Entities;

namespace SecureShare.WebAPI.Core.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetUserWithSharedFilesAsync(Guid id);
        Task<IEnumerable<User>> GetAllUserWithSharedFilesAsync();
    }
}
