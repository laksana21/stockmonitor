using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace APIBackend.DBModels;

[Table("tb_transaction")]
public partial class TbTransaction
{
    [Key]
    [Column("id")]
    [StringLength(100)]
    public string Id { get; set; } = null!;

    [Column("user_id")]
    [StringLength(50)]
    public string UserId { get; set; } = null!;

    [Column("item")]
    [StringLength(50)]
    public string Item { get; set; } = null!;

    [Column("pcs", TypeName = "int(11)")]
    public int Pcs { get; set; }

    [Column("price")]
    [Precision(10, 0)]
    public decimal Price { get; set; }

    [Column("transaction_time", TypeName = "time")]
    public TimeOnly TransactionTime { get; set; }

    [Column("transaction_date")]
    public DateOnly TransactionDate { get; set; }
}
