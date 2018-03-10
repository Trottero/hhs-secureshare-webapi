using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace SecureShare.WebAPI.Infrastructure.Interfaces
{
    public interface IAzureBlobService
    {
        Task<Guid> AddToBlobAsync(string container, FileStream file);
        Task<FileStream> GetFromBlobAsync(string container, string blobId);
        Task<Guid> DeleteFromBlobAsync(string container, string blobId);
    }
}
