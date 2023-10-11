using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PruebaTecnica.Model;

[Table("product")]
public partial class Product
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(255)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [Column("price", TypeName = "money")]
    public decimal Price { get; set; }

    [Column("image")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Image { get; set; }

    [Column("stock")]
    public int? Stock { get; set; }

    [Column("createdAt", TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [Column("updatedAt", TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [InverseProperty("IdProductNavigation")]
    public virtual ICollection<SaleDetail> SaleDetails { get; set; } = new List<SaleDetail>();
}
