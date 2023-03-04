using DocumentArchive.Model.ADO;

namespace DocumentArchive.Model
{
	/// <summary>
	/// Экземпляры этого класса создают новых пользователей в системе при регистрации
	/// </summary>
	internal class FreshUserBuilder : User
	{
		public new string Login { get; set; }
		public new string Password { get; set; }
		public new string Name { get; set; }
		public new string Email { get; set; }
		public new System.DateTime Registered { get; set; }
		public new int RoleId { get; set; }
	}
}
