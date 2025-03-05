using System;
using System.Collections.Generic;

namespace EF_Core_Day1_FormDB;

public partial class Category
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<LibraryBook> LibraryBooks { get; set; } = new List<LibraryBook>();
}
