using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solo.Domain.Repository
{
    public interface IProizvod
    {
        IEnumerable<ProizvodBo> GetAll();
        ProizvodBo GetProizvodById(int id);
        

    }
}
