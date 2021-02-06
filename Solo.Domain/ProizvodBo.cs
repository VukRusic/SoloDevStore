using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solo.Domain
{
    public class ProizvodBo
    {
        public int Id { get; set; }
        public int IdDev { get; set; }
        public string Naziv { get; set; }
        public string Zanr { get; set; }
        public int BrojIgraca { get; set; }
        public int PrepStarDoba { get; set; }
        public int Cena { get; set; }
        public int? Procenat { get; set; }
        public string Opis { get; set; }
    }
}
