using System;
using System.Collections.Generic;

namespace DocumentArchiveWebAPI.Models;

public partial class TextSearching
{
    public int Id { get; set; }

    public string Text { get; set; } = null!;

    public virtual ICollection<FilterStorage> FilterStorages { get; } = new List<FilterStorage>();
}
