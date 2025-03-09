using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core.Models
{
    public class Vendor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Picture { get; set; }
        public string HashPassword { get; set; }

        public virtual Shop Shop { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
    public class VendorConfigration : IEntityTypeConfiguration<Vendor>
    {
        public void Configure(EntityTypeBuilder<Vendor> modelBuilder)
        {
            modelBuilder.HasKey(c => c.Id);
            modelBuilder.HasIndex(c => c.UserName).IsUnique();
        }
    }
}
