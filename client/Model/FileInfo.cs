//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DocumentArchive.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class FileInfo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FileInfo()
        {
            this.Description1 = new HashSet<Description>();
            this.FilterStorage = new HashSet<FilterStorage>();
            this.UserFile = new HashSet<UserFile>();
        }
    
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Size { get; set; }
        public System.DateTime Created { get; set; }
        public byte[] Expression { get; set; }
        public int CategoryId { get; set; }
        public int AccessLevelId { get; set; }
        public string ShareLink { get; set; }
        public bool IsPinned { get; set; }
    
        public virtual Category Category { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Description> Description1 { get; set; }
        public virtual FileAccessLevel FileAccessLevel { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FilterStorage> FilterStorage { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserFile> UserFile { get; set; }
    }
}
