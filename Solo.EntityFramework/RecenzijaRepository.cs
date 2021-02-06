using Solo.Domain;
using Solo.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solo.EntityFramework
{
    public class RecenzijaRepository : IRecenzijaRepository
    {
        SoloEntities soloEntities = new SoloEntities();
        public void AddRecenzija(RecenzijaBo recenzija)
        {
            Recenzija recenzijaModel = new Recenzija()
            {
                Ocena = recenzija.Ocena,
                Komentar = recenzija.Komentar,
                IdProizvoda = recenzija.IdProizvoda,
                IdKorisnika = GetKorisnikIdByUsername(recenzija.UsernameKorisnika),
                Datum = DateTime.Now
            };

            soloEntities.Recenzijas.Add(recenzijaModel);
            soloEntities.SaveChanges();
        }

        public IEnumerable<RecenzijaBo> GetRecenzijasByProizvodId(int id)
        {
            List<RecenzijaBo> recenzijes = new List<RecenzijaBo>();
            IEnumerable<Recenzija>recenzije = soloEntities.Recenzijas.Where(t => t.IdProizvoda == id);
            foreach (Recenzija recenzija in recenzije)
            {
                recenzijes.Add(Map(recenzija));
            }

            return recenzijes;
        }

        private string GetUsernameByKorisnikId(int id)
        {
            return soloEntities.Users.Where(t => t.Id == id).Single().Username;
        }

        private int GetKorisnikIdByUsername(string username)
        {
            return soloEntities.Users.Where(t => t.Username == username).Single().Id;
        }

        private RecenzijaBo Map(Recenzija recenzija)
        {
            RecenzijaBo recenzijaBo = new RecenzijaBo()
            {
                Id = recenzija.Id,
                UsernameKorisnika = GetUsernameByKorisnikId(recenzija.IdKorisnika),
                IdProizvoda = recenzija.IdProizvoda,
                Komentar = recenzija.Komentar,
                Ocena = recenzija.Ocena,
                Datum = recenzija.Datum
            };

            return recenzijaBo;
        }

        public bool IsMade(RecenzijaBo recenzija)
        {
            int idKorisnika = GetKorisnikIdByUsername(recenzija.UsernameKorisnika);
            return !soloEntities.Recenzijas.Any(t => t.IdKorisnika == idKorisnika && t.IdProizvoda == recenzija.IdProizvoda);
        }
    }
}
