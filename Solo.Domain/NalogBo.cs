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
        [Required(ErrorMessage = "Nije unet username")]
        public string Ime { get; set; }
        [Required]
        public string Prezime { get; set; }
        [Required]
        public string JMBG { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Vrsta { get; set; }
        public string Stanje { get; set; }

        public string RacunID { get; set; }


    }
}
