using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SecureShare.WebAPI.Core.Entities;
using SecureShare.WebAPI.Infrastructure.Interfaces;

namespace SecureShare.WebAPI.Controllers
{
	[Produces("application/json")]
	[Route("api/Share")]
	public class SharingController : Controller
	{
		private readonly IEntityService<Users_UserFiles> _userfilesUsersEntityService;

		public SharingController(SecureShareWebAPIContext context, IUserFileService userFileService,
			IEntityService<Users_UserFiles> userfilesUsersEntityService)
		{
			_userfilesUsersEntityService = userfilesUsersEntityService;
		}

		[HttpPost]
		public async Task<IActionResult> ShareUserFileWithUser([FromBody] Users_UserFiles fileToShare)
		{
			if (!ModelState.IsValid) return BadRequest(ModelState);
			await _userfilesUsersEntityService.AddAsync(fileToShare);
			return RedirectToAction("GetUserFile", "UserFiles");
		}
	}
}