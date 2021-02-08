using Solo.Domain;
using Solo.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solo.EntityFramework
{
    public class RadnikRepository : IRadnikRepository
    {
        SoloEntities soloEntities = new SoloEntities();

        public IEnumerable<string> GetAllDevelopers()
        {
            List<string> developers = new List<string>();
            foreach (Developer developer in soloEntities.Developers)
            {
                developers.Add(developer.Nalog.User.Username);
            }

            return developers;
        }

        public int GetDugovanjaByDeveloper(string username)
        {
            int dugovanja = 0;
            List<EvidencijaProdaje> prodaje = soloEntities.EvidencijaProdajes.Where(e => e.RegistrovanProizvod.Developer.Nalog.User.Username == username && e.Status != "Placeno").ToList();
            foreach (EvidencijaProdaje proizvod in prodaje)
            {
                dugovanja += (int)proizvod.RegistrovanProizvod.Cena;
            }

            return dugovanja;
        }

        public void PayDeveloper(string username)
        {
            int dugovanja = 0;
            User developer = soloEntities.Users.Single(t => t.Username == username);
            List<EvidencijaProdaje> prodaje = soloEntities.EvidencijaProdajes.Where(e => e.RegistrovanProizvod.Developer.Nalog.User.Username == username && e.Status != "Placeno").ToList();
            foreach (EvidencijaProdaje proizvod in prodaje)
            {
                proizvod.Status = "Placeno";
                dugovanja += (int)proizvod.RegistrovanProizvod.Cena;
            }

            int stanje = int.Parse(developer.Nalog.Developer.Racun.Stanje);
            stanje += dugovanja;
            developer.Nalog.Developer.Racun.Stanje = stanje.ToString();
            soloEntities.SaveChanges();
        }
    }
}
