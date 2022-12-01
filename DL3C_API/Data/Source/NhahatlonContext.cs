using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DL3C_API.Data.Source;

public partial class NhahatlonContext : DbContext
{
    public NhahatlonContext()
    {
    }

    public NhahatlonContext(DbContextOptions<NhahatlonContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Body> Bodies { get; set; }

    public virtual DbSet<BodyComp> BodyComps { get; set; }

    public virtual DbSet<Building> Buildings { get; set; }

    public virtual DbSet<Face> Faces { get; set; }

    public virtual DbSet<Node> Nodes { get; set; }

    public virtual DbSet<Prism> Prisms { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=NHAHATLON;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Body>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("PK_IdBody")
                .IsClustered(false);

            entity.ToTable("Body");

            entity.Property(e => e.Id).HasDefaultValueSql("(newsequentialid())");
            entity.Property(e => e.BodyDescription)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.BodyName)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Color)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.EdgeColor)
                .HasMaxLength(1)
                .IsUnicode(false);

            entity.HasOne(d => d.IdBuildingNavigation).WithMany(p => p.Bodies)
                .HasForeignKey(d => d.IdBuilding)
                .HasConstraintName("FK_IdBuilding_Body");
        });

        modelBuilder.Entity<BodyComp>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("PK_IdBodyComp")
                .IsClustered(false);

            entity.ToTable("BodyComp");

            entity.Property(e => e.Id).HasDefaultValueSql("(newsequentialid())");

            entity.HasOne(d => d.IdBodyNavigation).WithMany(p => p.BodyComps)
                .HasForeignKey(d => d.IdBody)
                .HasConstraintName("FK_IdBody_BodyComp");

            entity.HasMany(d => d.IdFaces).WithMany(p => p.IdBodyComps)
                .UsingEntity<Dictionary<string, object>>(
                    "BodyCompFace",
                    r => r.HasOne<Face>().WithMany()
                        .HasForeignKey("IdFace")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_IdFace_BodyComp_Face"),
                    l => l.HasOne<BodyComp>().WithMany()
                        .HasForeignKey("IdBodyComp")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_IdBodyComp_BodyComp_Face"),
                    j =>
                    {
                        j.HasKey("IdBodyComp", "IdFace")
                            .HasName("PK_IdBodyComp_Face")
                            .IsClustered(false);
                        j.ToTable("BodyComp_Face");
                    });
        });

        modelBuilder.Entity<Building>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("PK_IdBuilding")
                .IsClustered(false);

            entity.ToTable("Building");

            entity.Property(e => e.Id).HasDefaultValueSql("(newsequentialid())");
            entity.Property(e => e.BuildingAddress)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.BuildingDescription)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.BuildingName)
                .HasMaxLength(1)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Face>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("PK_IdFace")
                .IsClustered(false);

            entity.ToTable("Face");

            entity.Property(e => e.Id).HasDefaultValueSql("(newsequentialid())");
            entity.Property(e => e.FaceName)
                .HasMaxLength(1)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Node>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("PK_IdNode")
                .IsClustered(false);

            entity.ToTable("Node");

            entity.Property(e => e.Id).HasDefaultValueSql("(newsequentialid())");
            entity.Property(e => e.ValueX).HasColumnName("valueX");
            entity.Property(e => e.ValueY).HasColumnName("valueY");
            entity.Property(e => e.ValueZ).HasColumnName("valueZ");

            entity.HasMany(d => d.IdFaces).WithMany(p => p.IdNodes)
                .UsingEntity<Dictionary<string, object>>(
                    "NodeFace",
                    r => r.HasOne<Face>().WithMany()
                        .HasForeignKey("IdFace")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_IdFace_Node_Face"),
                    l => l.HasOne<Node>().WithMany()
                        .HasForeignKey("IdNode")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_IdNode_Node_Face"),
                    j =>
                    {
                        j.HasKey("IdNode", "IdFace")
                            .HasName("PK_IdNode_IdFace")
                            .IsClustered(false);
                        j.ToTable("Node_Face");
                    });
        });

        modelBuilder.Entity<Prism>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("PK_IdPrism")
                .IsClustered(false);

            entity.ToTable("Prism");

            entity.Property(e => e.Id).HasDefaultValueSql("(newsequentialid())");

            entity.HasOne(d => d.IdBodyNavigation).WithMany(p => p.Prisms)
                .HasForeignKey(d => d.IdBody)
                .HasConstraintName("FK_IdBody_Prism");

            entity.HasOne(d => d.IdFaceNavigation).WithMany(p => p.Prisms)
                .HasForeignKey(d => d.IdFace)
                .HasConstraintName("FK_IdFace_Prism");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
