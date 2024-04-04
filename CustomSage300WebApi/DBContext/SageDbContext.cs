using System;
using System.Collections.Generic;
using CustomSage300WebApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace CustomSage300WebApi.DBContext;

public partial class SageDbContext : DbContext
{
    public SageDbContext()
    {
    }

    public SageDbContext(DbContextOptions<SageDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<POPORI> POPORIs { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<POPORI>(entity =>
        {
            entity.HasKey(e => e.PORISEQ).HasName("POPORI_KEY_0");
            entity.Property(e => e.AGDESC).IsFixedLength();
            entity.Property(e => e.AGDOCNUM).IsFixedLength();
            entity.Property(e => e.AGFISCYEAR).IsFixedLength();
            entity.Property(e => e.AGREF).IsFixedLength();
            entity.Property(e => e.AGSRCDOC).IsFixedLength();
            entity.Property(e => e.AUDTORG).IsFixedLength();
            entity.Property(e => e.AUDTUSER).IsFixedLength();
            entity.Property(e => e.CURRENCY).IsFixedLength();
            entity.Property(e => e.DESCRIPTIO).IsFixedLength();
            entity.Property(e => e.LASTRECEIP).IsFixedLength();
            entity.Property(e => e.PONUMBER).IsFixedLength();
            entity.Property(e => e.RATETYPE).IsFixedLength();
            entity.Property(e => e.RATETYPERC).IsFixedLength();
            entity.Property(e => e.REFERENCE).IsFixedLength();
            entity.Property(e => e.RQNNUMBER).IsFixedLength();
            entity.Property(e => e.TAXAUTH1).IsFixedLength();
            entity.Property(e => e.TAXAUTH2).IsFixedLength();
            entity.Property(e => e.TAXAUTH3).IsFixedLength();
            entity.Property(e => e.TAXAUTH4).IsFixedLength();
            entity.Property(e => e.TAXAUTH5).IsFixedLength();
            entity.Property(e => e.TAXGROUP).IsFixedLength();
            entity.Property(e => e.TRCURRENCY).IsFixedLength();
            entity.Property(e => e.VDCODE).IsFixedLength();
            entity.Property(e => e.VDNAME).IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
