using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SecureShare.WebAPI.Core.Entities;
using SecureShare.WebAPI.Core.Interfaces;
using SecureShare.WebAPI.Infrastructure.Interfaces;

namespace SecureShare.WebAPI.Services.Services
{
    public class UserService : EntityService<User>, IUserService
    {
        public UserService(IRepository<User> userRepository):base(userRepository)
        {
        }
        public async Task<User> GetUserWithSharedFilesAsync(Guid id)
        {
            return (await GetAsync(e => e.UserId == id, null,
                e => e.Include(f => f.Files).Include(z => z.FilesSharedWithUser))).SingleOrDefault();
        }

        public async Task<IEnumerable<User>> GetAllUserWithSharedFilesAsync()
        {
            return await GetAsync(null, null, e => e.Include(f => f.Files).Include(z => z.FilesSharedWithUser));
        }
    }
}
