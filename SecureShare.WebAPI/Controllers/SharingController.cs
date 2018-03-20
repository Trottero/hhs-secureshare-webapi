using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecureShare.WebAPI.Core.Entities;
using SecureShare.WebAPI.Core.Interfaces;
using SecureShare.WebAPI.Infrastructure.Interfaces;

namespace SecureShare.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Share")]
    public class SharingController : Controller
    {
        private readonly IUserFileService _userFileService;
        private readonly SecureShareWebAPIContext _context;
        private readonly IEntityService<Users_UserFiles> _userfilesUsersEntityService;

        public SharingController(SecureShareWebAPIContext context, IUserFileService userFileService, IEntityService<Users_UserFiles> userfilesUsersEntityService)
        {
            _context = context;
            _userFileService = userFileService;
            _userfilesUsersEntityService = userfilesUsersEntityService;
        }

        [HttpPost]
        public async Task<IActionResult> ShareUserFileWithUser([FromBody] Users_UserFiles fileToShare)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _userfilesUsersEntityService.AddAsync(fileToShare);
            return RedirectToAction("GetUserFile", "UserFiles");
        }
    }
}