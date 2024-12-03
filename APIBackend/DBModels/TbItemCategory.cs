using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace APIBackend.DBModels;

[Table("tb_item_category")]
public partial class TbItemCategory
{
    [Key]
    [Column("id")]
    [StringLength(50)]
    public string Id { get; set; } = null!;

    [Column("category_name", TypeName = "text")]
    public string CategoryName { get; set; } = null!;

    [Column("user_add")]
    [StringLength(50)]
    public string UserAdd { get; set; } = null!;

    [Column("user_update")]
    [StringLength(50)]
    public string UserUpdate { get; set; } = null!;

    [Column("date_add", TypeName = "datetime")]
    public DateTime DateAdd { get; set; }

    [Column("date_update", TypeName = "datetime")]
    public DateTime DateUpdate { get; set; }
}
