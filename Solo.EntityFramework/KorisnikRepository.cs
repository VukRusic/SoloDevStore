using Solo.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solo.EntityFramework
{
    public class KorisnikRepository : IKorisnikRepository
    {

        SoloEntities soloEntities = new SoloEntities();
        public void SmanjiRacun(int Cena, int korisnikID)
        {
            Korisnik korisnik = soloEntities.Korisniks.Where(k => k.Id == korisnikID).Single();
            if (korisnik == null) return;
            else
            {
                int NoviRacun = Int32.Parse(korisnik.Racun.Stanje) - Cena;
                korisnik.Racun.Stanje = NoviRacun.ToString();
                soloEntities.SaveChanges();
            }

        }
    }
}
