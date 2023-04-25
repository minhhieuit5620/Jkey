using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class Role
{
    public Guid Id { get; set; }

    public string RoleName { get; set; } = null!;

    public string? RoleDesciption { get; set; }

    public bool Active { get; set; }

    public Guid? UserCreated { get; set; }

    public Guid? UserModified { get; set; }

    public DateTime? DateCreated { get; set; }

    public DateTime? DateModified { get; set; }
}
