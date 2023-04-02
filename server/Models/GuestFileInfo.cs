using System;
using System.Collections.Generic;

namespace DocumentArchiveWebAPI.Models;

public partial class GuestFileInfo
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime Created { get; set; }

    public string ShareLink { get; set; } = null!;

    public int AccessLevelId { get; set; }

    public bool IsPinned { get; set; }
}
