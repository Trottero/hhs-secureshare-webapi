using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecureShare.WebApi.Core.Models;
using SecureShare.WebAPI.Infrastructure;

namespace SecureShare.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Files")]
    public class FilesController : Controller
    {
        private readonly IFileService _fileService;

        public FilesController(IFileService fileService)
        {
            _fileService = fileService;
        }

        // GET: api/Files
        [HttpGet]
        public IEnumerable<File> GetFile()
        {
            //return all files
            return null;
        }

        // GET: api/Files/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFile([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var file = await _fileService.GetById(id);

            if (file == null)
            {
                return NotFound();
            }

            return Ok(file);
        }

        // POST: api/Files
        [HttpPost]
        public async Task<IActionResult> PostFile([FromBody] File file)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            //add file
            await _fileService.AddAsync(file);

            return CreatedAtAction("GetFile", new { id = file.FileGuid }, file);
        }

        // DELETE: api/Files/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFile([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //delete file
            var file = await _fileService.GetById(id);
            if (file == null)
            {
                return NotFound();
            }

            await _fileService.DeleteById(file.FileGuid);

            return Ok(file);
        }
    }
}