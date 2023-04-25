using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class UserLogin
{
    public string ProviderKey { get; set; } = null!;

    public Guid UserId { get; set; }

    public string? LoginProvider { get; set; }

    public string? ProviderDisplayName { get; set; }
}
