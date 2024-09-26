using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CustomSage300WebApi.Entities;

[Table("SageFile")]
public partial class SageFile
{
    [Key]
    public int Id { get; set; }

    [StringLength(10)]
    public string? ItemId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? FileName { get; set; }
}
