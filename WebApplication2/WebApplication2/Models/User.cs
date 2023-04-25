using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class User
{
    public Guid Id { get; set; }

    public string FullName { get; set; } = null!;

    public int Gender { get; set; }

    public bool Active { get; set; }

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? ConfirmPassWord { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public string? Address { get; set; }

    public Guid? UserCreated { get; set; }

    public Guid? UserModified { get; set; }

    public DateTime? DateCreated { get; set; }

    public DateTime? DateModified { get; set; }
}
