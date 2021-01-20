using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebChat.Models
{
    public class KorisnikRegistrationModel
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }

        [Required(ErrorMessage = "Morate uneti korisnickoIme")]
        [DataType(DataType.Text)]
        public string KorisnickoIme { get; set; }
        [Required(ErrorMessage= "Morate uneti mejl!")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage ="Morate uneti sifru!")]
        [DataType(DataType.Password)]
        public string Sifra { get; set; }
        [DataType(DataType.Password)]
        [Compare("Sifra", ErrorMessage ="Sifre moraju biti iste")]
        public string PotvrdnaSifra { get; set; }






    }
}
