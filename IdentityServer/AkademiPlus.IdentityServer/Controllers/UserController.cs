﻿using AkademiPlus.IdentityServer.DTO_s;
using AkademiPlus.IdentityServer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using static IdentityServer4.IdentityServerConstants;

namespace AkademiPlus.IdentityServer.Controllers
{
	[Authorize(LocalApi.PolicyName)]
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly UserManager<ApplicationUser> _userManager;

		public UserController(UserManager<ApplicationUser> userManager)
		{
			_userManager = userManager;
		}
		[HttpPost]
		public async Task<IActionResult> SignUp(SignUpDTO signUpDTO)
		{
			var user = new ApplicationUser()
			{
                UserName = signUpDTO.Username,
                Email = signUpDTO.Email,
                NameSurname = signUpDTO.NameSurname,
				City = signUpDTO.City

			};
			await  _userManager.CreateAsync(user,signUpDTO.Password);
			return Ok("Kayıt Başarılı!");
		}
	}
}
