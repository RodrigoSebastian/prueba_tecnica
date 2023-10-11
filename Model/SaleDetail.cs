using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace PruebaTecnica.Model;

[Table("sale_detail")]
public partial class SaleDetail
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("idSale")]
    public int IdSale { get; set; }

    [Column("idProduct")]
    public int IdProduct { get; set; }

    [Column("amount")]
    public int Amount { get; set; }

    [Column("subTotal", TypeName = "money")]
    public decimal SubTotal { get; set; }

    [Column("createdAt", TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [Column("updatedAt", TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [JsonIgnore]
    [ForeignKey("IdProduct")]
    [InverseProperty("SaleDetails")]
    public virtual Product IdProductNavigation { get; set; } = null!;

    [JsonIgnore]
    [ForeignKey("IdSale")]
    [InverseProperty("SaleDetails")]
    public virtual Sale IdSaleNavigation { get; set; } = null!;
}
