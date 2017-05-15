using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DuitkuApps.Models;
using System.ComponentModel.DataAnnotations;

namespace DuitkuApps.ViewModels
{
    public class PenggunaVM
    {
        [Key]
        public int IdPengguna { get; set; }

        [Required]
        [Display(Name = "Username")]
        [StringLength(256)]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Nama Lengkap")]
        [StringLength(20)]
        public string NamaPengguna { get; set; }

        [Required]
        public string Alamat { get; set; }

        [Required]
        [Display(Name = "Sumber Penghasilan")]
        public int IdSumber { get; set; }

        [Required]
        [StringLength(25)]
        public string SumberPenghasilan { get; set; }

        [Required]
        [Display(Name = "No. Hp")]
        [StringLength(12)]
        public string NoHp { get; set; }

        [Required]
        [Display(Name = "No. NPWP")]
        [StringLength(15)]
        public string NoNPWP { get; set; }

        [Required]
        [Display(Name = "No. KTP")]
        [StringLength(16)]
        public string NoKTP { get; set; }

        [Required]
        [Display(Name = "Status")]
        public int IdStatus { get; set; }

        [Required]
        [StringLength(13)]
        public string NamaStatus { get; set; }

        [Required]
        [Display(Name = "Jumlah Tanggungan")]
        public int JmlTanggungan { get; set; }
    }
}