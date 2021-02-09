using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solo.Domain
{
    public class NalogBo
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Nije uneto ime korisnika")]
        public string Ime { get; set; }
        [Required(ErrorMessage = "Nije uneto prezime korisnika")]
        public string Prezime { get; set; }
        [Required(ErrorMessage = "Nije unet JMBG")]
        [Range(1, 1000000000, ErrorMessage = "JMBG ne moze da bude duzi od 10 karaktera")]
        public string JMBG { get; set; }
        [Required(ErrorMessage = "Nije unet username")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Nije uneta sifra")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Nije uneta vrsta naloga")]
        public string Vrsta { get; set; }
        public string Stanje { get; set; }
        [Required(ErrorMessage = "Morate uneti broj racuna")]
        public string RacunID { get; set; }


    }
}
