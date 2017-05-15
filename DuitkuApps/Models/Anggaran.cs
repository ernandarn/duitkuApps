namespace DuitkuApps.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Anggaran")]
    public partial class Anggaran
    {
        [Key]
        public int Id_anggaran { get; set; }

        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        public int? Id_penghasilan { get; set; }

        public int? Id_pengeluaran { get; set; }

        [Column(TypeName = "date")]
        public DateTime Bulan { get; set; }

        [Column(TypeName = "date")]
        public DateTime Tahun { get; set; }

        public virtual Pengeluaran Pengeluaran { get; set; }

        public virtual Penghasilan Penghasilan { get; set; }
    }
}
