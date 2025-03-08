using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core.Models
{
    public class Shop
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }

        public int VendorId { get; set; }
        public Vendor Vendor { get; set; }
    }
}
