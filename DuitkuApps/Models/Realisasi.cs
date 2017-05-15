namespace DuitkuApps.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Realisasi")]
    public partial class Realisasi
    {
        [Key]
        public int Id_realisasi { get; set; }

        [Display(Name = "ID Komponen")]
        public int id_komponen { get; set; }

        [Required]
        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Tanggal { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Nama Realisasi")]
        public string Nama_realisasi { get; set; }

        [Required]
        [Column(TypeName = "money")]
        public decimal Jumlah { get; set; }

        public virtual Komp_Pengeluaran Komp_Pengeluaran { get; set; }
    }
}
