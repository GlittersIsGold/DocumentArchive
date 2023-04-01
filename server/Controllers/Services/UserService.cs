using DocumentArchiveWebAPI.Interface;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace DocumentArchiveWebAPI.Controllers.Services
{
	public class UserService : IUserService
	{

		private readonly IHttpContextAccessor _contextAccessor;

		public UserService(IHttpContextAccessor contextAccessor)
		{
			_contextAccessor = contextAccessor;
		}

		string IUserService.GetUserData()
		{
			string? 
				result,
				id,
				name,
				role,
				email,
				userData;

			if (_contextAccessor != null)
			{
				id = _contextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.Sid);	
				name = _contextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Name);
				role = _contextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Role);
				email = _contextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Email);
				userData = _contextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.UserData);
				
				result = id + "\n" + name + "\n" + role + "\n" + email + "\n" + userData;
				return result;
			}
			else
			{
				result = "No data found";
				return result;
			}
		}
	}
}
