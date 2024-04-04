using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CustomSage300WebApi.Entities;

[Table("SageModule")]
public partial class SageModule
{
    [Key]
    public int Id { get; set; }

    [StringLength(10)]
    public string? Code { get; set; }

    [StringLength(10)]
    public string? Name { get; set; }
}
