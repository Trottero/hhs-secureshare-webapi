using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SecureShare.WebAPI.Core.Entities;
using SecureShare.WebAPI.Core.Interfaces;
using SecureShare.WebAPI.Infrastructure.Interfaces;

namespace SecureShare.WebAPI.Services.Services
{
    public class UserFileService : EntityService<UserFile>, IUserFileService
    {
        private readonly IUserFileRepository _userFileRepository;

        public UserFileService(IUserFileRepository userFileRepository, IAzureBlobService azureBlobService, IConfiguration configuration) : base(userFileRepository)
        {
            _userFileRepository = userFileRepository;
        }

        public new async Task<UserFile> AddAsync(UserFile userFile)
        {
            userFile.UploadDateTime = DateTime.Now;
            return await base.AddAsync(userFile);
        }

        public async Task<UserFile> GetUserFileWithUserAsync(Guid id)
        {
            var userFile =  await _userFileRepository.GetUserFileWithUserAsync(id);

            return userFile;
        }

        public Task<IEnumerable<UserFile>> GetAllWithOwnerAndSharedWithAsync()
        {
            return _userFileRepository.GetAllWithOwnerAndSharedWithAsync();
        }
    }
}
