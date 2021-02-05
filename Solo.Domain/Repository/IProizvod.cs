﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solo.Domain.Repository
{
    public interface IProizvod
    {
        IEnumerable<ProizvodBo> GetAll();
        IEnumerable<ProizvodBo> GetAllNonregisteredProizvods();
        ProizvodBo GetProizvodById(int id);
        IEnumerable<ProizvodBo> GetProizvodByZanr(string zanr);
        IEnumerable<ProizvodBo> GetProzivodByIme(string ime);
        string GetDeveloperByProizvodId(int id);
        IEnumerable<ProizvodBo> GetRegisteredProizvodsByDeveloperId(int id);
        void AddProizvod(ProizvodBo proizvod);
        IEnumerable<ProizvodBo> GetNonegisteredProizvods(int id);
        void Update(ProizvodBo proizvodBo);
        void RegisterProizvod(ProizvodBo proizvodBo);

        string BuyProduct(string idkupca, int idproizvoda);

    }
}
