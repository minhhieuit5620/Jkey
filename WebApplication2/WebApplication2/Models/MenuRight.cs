using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class MenuRight
{
    public string MenuId { get; set; } = null!;

    public Guid RoleId { get; set; }
}
