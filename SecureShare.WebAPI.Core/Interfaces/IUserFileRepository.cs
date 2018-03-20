using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SecureShare.WebAPI.Core.Entities;

namespace SecureShare.WebAPI.Core.Interfaces
{
    public interface IUserFileRepository : IRepository<UserFile>
    {
        Task<UserFile> GetUserFileWithUserAsync(Guid id);
        Task<IEnumerable<UserFile>> GetAllWithOwnerAndSharedWithAsync();
        Task<IEnumerable<UserFile>> GetFromUserAndSharedWithAsync(Guid id);

    }
}
