using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;

namespace AutomobileLibrary.DataAccess;

public partial class MyStockDBContext : DbContext
{
    public MyStockDBContext()
    {
    }

    public MyStockDBContext(DbContextOptions<MyStockDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Car> Cars { get; set; } = null!;
    public virtual DbSet<Category> Categories { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("server=(local);uid=sa;pwd=1234567890;database=MyStockDB;TrustServerCertificate=True;");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Car>(entity =>
        {
            entity.ToTable("Car");

            entity.Property(e => e.CarId).HasColumnName("CarID");

            entity.Property(e => e.CarName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.Manufacturer)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.Price).HasColumnType("money");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

            entity.Property(e => e.CategoryName).HasMaxLength(40);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
