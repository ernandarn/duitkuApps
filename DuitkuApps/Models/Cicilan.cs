namespace DuitkuApps.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Cicilan")]
    public partial class Cicilan
    {
        [Key]
        public int Id_cicilan { get; set; }

        public int Id_komponen { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Nama Cicilan")]
        public string Nama_cicilan { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Tanggal Mulai")]
        [DisplayFormat(DataFormatString = "{0:dd/MMM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Tgl_mulai { get; set; }

        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:dd/MMM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Tanggal Jatuh Tempo")]
        public DateTime Tgl_bayar { get; set; }

        [Column(TypeName = "money")]
        [Display(Name = "Jumlah Bayar")]
        public decimal Jmlh_bayar { get; set; }

        public virtual Komp_Pengeluaran Komp_Pengeluaran { get; set; }
    }
}
