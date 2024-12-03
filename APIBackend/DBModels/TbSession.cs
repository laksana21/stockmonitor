using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace APIBackend.DBModels;

[Table("tb_sessions")]
public partial class TbSession
{
    [Key]
    [Column("id")]
    [StringLength(50)]
    public string Id { get; set; } = null!;

    [Column("user_id")]
    [StringLength(50)]
    public string UserId { get; set; } = null!;

    [Column("token")]
    [StringLength(100)]
    public string Token { get; set; } = null!;

    [Column("date_add", TypeName = "datetime")]
    public DateTime DateAdd { get; set; }

    [Column("date_expired", TypeName = "datetime")]
    public DateTime DateExpired { get; set; }
}
