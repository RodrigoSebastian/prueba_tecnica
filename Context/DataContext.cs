using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Model;

namespace PruebaTecnica.Context;

public partial class DataContext : DbContext
{
    public DataContext()
    {
    }

    public DataContext(DbContextOptions<DataContext> options): base(options)
    {
    }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<SaleDetail> SaleDetails { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__product__3213E83FABDB4FFC");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Stock).HasDefaultValueSql("((0))");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__sale__3213E83F6FCAFA8B");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<SaleDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__sale_det__3213E83FF476EA0E");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.SaleDetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fkProduct");

            entity.HasOne(d => d.IdSaleNavigation).WithMany(p => p.SaleDetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fkSale");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
