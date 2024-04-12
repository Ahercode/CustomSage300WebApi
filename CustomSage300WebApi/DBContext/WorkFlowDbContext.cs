using System;
using System.Collections.Generic;
using CustomSage300WebApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace CustomSage300WebApi.DBContext;

public partial class WorkFlowDbContext : DbContext
{
    public WorkFlowDbContext()
    {
    }

    public WorkFlowDbContext(DbContextOptions<WorkFlowDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<SageModule> SageModules { get; set; }

    public virtual DbSet<SageModuleUser> SageModuleUsers { get; set; }

    public virtual DbSet<SageUser> SageUsers { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SageModule>(entity =>
        {
            entity.Property(e => e.Code).IsFixedLength();
            entity.Property(e => e.Name).IsFixedLength();
        });

        modelBuilder.Entity<SageModuleUser>(entity =>
        {
            entity.Property(e => e.isApprover).IsFixedLength();
        });

        modelBuilder.Entity<SageUser>(entity =>
        {
            entity.Property(e => e.CompanyId).IsFixedLength();
            entity.Property(e => e.Status).IsFixedLength();
            entity.Property(e => e.isAdmin).IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
