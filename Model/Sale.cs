using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaTecnica.Model;

/// <summary>
/// Modelo de la tabla sale
/// </summary>
[Table("sale")]
public partial class Sale
{
    /// <summary>
    /// Identificador de la venta
    /// </summary>
    [Key]
    [Column("id")]
    public int Id { get; set; }

    /// <summary>
    /// Total de la venta
    /// </summary>
    [Column("total", TypeName = "money")]
    public decimal Total { get; set; }

    /// <summary>
    /// Fecha de creación de la venta
    /// </summary>
    [Column("createdAt", TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    /// <summary>
    /// Fecha de actualización de la venta
    /// </summary>
    [Column("updatedAt", TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// Detalles de la venta
    /// </summary>
    [InverseProperty("IdSaleNavigation")]
    public virtual ICollection<SaleDetail> SaleDetails { get; set; } = new List<SaleDetail>();
}

/// <summary>
/// Parámetros para crear una nueva venta
/// </summary>
public partial class SaleParams {
    /// <summary>
    /// Identificador del producto
    /// </summary>
    public int ProductId { get; set; }

    /// <summary>
    /// Cantidad del producto vendido
    /// </summary>
    public int Amount { get; set; }
}
