using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SecureShare.WebAPI.Core.Entities;

namespace SecureShare.WebAPI.Infrastructure.Interfaces
{
    public interface IUserFileService : IEntityService<UserFile>
    {
        Task<UserFile> GetUserFileWithUser(Guid id);
    }
}
