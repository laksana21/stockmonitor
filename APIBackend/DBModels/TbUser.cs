using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace APIBackend.DBModels;

[Table("tb_users")]
public partial class TbUser
{
    [Key]
    [Column("id")]
    [StringLength(50)]
    public string Id { get; set; } = null!;

    [Column("username")]
    [StringLength(255)]
    public string Username { get; set; } = null!;

    [Column("password")]
    [StringLength(100)]
    public string Password { get; set; } = null!;

    [Column("name")]
    [StringLength(255)]
    public string? Name { get; set; }

    [Column("date_add", TypeName = "datetime")]
    public DateTime DateAdd { get; set; }
}
