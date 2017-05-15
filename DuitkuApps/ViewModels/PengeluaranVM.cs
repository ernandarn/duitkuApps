using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DuitkuApps.ViewModels
{
    public class PengeluaranVM
    {
        [Key]
        public int Id_komponen { get; set; }

        //[Required]
        //[StringLength(256)]
        //public string Username { get; set; }

        //public int Id_cicilan { get; set; }

        [Required]
        [StringLength(20)]
        [DisplayName("Nama Komponen")]
        public string Nama_komponen { get; set; }

        //[Required]
        //[DisplayName("Batas Maksimal")]
        //public int Batas_max { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id_pengeluaran { get; set; }

        //public int Id_realisasi { get; set; }

        [Column(TypeName = "date")]
        public DateTime Tanggal { get; set; }

        [Required]
        [StringLength(20)]
        [DisplayName("Nama Pengeluaran")]
        public string Nama_pengeluaran { get; set; }

        [Column(TypeName = "money")]
        public decimal Jumlah { get; set; }

        [Required]
        [StringLength(50)]
        public string Keterangan { get; set; }


        
    }
}