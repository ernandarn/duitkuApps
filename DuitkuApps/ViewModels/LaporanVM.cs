using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DuitkuApps.ViewModels
{
    public class LaporanVM
    {
        [Key]
        public int Id_komponen { get; set; }

        [Required]
        [Display(Name = "Nama Komponen")]
        [StringLength(20)]
        public string Nama_komponen { get; set; }

        [Key]
        public int Id_pengeluaran { get; set; }

        [Required]
        [Column(TypeName = "money")]
        public decimal Jumlah { get; set; }

        [Key]
        public int Id_cicilan { get; set; }

        [Column(TypeName = "money")]
        [Display(Name = "Jumlah Bayar")]
        public decimal Jmlh_bayar { get; set; }
    }
}