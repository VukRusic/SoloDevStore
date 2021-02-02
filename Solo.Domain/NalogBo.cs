using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solo.Domain
{
    public class NalogBo
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string JMBG { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Vrsta { get; set; }
    }
}
