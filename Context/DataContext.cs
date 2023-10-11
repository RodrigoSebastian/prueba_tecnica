using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Model;

namespace PruebaTecnica.Context;

/// <summary>
/// Contexto de datos para la aplicación.
/// </summary>
public partial class DataContext : DbContext
{
    /// <summary>
    /// Contexto de datos para la aplicación.
    /// </summary>
    public DataContext()
    {
    }

    /// <summary>
    /// Contexto de datos para la aplicación.
    /// </summary>
    /// <param name="options">Opciones del contexto de datos.</param>
    public DataContext(DbContextOptions<DataContext> options): base(options)
    {
    }

    /// <summary>
    /// Conjunto de datos de productos.
    /// </summary>
    public virtual DbSet<Product> Products { get; set; }

    /// <summary>
    /// Conjunto de datos de ventas.
    /// </summary>
    public virtual DbSet<Sale> Sales { get; set; }

    /// <summary>
    /// Conjunto de datos de detalles de ventas.
    /// </summary>
    public virtual DbSet<SaleDetail> SaleDetails { get; set; }

    /// <summary>
    /// Configura el modelo de datos.
    /// </summary>
    /// <param name="modelBuilder">Creador del modelo.</param>
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
