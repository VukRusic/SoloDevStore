﻿using Solo.Domain;
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
                korisnikModel.RacunID = "1234";
                soloEntities.Korisniks.Add(korisnikModel);
            }
            else if(nalog.Vrsta == "Developer")
            {
                Developer developerModel = new Developer();
                developerModel.Id = nalog.Id;
                developerModel.RacunID = "4321";
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

            return new NalogBo
            {
                Ime = user.Nalog.Ime,
                Id = user.Id,
                Prezime = user.Nalog.Prezime,
                JMBG = user.Nalog.JMBG,
                Racun = user.Nalog.Korisnik.Racun.Stanje

            };
        }

        public int GetIdByName(string username)
        {
            Nalog nalog = soloEntities.Nalogs.Where(t => t.User.Username == username).Single();
            return nalog.Id;
        }


    }
}
