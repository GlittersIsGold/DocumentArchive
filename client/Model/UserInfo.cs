using Newtonsoft.Json;

namespace DocumentArchive.Model
{
	/// <summary>
	/// Класс десериализации пользовательских данных из jwt
	/// </summary>
	public class UserInfo
	{
		public string Id { get; set; }
		public string Username { get; set; }
		public string Role { get; set; }
		public string Email { get; set; }
		public Stats Stats { get; set; }
	}

	public class Stats
	{
		[JsonProperty("Files uploaded")]
		public int Filesuploaded { get; set; }
	}

}