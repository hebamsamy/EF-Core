using EF_Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core
{
    public class EShopContext : DbContext
    {
        //tables
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductAttachment> ProductAttachments { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data source = DESKTOP-0KJMNFC; Initial catalog = E-Shop; Integrated security= true; trustservercertificate = true;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Setting Primary Key
            //Category
            modelBuilder.Entity<Category>().HasKey(c => c.Id);
            modelBuilder.Entity<Category>().HasIndex(c=>c.Name).IsUnique();
            

            //Product
            modelBuilder.Entity<Product>().HasKey(p => p.Id);
            modelBuilder.Entity<Product>().Property(p=> p.Name).HasColumnType("NVARCHAR(100)").IsRequired();
            modelBuilder.Entity<Product>().Property(p=> p.Quantity).HasColumnName("Stock").HasDefaultValue(1);
            modelBuilder.Entity<Product>().Property(p=> p.Price).HasColumnType("Money");
            modelBuilder.Entity<Product>().Property(p=> p.Description)
                .HasColumnType("NVARCHAR(500)").IsRequired(false);




            //Relations 


            //one to many
            modelBuilder.Entity<Category>()
                .HasMany(cat => cat.Products)
                .WithOne(prd => prd.Category)
                .HasForeignKey(prd => prd.CategoryId);

            modelBuilder.Entity<Product>()
                .HasMany(prd => prd.Attachments)
                .WithOne(att => att.Product)
                .HasForeignKey(att => att.ProductId);
            modelBuilder.Entity<Product>()
                .HasOne(prd => prd.Vendor)
                .WithMany(vendor => vendor.Products)
                .HasForeignKey(prd => prd.VendorId);

            //one to one
            modelBuilder.Entity<Shop>()
                .HasOne(sp => sp.Vendor)
                .WithOne(vr => vr.Shop)
                .HasForeignKey<Shop>(sp => sp.VendorId);

            //many to many
            //modelBuilder.Entity<Product>()
            //     .HasMany(prd => prd.Clients)
            //     .WithMany(cl => cl.Products)
            //     .UsingEntity(i => i.ToTable("Orders"));

            modelBuilder.Entity<Order>()
                .HasOne(ord => ord.Client)
                .WithMany(cl => cl.Orders)
                .HasForeignKey(ord => ord.ClientId);

            modelBuilder.Entity<OrderItem>()
                .HasOne(item => item.Order)
                .WithMany(Order => Order.Items)
                .HasForeignKey(item => item.OrderId);

            modelBuilder.Entity<OrderItem>()
                .HasOne(item => item.Product)
                .WithMany(Product => Product.OrderItems)
                .HasForeignKey(item => item.ProductId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
