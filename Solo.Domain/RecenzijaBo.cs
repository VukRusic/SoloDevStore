using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solo.Domain
{
    public class RecenzijaBo
    {
        public int Id { get; set; }
        public string UsernameKorisnika { get; set; }
        public int IdProizvoda { get; set; }
        public string Komentar { get; set; }
        [Required(ErrorMessage ="Morate uneti ocenu")]
        [Range(1,5,ErrorMessage ="Ocena mora da bude od 1 do 5")]
        public int Ocena { get; set; }
        public DateTime? Datum { get; set; }
    }
}
