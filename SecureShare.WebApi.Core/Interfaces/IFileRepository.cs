using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SecureShare.WebApi.Core.Models;

namespace SecureShare.WebAPI.Core.Interfaces
{
    public interface IFileRepository
    {
        IEnumerable<File> GetAll();
        Task<File> GetById(Guid id);
        Task DeleteById(Guid id);
        Task AddAsync(File file);
    }
}
