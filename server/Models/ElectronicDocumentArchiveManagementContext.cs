using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DocumentArchiveWebAPI.Models;

public partial class ElectronicDocumentArchiveManagementContext : DbContext
{
    public ElectronicDocumentArchiveManagementContext()
    {
    }

    public ElectronicDocumentArchiveManagementContext(DbContextOptions<ElectronicDocumentArchiveManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Description> Descriptions { get; set; }

    public virtual DbSet<FileAccessLevel> FileAccessLevels { get; set; }

    public virtual DbSet<FileInfo> FileInfos { get; set; }

    public virtual DbSet<FilterStorage> FilterStorages { get; set; }

    public virtual DbSet<GuestFileInfo> GuestFileInfos { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<TextSearching> TextSearchings { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserFile> UserFiles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("Category");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Description>(entity =>
        {
            entity.ToTable("Description");

            entity.Property(e => e.Information).HasMaxLength(400);

            entity.HasOne(d => d.FileInfo).WithMany(p => p.Descriptions)
                .HasForeignKey(d => d.FileInfoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Description_FileInfo");
        });

        modelBuilder.Entity<FileAccessLevel>(entity =>
        {
            entity.ToTable("FileAccessLevel");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<FileInfo>(entity =>
        {
            entity.ToTable("FileInfo");

            entity.Property(e => e.Description).HasMaxLength(400);
            entity.Property(e => e.ShareLink).HasMaxLength(150);
            entity.Property(e => e.Size).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Title).HasMaxLength(400);

            entity.HasOne(d => d.AccessLevel).WithMany(p => p.FileInfos)
                .HasForeignKey(d => d.AccessLevelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FileInfo_FileAccessLevel");

            entity.HasOne(d => d.Category).WithMany(p => p.FileInfos)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FileInfo_Category");
        });

        modelBuilder.Entity<FilterStorage>(entity =>
        {
            entity.ToTable("FilterStorage");

            entity.Property(e => e.Keyword).HasMaxLength(300);

            entity.HasOne(d => d.Description).WithMany(p => p.FilterStorages)
                .HasForeignKey(d => d.DescriptionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FilterStorage_Description");

            entity.HasOne(d => d.FileInfo).WithMany(p => p.FilterStorages)
                .HasForeignKey(d => d.FileInfoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FilterStorage_FileInfo");

            entity.HasOne(d => d.TextSearching).WithMany(p => p.FilterStorages)
                .HasForeignKey(d => d.TextSearchingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FilterStorage_TextSearching");
        });

        modelBuilder.Entity<GuestFileInfo>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("GuestFileInfo");

            entity.Property(e => e.Description).HasMaxLength(400);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.ShareLink).HasMaxLength(150);
            entity.Property(e => e.Title).HasMaxLength(400);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("Role");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<TextSearching>(entity =>
        {
            entity.ToTable("TextSearching");

            entity.Property(e => e.Text).HasMaxLength(400);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_User_1");

            entity.ToTable("User");

            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Login).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(150);

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_Role");
        });

        modelBuilder.Entity<UserFile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_StorageHistory");

            entity.ToTable("UserFile");

            entity.HasOne(d => d.FileInfo).WithMany(p => p.UserFiles)
                .HasForeignKey(d => d.FileInfoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StorageHistory_FileInfo");

            entity.HasOne(d => d.User).WithMany(p => p.UserFiles)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StorageHistory_User");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
