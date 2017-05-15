using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DuitkuApps.ViewModels
{
    public class PengeluaranAllView
    {
        [Key]
        public int Id_komponen { get; set; }

        [Required]
        [StringLength(256)]
        public string Username { get; set; }

        public int? Id_cicilan { get; set; }

        [Required]
        [Display(Name = "Nama Komponen")]
        [StringLength(20)]
        public string Nama_komponen { get; set; }

        [Required]
        [Display(Name = "Batas Maksimal")]
        public int Batas_max { get; set; }


        [Key]
        public int Id_pengeluaran { get; set; }

        [Required]
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

        [Key]
        public int Id_realisasi { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime TanggalRealisasi { get; set; }

        [Required]
        [StringLength(20)]
        public string Nama_realisasi { get; set; }
    }
}