using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SecureShare.WebAPI.Infrastructure.Interfaces;

namespace SecureShare.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/blob")]
    [Consumes("multipart/form-data", "application/json")]
    public class BlobFilesController : Controller
    {
        //this controller should manage the blobs on azure
        private readonly IAzureBlobService _azureBlobService;

        public BlobFilesController(IAzureBlobService azureBlobService)
        {
            _azureBlobService = azureBlobService;
        }

        //POST: api/blob/add/
        //Include file in the body as multipart/form-data
        [HttpPost]
        public async Task<IActionResult> PostFileToBlob(IFormFile file)
        {
            if (file == null)
                return BadRequest();
            var blobId = await _azureBlobService.AddToBlobAsync("files", file);
            
            return Ok(blobId);
        }

        //GET: api/blob/0000-00000-0000
        [HttpGet("{id}")]
        public async Task<FileStream> GetFileFromBlob([FromRoute]Guid id)
        {
            return (await _azureBlobService.GetFromBlobAsync("files", id.ToString()));
        }
    }
}
