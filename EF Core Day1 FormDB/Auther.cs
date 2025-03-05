using System;
using System.Collections.Generic;

namespace EF_Core_Day1_FormDB;

public partial class Auther
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string HashPassword { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<LibraryBook> LibraryBooks { get; set; } = new List<LibraryBook>();
}
