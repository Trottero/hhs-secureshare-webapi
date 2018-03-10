using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SecureShare.WebAPI.Core.Entities;
using SecureShare.WebAPI.Core.Interfaces;

namespace SecureShare.WebAPI.Infrastructure.Repositories
{
    public class UserFileRepository : Repository<UserFile>, IUserFileRepository
    {
        public UserFileRepository(SecureShareWebAPIContext context) : base(context)
        {
        }

        public Task<UserFile> GetUserFileWithUserAsync(Guid id)
        {
            return base.GetOneAsync(null, e => e.Include(o => o.Owner));
        }

        public Task<IEnumerable<UserFile>> GetAllWithOwnerAndSharedWithAsync()
        {
            return GetAsync(null, null, e => e.Include(o => o.Owner).Include(z => z.SharedWith));
        }
    }
}
