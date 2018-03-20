using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using SecureShare.WebAPI.Infrastructure.Interfaces;

namespace SecureShare.WebAPI.Services.Services
{
    public class AzureBlobService : IAzureBlobService
    {
        private readonly IConfiguration _configuration;
        private readonly CloudBlobClient _cloudBlobClient;
        public AzureBlobService(IConfiguration configuration)
        {
            _configuration = configuration;
            CloudStorageAccount.TryParse(_configuration.GetConnectionString("SecureShareStorageAccount"),
                out var cloudStorageAccount);
            _cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
        }

        //uploads the given file and returns the ID that it was uploaded under
        public async Task<Guid> AddToBlobAsync(string container, IFormFile file)
        {
            var cloudBlobContainer = _cloudBlobClient.GetContainerReference(container);
            await cloudBlobContainer.CreateIfNotExistsAsync();

            var blobId = Guid.NewGuid();
            var blobReference = cloudBlobContainer.GetBlockBlobReference(blobId.ToString());
            await blobReference.UploadFromStreamAsync(file.OpenReadStream());
            return blobId;
        }

        //Gets a specified blob
        public async Task<FileStream> GetFromBlobAsync(string container, string blobId)
        {
            var cloudBlobContainer = _cloudBlobClient.GetContainerReference(container);
            if (!await cloudBlobContainer.ExistsAsync()) return null;

            var filePath = Path.GetTempPath();
            var fileName = Path.GetRandomFileName();
            var blobReference = cloudBlobContainer.GetBlockBlobReference(blobId);
            await blobReference.DownloadToFileAsync(filePath + fileName, FileMode.Create);
            return File.Open(filePath + fileName, FileMode.Open);

        }

        public async Task<Guid> DeleteFromBlobAsync(string container, string blobId)
        {
            var cloudBlobContainer = _cloudBlobClient.GetContainerReference(container);
            if (!await cloudBlobContainer.ExistsAsync()) return new Guid();

            var blobReference = cloudBlobContainer.GetBlockBlobReference(blobId);
            await blobReference.DeleteIfExistsAsync();
            return new Guid(blobId);

        }
    }
}
