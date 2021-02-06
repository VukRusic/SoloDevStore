using Solo.Domain;
using Solo.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solo.EntityFramework
{
    public class LogRegRepository : ILogRegRepository
    {
        private SoloEntities soloEntities = new SoloEntities();
        public void AddUser(NalogBo nalog)
        { 
            User userModel = new User();
            userModel.Id = nalog.Id;
            userModel.Username = nalog.Username;
            userModel.Password = nalog.Password;
            userModel.Vrsta = nalog.Vrsta;

            soloEntities.Users.Add(userModel);

            Nalog nalogModel = new Nalog();
            nalogModel.Id = nalog.Id;
            nalogModel.Ime = nalog.Ime;
            nalogModel.Prezime = nalog.Prezime;
            nalogModel.JMBG = nalog.JMBG;

            soloEntities.Nalogs.Add(nalogModel);

            if(nalog.Vrsta == "Korisnik")
            {
                Korisnik korisnikModel = new Korisnik();
                korisnikModel.Id = nalog.Id;
                korisnikModel.RacunID = "1234"; // ovde bi posle nove registracije trebalo da bude RacunID
                //ovde bi o
                //korisnikModel.Racun.Stanje=8500 npr
                soloEntities.Korisniks.Add(korisnikModel);
            }
            else if(nalog.Vrsta == "Developer")
            {
                Developer developerModel = new Developer();
                developerModel.Id = nalog.Id;
                developerModel.RacunID = "4321"; // ovde bi posle nove registracije trebalo da bude RacunID
               //korisnikModel.Racun.Stanje=8500 npr
                soloEntities.Developers.Add(developerModel);
            }
            soloEntities.SaveChanges();
        }

        public List<string> GetRoleForUser(string username)
        {
            return soloEntities.Users.Where(t => t.Username == username).Select(k => k.Vrsta).ToList();
        }

        public UserBo GetUserByName(string username)
        {
            User user = soloEntities.Users.Single(t => t.Username == username);

            return new UserBo
            {
                Username = user.Username,
                Id = user.Id,
                Password = user.Password,
                Role = user.Vrsta
            };
        }

        public bool isFree(NalogBo nalog)
        {
            return !soloEntities.Users.Any(t => t.Username == nalog.Username);
        }

        public bool isValid(UserBo userBo)
        {
            return soloEntities.Users.Any(t => t.Username == userBo.Username && t.Password == userBo.Password);
        }


        public NalogBo GetNalogByName(string id)
        {

            User user = soloEntities.Users.Where(t => t.Username == id).Single();
            Nalog nalog = soloEntities.Nalogs.Where(t => t.Id == user.Id).Single();
            Korisnik korisnik = soloEntities.Korisniks.Where(t => t.Id == nalog.Id).Single();


            return new NalogBo
            {
                Ime = nalog.Ime,
                Id = nalog.Id,
                Prezime = nalog.Prezime,
                JMBG = nalog.JMBG,
                Racun = korisnik.Racun.Stanje

            };
        }


    }
}
