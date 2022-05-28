using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcTicariOtomasyon.Models.Siniflar
{
    public class KargoTakip
    {
        [Key]
        public int KargoTakipİd { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(300)]
        public string Aciklama { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string TakipKodu { get; set; }//1234567AB
        public DateTime Tarih { get; set; }
    }
}