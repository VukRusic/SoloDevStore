using Solo.Domain;
using Solo.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solo.EntityFramework
{
    public class RecenzijaRepository : IRecenzija
    {
        SoloEntities soloEntities = new SoloEntities();
        public void AddRecenzija(RecenzijaBo recenzija)
        {
            throw new NotImplementedException();
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
    }
}
