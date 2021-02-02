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
            soloEntities.SaveChanges();

            Nalog nalogModel = new Nalog();
            nalogModel.Id = nalog.Id;
            nalogModel.Ime = nalog.Ime;
            nalogModel.Prezime = nalog.Prezime;
            nalogModel.JMBG = nalog.JMBG;

            soloEntities.Nalogs.Add(nalogModel);
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

        public bool isValid(UserBo userBo)
        {
            return soloEntities.Users.Any(t => t.Username == userBo.Username && t.Password == userBo.Password);
        }
    }
}
