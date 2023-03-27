using System;
using System.Collections.Generic;

namespace DocumentArchiveWebAPI.Models;

public partial class Category
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<FileInfo> FileInfos { get; } = new List<FileInfo>();
}
