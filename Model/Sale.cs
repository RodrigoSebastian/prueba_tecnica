using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PruebaTecnica.Model;

[Table("sale")]
public partial class Sale
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("total", TypeName = "money")]
    public decimal Total { get; set; }

    [Column("createdAt", TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [Column("updatedAt", TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [InverseProperty("IdSaleNavigation")]
    public virtual ICollection<SaleDetail> SaleDetails { get; set; } = new List<SaleDetail>();
}
