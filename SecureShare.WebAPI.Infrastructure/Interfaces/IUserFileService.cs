using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SecureShare.WebAPI.Core.Entities;

namespace SecureShare.WebAPI.Infrastructure.Interfaces
{
    public interface IUserFileService : IEntityService<UserFile>
    {
        Task<UserFile> GetUserFileWithUserAsync(Guid id);

        Task<IEnumerable<UserFile>> GetAllWithOwnerAndSharedWithAsync();
        Task<IEnumerable<UserFile>> GetFromUserAndSharedWithAsync(Guid id);
    }
}
