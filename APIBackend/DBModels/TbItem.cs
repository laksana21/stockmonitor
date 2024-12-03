using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace APIBackend.DBModels;

[Table("tb_items")]
public partial class TbItem
{
    [Key]
    [Column("id")]
    [StringLength(50)]
    public string Id { get; set; } = null!;

    [Column("item_name", TypeName = "mediumtext")]
    public string? ItemName { get; set; }

    [Column("price")]
    public double Price { get; set; }

    [Column("stock", TypeName = "int(15)")]
    public int Stock { get; set; }

    [Column("category")]
    [StringLength(50)]
    public string Category { get; set; } = null!;

    [Column("image_url", TypeName = "text")]
    public string? ImageUrl { get; set; }

    [Column("date_add", TypeName = "datetime")]
    public DateTime DateAdd { get; set; }

    [Column("date_edit", TypeName = "datetime")]
    public DateTime DateEdit { get; set; }

    [Column("user_add")]
    [StringLength(50)]
    public string UserAdd { get; set; } = null!;

    [Column("user_edit")]
    [StringLength(50)]
    public string UserEdit { get; set; } = null!;
}
