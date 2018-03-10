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
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository):base(userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<User> GetUserWithSharedFilesAsync(Guid id)
        {
            return await _userRepository.GetUserWithSharedFilesAsync(id);
        }

        public async Task<IEnumerable<User>> GetAllUserWithSharedFilesAsync()
        {
            return await _userRepository.GetAllUserWithSharedFilesAsync();
        }
    }
}
