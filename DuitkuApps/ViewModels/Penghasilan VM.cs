using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using DuitkuApps.Models;

namespace DuitkuApps.ViewModels
{
    public class Penghasilan_VM
    {
        public DateTime? tgl_mulai { get; set; }
        public DateTime? tgl_selesai { get; set; }
        public virtual ICollection<Penghasilan> hasil { get; set; }
    }
}