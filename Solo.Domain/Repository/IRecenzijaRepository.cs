using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solo.Domain.Repository
{
    public interface IRecenzijaRepository
    {
        IEnumerable<RecenzijaBo> GetRecenzijasByProizvodId(int id);
        string GetAvgRecenzijaByProizvodId(int id);
        void AddRecenzija(RecenzijaBo recenzija);
        bool IsMade(RecenzijaBo recenzija);
    }
}
