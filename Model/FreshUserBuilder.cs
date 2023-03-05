using DocumentArchive.Model.ADO;

namespace DocumentArchive.Model
{
	/// <summary>
	/// Экземпляры этого класса создают новых пользователей в системе при регистрации.
	/// Содержит свойства DocumentArchive.Model.ADO.User
	/// </summary>
	internal class FreshUserBuilder
	{
		public string Login { get; set; }
		public string Password { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public System.DateTime Registered { get; set; }
		public int RoleId { get; set; }
	}
}
