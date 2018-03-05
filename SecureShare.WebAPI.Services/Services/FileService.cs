using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SecureShare.WebApi.Core.Models;
using SecureShare.WebAPI.Core.Interfaces;
using SecureShare.WebAPI.Infrastructure;

namespace SecureShare.WebAPI.Services.Services
{
    public class FileService : IFileService
    {
        private readonly IFileRepository _fileRepository;

        public FileService(IFileRepository fileRepository)
        {
            _fileRepository = fileRepository;
        }

        public IEnumerable<File> GetAll()
        {
            return _fileRepository.GetAll();
        }

        public Task<File> GetById(Guid id)
        {
            return  _fileRepository.GetById(id);
        }

        public async Task DeleteById(Guid id)
        {
            await _fileRepository.DeleteById(id);
        }

        public async Task AddAsync(File file)
        {
            await _fileRepository.AddAsync(file);
        }
    }
}
