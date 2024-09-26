using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CustomSage300WebApi.Entities;

[Table("WorkFlowDetail")]
public partial class WorkFlowDetail
{
    [Key]
    public int Id { get; set; }

    public int ApplicationId { get; set; }

    [StringLength(80)]
    public string? Name { get; set; }

    public string? Description { get; set; }
}
