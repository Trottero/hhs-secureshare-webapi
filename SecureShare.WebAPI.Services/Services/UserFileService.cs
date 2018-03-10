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
        private readonly IAzureBlobService _azureBlobService;
        private readonly IConfiguration _configuration;

        public UserFileService(IUserFileRepository userFileRepository, IAzureBlobService azureBlobService, IConfiguration configuration) : base(userFileRepository)
        {
            _userFileRepository = userFileRepository;
            _azureBlobService = azureBlobService;
            _configuration = configuration;
        }

        public new async Task<UserFile> AddAsync(UserFile userFile)
        {
            var blobId = await _azureBlobService.AddToBlobAsync(_configuration["BlobContainer"],
                FileConverterService.ConvertBase64ToFileStream(userFile.FileEncodedToBase64));
            userFile.BlobId = blobId;
            userFile.UploadDateTime = DateTime.Now;
            return await base.AddAsync(userFile);
        }

        public async Task<UserFile> GetUserFileWithUserAsync(Guid id)
        {
            var userFile =  await _userFileRepository.GetUserFileWithUserAsync(id);
            userFile.FileEncodedToBase64 =
                FileConverterService.ConvertFileToBase64(
                    await _azureBlobService.GetFromBlobAsync(_configuration["BlobContainer"], userFile.BlobId.ToString()));

            return userFile;
        }

        public Task<IEnumerable<UserFile>> GetAllWithOwnerAndSharedWithAsync()
        {
            return _userFileRepository.GetAllWithOwnerAndSharedWithAsync();
        }
    }
}
