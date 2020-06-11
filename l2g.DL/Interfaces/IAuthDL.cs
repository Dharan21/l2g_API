using l2g.Entities.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l2g.DL.Interfaces
{
    public interface IAuthDL
    {
        UserVM ValidateUser(string username, string password);
        bool CheckEmailExists(string email);
        bool CheckUsernameExists(string username);
        bool RegisterUser(UserVM userVM);
        string GetPassword(string email);
    }
}
