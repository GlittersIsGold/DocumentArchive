﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DocumentArchive.Model.ADO
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ElectronicDocumentArchiveEntities : DbContext
    {
        public ElectronicDocumentArchiveEntities()
            : base("name=ElectronicDocumentArchiveEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Description> Descriptions { get; set; }
        public virtual DbSet<FileInfo> FileInfoes { get; set; }
        public virtual DbSet<FilterStorage> FilterStorages { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<StatusUpload> StatusUploads { get; set; }
        public virtual DbSet<StorageHistory> StorageHistories { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TextSearching> TextSearchings { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}