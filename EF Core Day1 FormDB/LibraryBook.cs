using System;
using System.Collections.Generic;

namespace EF_Core_Day1_FormDB;

public partial class LibraryBook
{
    public int BookId { get; set; }

    public string Title { get; set; } = null!;

    public decimal Price { get; set; }

    public int CategoryId { get; set; }

    public int AutherId { get; set; }

    public virtual Auther Auther { get; set; } = null!;

    public virtual Category Category { get; set; } = null!;
}
