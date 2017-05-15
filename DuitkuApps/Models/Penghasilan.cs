namespace DuitkuApps.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Penghasilan")]
    public partial class Penghasilan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Penghasilan()
        {
            Anggaran = new HashSet<Anggaran>();
        }

        [Key]
        public int Id_penghasilan { get; set; }

        [Required]
        //[Display(ResourceType = typeof(MyResources), Name = "Username")]
        [StringLength(256)]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Tanggal { get; set; }

        [Required]
        [Display(Name = "Nama Penghasilan")]
        [StringLength(20)]
        public string Nama_penghasilan { get; set; }

        [Required]
        [Column(TypeName = "money")]
        public int Jumlah { get; set; }

        [Required]
        [StringLength(50)]
        public string Keterangan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Anggaran> Anggaran { get; set; }
    }
}
