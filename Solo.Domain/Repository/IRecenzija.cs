using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solo.Domain.Repository
{
    public interface IRecenzija
    {
        IEnumerable<RecenzijaBo> GetRecenzijasByProizvodId(int id);
        void AddRecenzija(RecenzijaBo recenzija);
        bool IsMade(RecenzijaBo recenzija);
    }
}
