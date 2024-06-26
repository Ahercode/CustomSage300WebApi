﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CustomSage300WebApi.Entities;

[Table("SageModuleUser")]
public partial class SageModuleUser
{
    [Key]
    public int Id { get; set; }

    public int? SageModuleId { get; set; }

    public int? UserId { get; set; }

    [StringLength(10)]
    public string? isApprover { get; set; }
}
