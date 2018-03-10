using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SecureShare.WebAPI.Core.Entities;
using SecureShare.WebAPI.Core.Interfaces;
using SecureShare.WebAPI.Infrastructure.Interfaces;

namespace SecureShare.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/UserFiles")]
    public class UserFilesController : Controller
    {
        private readonly IUserFileService _userFileService;
        private readonly SecureShareWebAPIContext _context;

        public UserFilesController(SecureShareWebAPIContext context, IUserFileService userFileService)
        {
            _context = context;
            _userFileService = userFileService;
        }

        // GET: api/UserFiles
        [HttpGet]
        public async Task<IActionResult> GetUserFile()
        {
            _context.Database.EnsureCreated();
            return Ok(await _userFileService.GetAllWithOwnerAndSharedWithAsync());
        }

        // GET: api/UserFiles/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserFile([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userFile = await _userFileService.GetByIdAsync(id);

            if (userFile == null)
            {
                return NotFound();
            }

            return Ok(userFile);
        }

        // POST: api/UserFiles
        [HttpPost]
        public async Task<IActionResult> PostUserFile([FromBody] UserFile userFile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _userFileService.AddAsync(userFile);

            return CreatedAtAction("GetUserFile", new { id = userFile.UserFileId }, userFile);
        }

        // DELETE: api/UserFiles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserFile([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userFile = await _userFileService.GetByIdAsync(id);
            if (userFile == null)
            {
                return NotFound();
            }

            await _userFileService.DeleteAsync(userFile);

            return Ok(userFile);
        }
    }
}