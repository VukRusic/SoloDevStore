using Solo.Domain;
using Solo.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solo.EntityFramework
{
    public class ProizvodRepository : IProizvod
    {
        SoloEntities soloEntities = new SoloEntities();
        public IEnumerable<ProizvodBo> GetAll()
        {
            List<ProizvodBo> proizvods = new List<ProizvodBo>();

            foreach (RegistrovanProizvod proizvod in soloEntities.RegistrovanProizvods)
            {
                proizvods.Add(Map(proizvod));
            }

            return proizvods;
        }

        public ProizvodBo GetProizvodById(int id)
        {
            RegistrovanProizvod proizvod =  soloEntities.RegistrovanProizvods.Where(t => t.Id == id).Single();
            return Map(proizvod);
        }

        public IEnumerable<ProizvodBo> GetProizvodByZanr(string zanr)
        {
            List<ProizvodBo> proizvods = new List<ProizvodBo>();
            IEnumerable<RegistrovanProizvod> proizvodi = soloEntities.RegistrovanProizvods.Where(t => t.Zanr == zanr).ToList();
            foreach (RegistrovanProizvod proizvod in proizvodi)
            {
                proizvods.Add(Map(proizvod));
            }
            return proizvods;
        }

        public IEnumerable<ProizvodBo> GetProzivodByIme(string ime)
        {
            List<ProizvodBo> proizvods = new List<ProizvodBo>();
            IEnumerable<RegistrovanProizvod> proizvodi = soloEntities.RegistrovanProizvods.Where(p => p.Naziv.Contains(ime));
            foreach (RegistrovanProizvod proizvod in proizvodi)
            {
                proizvods.Add(Map(proizvod));
            }
            return proizvods;
        }

        private ProizvodBo Map(RegistrovanProizvod proizvod)
        {
            ProizvodBo proizvodBo = new ProizvodBo()
            {
                Id = proizvod.Id,
                IdDev = proizvod.IdDevelopera,
                BrojIgraca = proizvod.BrojIgraca,
                Zanr = proizvod.Zanr,
                Naziv = proizvod.Naziv,
                PrepStarDoba = proizvod.PrepStarDoba,
                Procenat = proizvod.Procenat,
                Cena = (int)proizvod.Cena,
                Opis = proizvod.Opis
            };

            return proizvodBo;
        }

        public string GetDeveloperByProizvodId(int id)
        {
            ProizvodBo proizvod = GetProizvodById(id);
            return soloEntities.Users.Where(t => t.Id == proizvod.IdDev).Single().Username;
        }
    }
}
