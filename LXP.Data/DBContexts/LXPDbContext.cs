using System;
using System.Collections.Generic;
using LXP.Common.Entities;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace LXP.Common;

public partial class LXPDbContext : DbContext
{
    public LXPDbContext()
    {
    }

    public LXPDbContext(DbContextOptions<LXPDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Efmigrationshistory> Efmigrationshistories { get; set; }

    public virtual DbSet<Moviedetail> Moviedetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;database=moviecenter1;uid=root;pwd=Password@12345", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.33-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Efmigrationshistory>(entity =>
        {
            entity.HasKey(e => e.MigrationId).HasName("PRIMARY");

            entity.ToTable("__efmigrationshistory");

            entity.Property(e => e.MigrationId).HasMaxLength(150);
            entity.Property(e => e.ProductVersion).HasMaxLength(32);
        });

        modelBuilder.Entity<Moviedetail>(entity =>
        {
            entity.HasKey(e => e.MovieId).HasName("PRIMARY");

            entity.ToTable("moviedetails");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
