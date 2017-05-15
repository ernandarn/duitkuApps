using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DuitkuApps.ViewModels
{
    public class Penghasilan_VM
    {
        [Key]
        public int Id_anggaran { get; set; }

        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime Bulan { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime Tahun { get; set; }


        [Required]
        public int Id_penghasilan { get; set; }

        [Required]
        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        public DateTime Tanggal { get; set; }

        [Required]
        [StringLength(20)]
        [DisplayName("Nama Penghasilan")]
        public string Nama_penghasilan { get; set; }

        [Required]
        [Column(TypeName = "money")]
        public decimal Jumlah { get; set; }

        [Required]
        [StringLength(50)]
        public string Keterangan { get; set; }

        public IEnumerable<System.Web.Mvc.SelectListItem> bulan { get; set; }
        public IEnumerable<System.Web.Mvc.SelectListItem> tahun { get; set; }
    }
}