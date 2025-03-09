﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
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
        public virtual Vendor Vendor { get; set; }
    }
    public class ShopConfigration : IEntityTypeConfiguration<Shop>
    {
        public void Configure(EntityTypeBuilder<Shop> modelBuilder)
        {
            modelBuilder.HasKey(c => c.Id);

            modelBuilder
                .HasOne(sp => sp.Vendor)
                .WithOne(vr => vr.Shop)
                .HasForeignKey<Shop>(sp => sp.VendorId);
        }
    }
}
