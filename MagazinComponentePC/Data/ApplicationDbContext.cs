using System;
using System.Collections.Generic;
using MagazinComponentePC.Models.DBObjects;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MagazinComponentePC.Data;

public partial class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

   // public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    //public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }

   // public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

   // public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

    //public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

    //public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }

    public virtual DbSet<Comenzi> Comenzis { get; set; }

    public virtual DbSet<DetaliiComanda> DetaliiComanda { get; set; }

    public virtual DbSet<Produse> Produses { get; set; }

    public virtual DbSet<Utilizatori> Utilizatoris { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        /*modelBuilder.Entity<AspNetRole>(entity =>
        {
            entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedName] IS NOT NULL)");

            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.NormalizedName).HasMaxLength(256);
        });

        modelBuilder.Entity<AspNetRoleClaim>(entity =>
        {
            entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

            entity.HasOne(d => d.Role).WithMany(p => p.AspNetRoleClaims).HasForeignKey(d => d.RoleId);
        });

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

            entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedUserName] IS NOT NULL)");

            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
            entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
            entity.Property(e => e.UserName).HasMaxLength(256);

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AspNetUserRole",
                    r => r.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                    l => l.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId");
                        j.ToTable("AspNetUserRoles");
                        j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                    });
        });

        modelBuilder.Entity<AspNetUserClaim>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserClaims).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserLogin>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

            entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

            entity.Property(e => e.LoginProvider).HasMaxLength(128);
            entity.Property(e => e.ProviderKey).HasMaxLength(128);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserLogins).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserToken>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

            entity.Property(e => e.LoginProvider).HasMaxLength(128);
            entity.Property(e => e.Name).HasMaxLength(128);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserTokens).HasForeignKey(d => d.UserId);
        });*/

        modelBuilder.Entity<Comenzi>(entity =>
        {
            entity.HasKey(e => e.ComandaId).HasName("PK__Comenzi__845B4DBC303B22CF");

            entity.ToTable("Comenzi");

            entity.Property(e => e.ComandaId)
                .ValueGeneratedNever()
                .HasColumnName("ComandaID");
            entity.Property(e => e.DataComanda)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Stare)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Comenzis)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Comenzi_ToUtilizatori");
        });

        modelBuilder.Entity<DetaliiComanda>(entity =>
        {
            entity.HasKey(e => e.DetaliiId).HasName("PK__DetaliiC__5182AC376F557BA9");

            entity.Property(e => e.DetaliiId)
                .ValueGeneratedNever()
                .HasColumnName("DetaliiID");
            entity.Property(e => e.ComandaId).HasColumnName("ComandaID");
            entity.Property(e => e.PretProdus).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ProdusId).HasColumnName("ProdusID");

            entity.HasOne(d => d.Comanda).WithMany(p => p.DetaliiComanda)
                .HasForeignKey(d => d.ComandaId)
                .HasConstraintName("FK_DetaliiComanda_ToComenzi");

            entity.HasOne(d => d.Produs).WithMany(p => p.DetaliiComanda)
                .HasForeignKey(d => d.ProdusId)
                .HasConstraintName("FK_DetaliiComanda_ToProduse");
        });

        modelBuilder.Entity<Produse>(entity =>
        {
            entity.HasKey(e => e.ProdusId).HasName("PK__Produse__09083E94DB357952");

            entity.ToTable("Produse");

            entity.Property(e => e.ProdusId)
                .ValueGeneratedNever()
                .HasColumnName("ProdusID");
            entity.Property(e => e.Descriere)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.NumeProdus)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Pret).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<Utilizatori>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Utilizat__1788CCACB3DA232B");

            entity.ToTable("Utilizatori");

            entity.HasIndex(e => e.Email, "UQ__Utilizat__A9D10534AC0426FC").IsUnique();

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("UserID");
            entity.Property(e => e.DataInregistrare)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nume)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Parola)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
