using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class MenuLanguage
{
    public string MenuId { get; set; } = null!;

    public int LangId { get; set; }

    public string Value { get; set; } = null!;
}
