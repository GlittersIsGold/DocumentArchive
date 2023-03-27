using System;
using System.Collections.Generic;

namespace DocumentArchiveWebAPI.Models;

public partial class User
{
    public int Id { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTime Registered { get; set; }

    public int RoleId { get; set; }

    public virtual Role Role { get; set; } = null!;

    public virtual ICollection<UserFile> UserFiles { get; } = new List<UserFile>();
}
