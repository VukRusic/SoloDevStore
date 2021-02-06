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
        LogRegRepository _LogRegRepository = new LogRegRepository();
        KorisnikRepository _korisnikRepository = new KorisnikRepository();
        public IEnumerable<ProizvodBo> GetAll()
        {
            List<ProizvodBo> proizvods = new List<ProizvodBo>();

            foreach (RegistrovanProizvod proizvod in soloEntities.RegistrovanProizvods.Where(t=>t.Procenat>0))
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
            IEnumerable<RegistrovanProizvod> proizvodi = soloEntities.RegistrovanProizvods.Where(t => t.Zanr == zanr && t.Procenat>0).ToList();
            foreach (RegistrovanProizvod proizvod in proizvodi)
            {
                proizvods.Add(Map(proizvod));
            }
            return proizvods;
        }

        public IEnumerable<ProizvodBo> GetProzivodByIme(string ime)
        {
            List<ProizvodBo> proizvods = new List<ProizvodBo>();
            IEnumerable<RegistrovanProizvod> proizvodi = soloEntities.RegistrovanProizvods.Where(p => p.Naziv.Contains(ime) && p.Procenat>0).ToList();
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

        public IEnumerable<ProizvodBo> GetRegisteredProizvodsByDeveloperId(int id)
        {
            List<ProizvodBo> proizvods = new List<ProizvodBo>();
            IEnumerable<RegistrovanProizvod> proizvodi = soloEntities.RegistrovanProizvods.Where(p => p.IdDevelopera == id && p.Procenat > 0).ToList();
            foreach (RegistrovanProizvod proizvod in proizvodi)
            {
                proizvods.Add(Map(proizvod));
            }
            return proizvods;
        }

        public void AddProizvod(ProizvodBo proizvod)
        {
            RegistrovanProizvod registrovanProizvod = new RegistrovanProizvod()
            {
                IdDevelopera = proizvod.IdDev,
                Naziv = proizvod.Naziv,
                Zanr = proizvod.Zanr,
                BrojIgraca = proizvod.BrojIgraca,
                PrepStarDoba = proizvod.PrepStarDoba,
                Cena = proizvod.Cena,
                Opis = proizvod.Opis,
                Procenat = 0
            };

            soloEntities.RegistrovanProizvods.Add(registrovanProizvod);
            soloEntities.SaveChanges();
        }

        public IEnumerable<ProizvodBo> GetNonegisteredProizvods(int id)
        {
            List<ProizvodBo> proizvods = new List<ProizvodBo>();
            IEnumerable<RegistrovanProizvod> proizvodi = soloEntities.RegistrovanProizvods.Where(p => p.IdDevelopera == id && p.Procenat == 0).ToList();
            foreach (RegistrovanProizvod proizvod in proizvodi)
            {
                proizvods.Add(Map(proizvod));
            }
            return proizvods;
        }

        public void Update(ProizvodBo proizvodBo)
        {
            RegistrovanProizvod proizvod = soloEntities.RegistrovanProizvods.Single(t => t.Id == proizvodBo.Id);

            proizvod.Naziv = proizvodBo.Naziv;
            proizvod.Opis = proizvodBo.Opis;
            proizvod.PrepStarDoba = proizvodBo.PrepStarDoba;
            proizvod.Zanr = proizvodBo.Zanr;
            proizvod.BrojIgraca = proizvodBo.BrojIgraca;

            soloEntities.SaveChanges();

        }

        public IEnumerable<ProizvodBo> GetAllNonregisteredProizvods()
        {
            List<ProizvodBo> proizvods = new List<ProizvodBo>();
            IEnumerable<RegistrovanProizvod> proizvodi = soloEntities.RegistrovanProizvods.Where(p=> p.Procenat == 0).ToList();
            foreach (RegistrovanProizvod proizvod in proizvodi)
            {
                proizvods.Add(Map(proizvod));
            }
            return proizvods;
        }

        public void RegisterProizvod(ProizvodBo proizvodBo)
        {
            RegistrovanProizvod proizvod = soloEntities.RegistrovanProizvods.Single(t => t.Id == proizvodBo.Id);
            proizvod.Procenat = proizvodBo.Procenat;
            soloEntities.SaveChanges();
        }


        public string BuyProduct(string idkupca, int idproizvoda)
        {
            ProizvodBo ZeljeniProzivod = GetProizvodById(idproizvoda);

            NalogBo TrenutniNalog = _LogRegRepository.GetNalogByName(idkupca);
            int StanjeKorisnika = Int32.Parse(TrenutniNalog.Racun);
            if (StanjeKorisnika > ZeljeniProzivod.Cena)
            {
                _korisnikRepository.SmanjiRacun(ZeljeniProzivod.Cena, TrenutniNalog.Id);
                return "Uspeh";
            }
            else
            {
                return "Neuspeh";
            }

        }



    }
}
