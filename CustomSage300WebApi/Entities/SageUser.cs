using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CustomSage300WebApi.Entities;

[Keyless]
[Table("SageUser")]
public partial class SageUser
{
    public int? Id { get; set; }

    [StringLength(50)]
    public string FirstName { get; set; } = null!;

    [StringLength(50)]
    public string? Surname { get; set; }

    [StringLength(50)]
    public string? OtherName { get; set; }

    [StringLength(50)]
    public string Email { get; set; } = null!;

    [StringLength(15)]
    public string? Phone { get; set; }

    [StringLength(10)]
    public string? CompanyId { get; set; }

    [StringLength(30)]
    public string? Username { get; set; }

    public string? Password { get; set; }

    [StringLength(10)]
    public string? isAdmin { get; set; }

    [StringLength(10)]
    public string? Status { get; set; }
}
