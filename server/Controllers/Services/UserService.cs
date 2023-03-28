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
			string? result, uId;

			if (_contextAccessor != null)
			{
				uId = _contextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);	
				
				return result = uId;
			}
			else
			{
				return result = "123";
			}
		}
	}
}
