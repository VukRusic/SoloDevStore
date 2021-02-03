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

        public IEnumerable<ProizvodBo> GetProizvodByTema(string tema)
        {
            List<ProizvodBo> proizvods = new List<ProizvodBo>();
            IEnumerable<RegistrovanProizvod> proizvodi = soloEntities.RegistrovanProizvods.Where(t => t.Tema == tema).ToList();
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
                Tema = proizvod.Tema,
                PrepStarDoba = proizvod.PrepStarDoba,
                Procenat = proizvod.Procenat,
                Cena = (int)proizvod.Cena
            };

            return proizvodBo;
        }
    }
}
