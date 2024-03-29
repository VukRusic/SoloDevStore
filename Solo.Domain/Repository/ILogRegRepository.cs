﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solo.Domain.Repository
{
    public interface ILogRegRepository
    {
        bool isValid(UserBo userBo);
        UserBo GetUserByName(string username);
        List<string> GetRoleForUser(string username);
        void AddUser(NalogBo nalog);
        bool isFree(NalogBo nalog);
        NalogBo GetNalogByName(string username);
        int GetIdByName(string username);

        void Update(NalogBo nalog);

    }
}
