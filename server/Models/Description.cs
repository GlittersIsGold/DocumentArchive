using System;
using System.Collections.Generic;

namespace DocumentArchiveWebAPI.Models;

public partial class Description
{
    public int Id { get; set; }

    public string Information { get; set; } = null!;

    public int FileInfoId { get; set; }

    public virtual FileInfo FileInfo { get; set; } = null!;

    public virtual ICollection<FilterStorage> FilterStorages { get; } = new List<FilterStorage>();
}
