using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace QLHopDong.Models;

public partial class QlhopDongContext : DbContext
{
    public QlhopDongContext()
    {
    }

    public QlhopDongContext(DbContextOptions<QlhopDongContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Contract> Contracts { get; set; }

    public virtual DbSet<ContractDetail> ContractDetails { get; set; }

    public virtual DbSet<PartyA> PartyAs { get; set; }

    public virtual DbSet<PartyB> PartyBs { get; set; }

    public virtual DbSet<Term> Terms { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=MT\\MT;Initial Catalog=QLHopDong;Integrated Security=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Contract>(entity =>
        {
            entity.ToTable("Contract");

            entity.Property(e => e.ContractId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("ContractID");
            entity.Property(e => e.ContractName).HasMaxLength(150);
            entity.Property(e => e.ContractType).HasMaxLength(50);
        });

        modelBuilder.Entity<ContractDetail>(entity =>
        {
            entity.ToTable("ContractDetail");

            entity.Property(e => e.ContractDetailId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("ContractDetailID");
            entity.Property(e => e.ContractDetailContent).HasColumnType("text");
            entity.Property(e => e.ContractDetailStatus).HasMaxLength(20);
            entity.Property(e => e.ContractId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("ContractID");
            entity.Property(e => e.PartyAid)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("PartyAID");
            entity.Property(e => e.PartyBid)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("PartyBID");

            entity.HasOne(d => d.Contract).WithMany(p => p.ContractDetails)
                .HasForeignKey(d => d.ContractId)
                .HasConstraintName("FK_ContractDetail_Contract");

            entity.HasOne(d => d.PartyA).WithMany(p => p.ContractDetails)
                .HasForeignKey(d => d.PartyAid)
                .HasConstraintName("FK_ContractDetail_PartyA");

            entity.HasOne(d => d.PartyB).WithMany(p => p.ContractDetails)
                .HasForeignKey(d => d.PartyBid)
                .HasConstraintName("FK_ContractDetail_PartyB");
        });

        modelBuilder.Entity<PartyA>(entity =>
        {
            entity.ToTable("PartyA");

            entity.Property(e => e.PartyAid)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("PartyAID");
            entity.Property(e => e.PartyAaccount)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("PartyAAccount");
            entity.Property(e => e.PartyAaddress)
                .HasMaxLength(255)
                .HasColumnName("PartyAAddress");
            entity.Property(e => e.PartyAcontact)
                .HasMaxLength(15)
                .HasColumnName("PartyAContact");
            entity.Property(e => e.PartyAname)
                .HasMaxLength(100)
                .HasColumnName("PartyAName");
            entity.Property(e => e.PartyAposition)
                .HasMaxLength(50)
                .HasColumnName("PartyAPosition");
            entity.Property(e => e.PartyArepresentive)
                .HasMaxLength(100)
                .HasColumnName("PartyARepresentive");
            entity.Property(e => e.PartyAtax)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("PartyATax");
        });

        modelBuilder.Entity<PartyB>(entity =>
        {
            entity.ToTable("PartyB");

            entity.Property(e => e.PartyBid)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("PartyBID");
            entity.Property(e => e.PartyBaccount)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("PartyBAccount");
            entity.Property(e => e.PartyBaddress)
                .HasMaxLength(255)
                .HasColumnName("PartyBAddress");
            entity.Property(e => e.PartyBcontact)
                .HasMaxLength(15)
                .HasColumnName("PartyBContact");
            entity.Property(e => e.PartyBname)
                .HasMaxLength(100)
                .HasColumnName("PartyBName");
            entity.Property(e => e.PartyBposition)
                .HasMaxLength(50)
                .HasColumnName("PartyBPosition");
            entity.Property(e => e.PartyBrepresentive)
                .HasMaxLength(100)
                .HasColumnName("PartyBRepresentive");
            entity.Property(e => e.PartyBtax)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("PartyBTax");
        });

        modelBuilder.Entity<Term>(entity =>
        {
            entity.ToTable("Term");

            entity.Property(e => e.TermId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("TermID");
            entity.Property(e => e.ContractId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("ContractID");
            entity.Property(e => e.TermDetail).HasColumnType("text");

            entity.HasOne(d => d.Contract).WithMany(p => p.Terms)
                .HasForeignKey(d => d.ContractId)
                .HasConstraintName("FK_Term_Contract");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
