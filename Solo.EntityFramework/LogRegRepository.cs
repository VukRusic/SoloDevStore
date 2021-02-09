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

            Racun racunModel = new Racun();
            racunModel.Id = nalog.RacunID;
            racunModel.Stanje = "8500";

            soloEntities.Racuns.Add(racunModel);

            if(nalog.Vrsta == "Korisnik")
            {
                Korisnik korisnikModel = new Korisnik();
                korisnikModel.Id = nalog.Id;
                korisnikModel.RacunID = nalog.RacunID;
                soloEntities.Korisniks.Add(korisnikModel);
            }
            else if(nalog.Vrsta == "Developer")
            {
                Developer developerModel = new Developer();
                developerModel.Id = nalog.Id;
                developerModel.RacunID = nalog.RacunID;
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


        public NalogBo GetNalogByName(string username)
        {
            User user = soloEntities.Users.Where(t => t.Username == username).Single();

            if (user.Vrsta == "Korisnik")
            {
                return new NalogBo
                {
                    Ime = user.Nalog.Ime,
                    Id = user.Id,
                    Prezime = user.Nalog.Prezime,
                    JMBG = user.Nalog.JMBG,
                    Stanje = user.Nalog.Korisnik.Racun.Stanje,
                    Username = user.Username,
                    Password = user.Password
                };
            }
            else
            {
                return new NalogBo
                {
                    Ime = user.Nalog.Ime,
                    Id = user.Id,
                    Prezime = user.Nalog.Prezime,
                    JMBG = user.Nalog.JMBG,
                    Stanje = user.Nalog.Developer.Racun.Stanje,
                    Username = user.Username,
                    Password = user.Password
                };
            }
        }

        public int GetIdByName(string username)
        {
            Nalog nalog = soloEntities.Nalogs.Where(t => t.User.Username == username).Single();
            return nalog.Id;
        }

        public void Update(NalogBo nalog)
        {
            User user = soloEntities.Users.Where(u => u.Id == nalog.Id).Single();

            user.Username = nalog.Username;
            user.Password = nalog.Password;
            
            soloEntities.SaveChanges();
        }
    }
}
