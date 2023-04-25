using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class PageRight
{
    public string PageId { get; set; } = null!;

    public Guid RoleId { get; set; }

    public virtual Role Role { get; set; } = null!;
}
