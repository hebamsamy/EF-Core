﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EF_Core_Day1_FormDB;

public partial class LibraryContext : DbContext
{
    public LibraryContext()
    {
    }

    public LibraryContext(DbContextOptions<LibraryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Auther> Authers { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<LibraryBook> LibraryBooks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data source = DESKTOP-0KJMNFC; Initial catalog = Library; Integrated security= true; trustservercertificate = true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LibraryBook>(entity =>
        {
            entity.HasKey(e => e.BookId);

            entity.ToTable("LibraryBooks", "Production");

            entity.HasIndex(e => e.AutherId, "IX_LibraryBooks_AutherId");

            entity.HasIndex(e => e.CategoryId, "IX_LibraryBooks_CategoryId");

            entity.Property(e => e.BookId)
                .ValueGeneratedNever()
                .HasColumnName("Book_Id");
            entity.Property(e => e.Price).HasColumnType("money");
            entity.Property(e => e.Title).HasMaxLength(50);

            entity.HasOne(d => d.Auther).WithMany(p => p.LibraryBooks).HasForeignKey(d => d.AutherId);

            entity.HasOne(d => d.Category).WithMany(p => p.LibraryBooks).HasForeignKey(d => d.CategoryId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
