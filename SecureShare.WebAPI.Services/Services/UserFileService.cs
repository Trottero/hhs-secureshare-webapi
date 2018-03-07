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
    public class UserFileService : EntityService<UserFile>, IUserFileService
    {
        private readonly IRepository<UserFile> _userFileRepository;
        public UserFileService(IRepository<UserFile> userFileRepository) : base(userFileRepository)
        {
            _userFileRepository = userFileRepository;
        }

        public Task<UserFile> GetUserFileWithUserAsync(Guid id)
        {
            return _userFileRepository.GetOneAsync(null, e => e.Include(o => o.Owner));
        }

        public new Task<IEnumerable<UserFile>> GetAllAsync()
        {
            return GetAsync(null, null, e => e.Include(o => o.Owner).Include(z => z.SharedWith));
        }
    }
}
