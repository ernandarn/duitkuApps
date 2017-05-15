using DuitkuApps.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DuitkuApps.ViewModels
{
    public class DetailVM
    {
        [Key]
        public int Id_pengeluaran { get; set; }

        //public int? Id_realisasi { get; set; }

        [Required]
        public int Id_komponen { get; set; }

         [Required]
        [Display(Name = "Nama Komponen")]
        [StringLength(20)]
        public string Nama_komponen { get; set; }

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
    }
}