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
        private readonly IUserFileRepository _userFileRepository;
        public UserFileService(IUserFileRepository userFileRepository) : base(userFileRepository)
        {
            _userFileRepository = userFileRepository;
        }

        public Task<UserFile> GetUserFileWithUserAsync(Guid id)
        {
            return _userFileRepository.GetUserFileWithUserAsync(id);
        }

        public Task<IEnumerable<UserFile>> GetAllWithOwnerAndSharedWithAsync()
        {
            return _userFileRepository.GetAllWithOwnerAndSharedWithAsync();
        }
    }
}
