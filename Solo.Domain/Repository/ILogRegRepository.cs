using System;
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
        void AddUser(UserBo userBo);

    }
}
