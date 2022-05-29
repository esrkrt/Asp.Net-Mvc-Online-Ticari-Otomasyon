using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcTicariOtomasyon.Models.Siniflar
{
    public class Mesajlar
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName ="VarChar")]
        [StringLength(50)]
        public string Gonderici { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(50)]
        public string Alici { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(50)]
        public string Konu { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(2000)]
        public string icerik { get; set; }
        [Column(TypeName = "Date")]
        public DateTime Tarih { get; set; }
    }
}