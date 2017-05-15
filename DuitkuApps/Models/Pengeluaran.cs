namespace DuitkuApps.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Pengeluaran")]
    public partial class Pengeluaran
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pengeluaran()
        {
            Anggaran = new HashSet<Anggaran>();
        }

        [Key]
        public int Id_pengeluaran { get; set; }

        [Required]
        [Display(Name = "Kode Komponen")]
        public int Id_komponen { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MMM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Tanggal { get; set; }

        [Required]
        [Display(Name = "Nama Pengeluaran")]
        [StringLength(20)]
        public string Nama_pengeluaran { get; set; }

        [Required]
        [Column(TypeName = "money")]
        public decimal Jumlah { get; set; }

        [Required]
        [StringLength(50)]
        public string Keterangan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Anggaran> Anggaran { get; set; }

        public virtual Komp_Pengeluaran Komp_Pengeluaran { get; set; }
    }
}
