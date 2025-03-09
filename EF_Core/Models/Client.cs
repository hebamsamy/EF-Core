using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Picture { get; set; }
        public string HashPassword { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    

    }

    public class ClientConfigration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> modelBuilder)
        {
            modelBuilder.HasKey(c => c.Id);
            modelBuilder.HasIndex(c => c.UserName).IsUnique();
        }
    }
}
