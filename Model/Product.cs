using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace PruebaTecnica.Model;

/// <summary>
/// Modelo de la tabla product
/// </summary>
[Table("product")]
public partial class Product
{
    /// <summary>
    /// Identificador del producto
    /// </summary>
    [Key]
    [Column("id")]
    public int Id { get; set; }

    /// <summary>
    /// Nombre del producto
    /// </summary>
    [Column("name")]
    [StringLength(255)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    /// <summary>
    /// Precio del producto
    /// </summary>
    [Column("price", TypeName = "money")]
    public decimal Price { get; set; }

    /// <summary>
    /// Imagen del producto
    /// </summary>
    [Column("image")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Image { get; set; }

    /// <summary>
    /// Stock del producto
    /// </summary>
    [Column("stock")]
    public int? Stock { get; set; }

    /// <summary>
    /// Fecha de creación del producto
    /// </summary>
    [Column("createdAt", TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    /// <summary>
    /// Fecha de actualización del producto
    /// </summary>
    [Column("updatedAt", TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// Detalles de las ventas del producto
    /// </summary>
    [JsonIgnore]
    [InverseProperty("IdProductNavigation")]
    public virtual ICollection<SaleDetail> SaleDetails { get; set; } = new List<SaleDetail>();
}
