using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solo.Domain.Repository
{
    public interface IRadnikRepository
    {
        int GetDugovanjaByDeveloper(string username);
        IEnumerable<string> GetAllDevelopers();
        void PayDeveloper(string username);
    }
}
