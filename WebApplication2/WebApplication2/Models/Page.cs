using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class Page
{
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public bool Active { get; set; }

    public string? ActionId { get; set; }

    public string? SourcePath { get; set; }

    public string? BackPageId { get; set; }

    public bool? PermissionRequire { get; set; }

    public Guid? UserCreated { get; set; }

    public Guid? UserModified { get; set; }

    public DateTime? DateCreated { get; set; }

    public DateTime? DateModified { get; set; }
}
