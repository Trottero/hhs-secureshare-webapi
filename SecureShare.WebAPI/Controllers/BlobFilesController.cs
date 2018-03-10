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
        private readonly IAzureBlobService _azureBlobService;

        public BlobFilesController(IAzureBlobService azureBlobService)
        {
            _azureBlobService = azureBlobService;
        }

        //POST: api/blob/add/
        //Include file in the body as multipart/form-data
        [HttpPost("add")]
        public async Task<IActionResult> PostFileToBlob(IFormFile file)
        {
            if (file == null)
                return BadRequest();
            var blobId = await _azureBlobService.AddToBlobAsync("files", file);
            return Ok(blobId);
        }
    
        //GET: api/blob/get/0000-00000-0000
        [HttpGet("get/{id}")]
        public async Task<FileStream> GetFileFromBlob([FromRoute]Guid id)
        {
            return (await _azureBlobService.GetFromBlobAsync("files", id.ToString()));
        }

        //DELETE: api/blob/delete/{id}
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteBlob([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var blobId = await _azureBlobService.DeleteFromBlobAsync("files", id.ToString());
            if (blobId == new Guid())
            {
                return BadRequest();
            }
            return Ok(blobId);
        }
    }
}
