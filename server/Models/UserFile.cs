using System;
using System.Collections.Generic;

namespace DocumentArchiveWebAPI.Models;

public partial class UserFile
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int FileInfoId { get; set; }

    public DateTime DateUpload { get; set; }

    public virtual FileInfo FileInfo { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
