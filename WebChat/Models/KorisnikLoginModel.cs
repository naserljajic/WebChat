using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebChat.Models
{
    public class KorisnikLoginModel
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name ="Korisnicko ime")]
        public string KorisnickoIme { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Sifra { get; set; }

        [Display(Name ="Zapamti me?")]
        public bool ZapamtiMe { get; set; }
    }
}
