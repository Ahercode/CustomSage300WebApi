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

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=208.117.44.15; Database=WorkFlowDB; User ID=sa; Password=Admin@EnP; MultipleActiveResultSets=true; TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SageModule>(entity =>
        {
            entity.Property(e => e.Code).IsFixedLength();
            entity.Property(e => e.Name).IsFixedLength();
        });

        modelBuilder.Entity<SageModuleUser>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
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
