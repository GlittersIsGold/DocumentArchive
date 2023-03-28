namespace DocumentArchiveWebAPI.Models.Dto
{
	public class UserLoginDto
	{
		public required string Login { get; set; } = null!;
		
		public required string Password { get; set; } = null!;
	}
}
