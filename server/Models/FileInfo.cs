using System;
using System.Collections.Generic;

namespace DocumentArchiveWebAPI.Models;

public partial class FileInfo
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public decimal Size { get; set; }

    public DateTime Created { get; set; }

    public byte[] Expression { get; set; } = null!;

    public int CategoryId { get; set; }

    public int AccessLevelId { get; set; }

    public string ShareLink { get; set; } = null!;

    public virtual FileAccessLevel AccessLevel { get; set; } = null!;

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<Description> Descriptions { get; } = new List<Description>();

    public virtual ICollection<FilterStorage> FilterStorages { get; } = new List<FilterStorage>();

    public virtual ICollection<UserFile> UserFiles { get; } = new List<UserFile>();
}
