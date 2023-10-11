using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace PruebaTecnica.Model;

/// <summary>
/// Modelo de la tabla sale_detail
/// </summary>
[Table("sale_detail")]
public partial class SaleDetail
{
    /// <summary>
    /// Identificador del detalle de la venta
    /// </summary>
    [Key]
    [Column("id")]
    public int Id { get; set; }

    /// <summary>
    /// Identificador de la venta
    /// </summary>
    [Column("idSale")]
    public int IdSale { get; set; }

    /// <summary>
    /// Identificador del producto
    /// </summary>
    [Column("idProduct")]
    public int IdProduct { get; set; }

    /// <summary>
    /// Cantidad del producto vendido
    /// </summary>
    [Column("amount")]
    public int Amount { get; set; }

    /// <summary>
    /// Subtotal del detalle de la venta
    /// </summary>
    [Column("subTotal", TypeName = "money")]
    public decimal SubTotal { get; set; }

    /// <summary>
    /// Fecha de creación del detalle de la venta
    /// </summary>
    [Column("createdAt", TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    /// <summary>
    /// Fecha de actualización del detalle de la venta
    /// </summary>
    [Column("updatedAt", TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// Producto al que pertenece el detalle de la venta
    /// </summary>
    [JsonIgnore]
    [ForeignKey("IdProduct")]
    [InverseProperty("SaleDetails")]
    public virtual Product IdProductNavigation { get; set; } = null!;

    /// <summary>
    /// Venta a la que pertenece el detalle de la venta
    /// </summary>
    [JsonIgnore]
    [ForeignKey("IdSale")]
    [InverseProperty("SaleDetails")]
    public virtual Sale IdSaleNavigation { get; set; } = null!;
}
