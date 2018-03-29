using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SecureShare.WebAPI.Core.Entities;
using SecureShare.WebAPI.Infrastructure.Interfaces;

namespace SecureShare.WebAPI.Controllers
{
	[Produces("application/json")]
	[Route("api/files")]
	public class UserFilesController : Controller
	{
		private readonly IUserFileService _userFileService;
		private readonly SecureShareWebAPIContext _context;

		public UserFilesController(SecureShareWebAPIContext context, IUserFileService userFileService)
		{
			_context = context;
			_userFileService = userFileService;
		}

		// GET: api/files
		[HttpGet]
		public async Task<IActionResult> GetUserFile()
		{
			_context.Database.EnsureCreated();
			return Ok(await _userFileService.GetAllWithOwnerAndSharedWithAsync());
		}

		// GET: api/files/5
		[HttpGet("{id}")]
		public async Task<IActionResult> GetUserFile([FromRoute] Guid id)
		{
			if (!ModelState.IsValid) return BadRequest(ModelState);

			var userFile = await _userFileService.GetByIdAsync(id);

			if (userFile == null) return NotFound();

			return Ok(userFile);
		}

		// POST: api/files
		[HttpPost]
		public async Task<IActionResult> PostUserFile([FromBody] UserFile userFile)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			await _userFileService.AddAsync(userFile);

			return CreatedAtAction("GetUserFile", new {id = userFile.UserFileId}, userFile);
		}

		// DELETE: api/files/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteUserFile([FromRoute] Guid id)
		{
			if (!ModelState.IsValid) return BadRequest(ModelState);

			var userFile = await _userFileService.GetByIdAsync(id);

			if (userFile == null) return NotFound();

			await _userFileService.DeleteAsync(userFile);

			return Ok(userFile);
		}

		//GET: api/files/user/00000-0000-000
		//Gets all files from specified user
		[HttpGet("user/{id}")]
		public async Task<IActionResult> GetFilesFromUser([FromRoute] Guid id)
		{
			return Ok(await _userFileService.GetFromUserAndSharedWithAsync(id));
		}

		[HttpGet("sharedwith/{id}")]
		public async Task<IActionResult> GetFilesSharedWith([FromRoute] Guid id)
		{
			return Ok(await _userFileService.GetFilesSharedWithUser(id));
		}
	}
}