using System;
using System.Collections.Generic;

namespace DocumentArchiveWebAPI.Models;

public partial class FilterStorage
{
    public int Id { get; set; }

    public int FileInfoId { get; set; }

    public string Keyword { get; set; } = null!;

    public int DescriptionId { get; set; }

    public int CategoryId { get; set; }

    public int TextSearchingId { get; set; }

    public int IndexSearching { get; set; }

    public virtual Description Description { get; set; } = null!;

    public virtual FileInfo FileInfo { get; set; } = null!;

    public virtual TextSearching TextSearching { get; set; } = null!;
}
