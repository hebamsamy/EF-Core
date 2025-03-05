using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_Day1
{
    public class Auther
    {
        public int Id { get; set; }

        [RegularExpression(@"^a-zA-Z+$")]
        public string Name { get; set; }

        public string HashPassword { get; set; }
        //[Compare("Password")]
        //public string ConfirmPassword { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [NotMapped]
        public DateTime ReigterDate { get; set; } = DateTime.Now;

        public ICollection<Book> Books { get; set; }

    }
}
