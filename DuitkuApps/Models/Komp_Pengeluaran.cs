namespace DuitkuApps.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Komp_Pengeluaran
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Komp_Pengeluaran()
        {
            Pengeluaran = new HashSet<Pengeluaran>();
            Cicilan = new HashSet<Cicilan>();
            Realisasi = new HashSet<Realisasi>();
        }

        [Key]
        public int Id_komponen { get; set; }

        [Required]
        [StringLength(256)]
        public string Username { get; set; }

        [Required]
        [Display(Name = "Nama Komponen")]
        [StringLength(20)]
        public string Nama_komponen { get; set; }

        [Required]
        [Display(Name = "Batas Maksimal (%)")]
        public int Batas_max { get; set; }

        

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pengeluaran> Pengeluaran { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cicilan> Cicilan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Realisasi> Realisasi { get; set; }




    }
}
