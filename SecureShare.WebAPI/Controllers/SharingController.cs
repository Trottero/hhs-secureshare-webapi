using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SecureShare.WebAPI.Core.Entities;
using SecureShare.WebAPI.Infrastructure.Interfaces;

namespace SecureShare.WebAPI.Controllers
{
	[Produces("application/json")]
	[Route("api")]
	public class SharingController : Controller
	{
		private readonly IEntityService<Users_UserFiles> _userfilesUsersEntityService;

		public SharingController(SecureShareWebAPIContext context, IUserFileService userFileService,
			IEntityService<Users_UserFiles> userfilesUsersEntityService)
		{
			_userfilesUsersEntityService = userfilesUsersEntityService;
		}

		//POST: api/share/
		//Shares a file with a user using the Users_Userfiles object
		[HttpPost("share")]
		public async Task<IActionResult> ShareUserFileWithUser([FromBody] Users_UserFiles fileToShare)
		{
			if (!ModelState.IsValid) return BadRequest(ModelState);
			await _userfilesUsersEntityService.AddAsync(fileToShare);
		    return Ok(fileToShare);
		}
	}
}