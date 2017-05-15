namespace DuitkuApps.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Master_SumberPenghasilan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Master_SumberPenghasilan()
        {
            Pengguna = new HashSet<Pengguna>();
        }

        [Key]
        public int IdSumber { get; set; }

        [Required]
        [StringLength(25)]
        public string SumberPenghasilan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pengguna> Pengguna { get; set; }
    }
}
