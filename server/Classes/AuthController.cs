using DocumentArchiveWebAPI.Interface;
using DocumentArchiveWebAPI.Models;
using DocumentArchiveWebAPI.Models.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DocumentArchiveWebAPI.Classes
{
	[EnableCors("Allow")]
	[Route("api/auth")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly IConfiguration _configuration;
		private readonly ElectronicDocumentArchiveManagementContext _context;
		private readonly IUserService _userService;

        public AuthController(IConfiguration configuration, ElectronicDocumentArchiveManagementContext context, IUserService userService)
        {
            _configuration = configuration;
			_context = context;
			_userService = userService;
        }

		[HttpPost("register")]
		public ActionResult<User> Register(UserRegisterDto registerDto)
		{
			string Hash = BCrypt.Net.BCrypt.HashPassword(registerDto.Password);

			try
			{

				User user = new()
				{
					Login = registerDto.Login,
					Password = Hash,
					Name = registerDto.Name,
					Email = registerDto.Email,
					Registered = DateTime.Now,
					RoleId = 1
				};

				_context.Users.Add(user);
				_context.SaveChanges();
				
				return Ok(user);
			}
			catch (Exception)
			{
				return Forbid();
			}
		}

		[HttpPost("login")]
		public ActionResult<User> Login(UserLoginDto loginDto)
		{
			try
			{
				var user = _context.Users.FirstOrDefault(u=> u.Login == loginDto.Login);

				if (user != null)
				{
					if (BCrypt.Net.BCrypt.Verify(loginDto.Password, user.Password))
					{
						string token = GenerateToken(user);
						return Ok(token);
					}

					else 
					{
						return UnprocessableEntity();
					}	
				}
				else
				{
					return BadRequest();
				}
			}
			catch (Exception)
			{
				return BadRequest();
			}
		}

		[Authorize]
		[HttpGet("user-data")]
		public ActionResult<string> GetUserData()
		{
			var result = _userService.GetUserData();
			return Ok(result);
		}

		private string GenerateToken(User user)
		{
			try
			{
				if(user.Login != null)
				{
					List<Claim> claims = new()
					{
						new Claim(ClaimTypes.Sid, user.Id.ToString()),
						new Claim(ClaimTypes.Name, user.Login),
						new Claim(ClaimTypes.Role, user.RoleId.ToString()),
						new Claim(ClaimTypes.Email, user.Email),
						new Claim(ClaimTypes.UserData,
							"Files uploaded:" + user.UserFiles.Count
							),
					};
			
					var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("SecurityKeys:Token").Value!));

					var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

					var token = new JwtSecurityToken(
						claims: claims, 
						expires: DateTime.Now.AddHours(6),
						signingCredentials: creds);

					var jwt = new JwtSecurityTokenHandler().WriteToken(token);

					return jwt;
				}

				return "Can`t create token on wrong data";
			}
			catch (Exception)
			{
				return "Token generation not working";
			}
		}
    }
}
