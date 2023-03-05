namespace DocumentArchive.Model
{
    /// <summary>
    /// Хранение данных о пользователе во время сеанса
    /// </summary>
	public class UserPrimaryData
	{
        internal int Id { get; }
		internal string Name { get; }

		public UserPrimaryData(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}