using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solo.Domain
{
    public class ProizvodBo
    {
        public int Id { get; set; }
        public int IdDev { get; set; }
        [Required(ErrorMessage ="Naziv nije unet")]
        public string Naziv { get; set; }
        [Required(ErrorMessage = "Zanr nije unet")]
        public string Zanr { get; set; }
        [Required(ErrorMessage = "Broj igraca nije unet")]
        public int BrojIgraca { get; set; }
        [Required(ErrorMessage = "Preporuceno starosno doba nije uneto")]
        public int PrepStarDoba { get; set; }
        [Required(ErrorMessage = "Cena nije uneta")]
        public int Cena { get; set; }
        public int? Procenat { get; set; }
        [Required(ErrorMessage = "Opis nije unet")]
        public string Opis { get; set; }
    }
}
