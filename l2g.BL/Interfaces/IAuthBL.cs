using l2g.Entities.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l2g.BL.Interfaces
{
    public interface IAuthBL
    {
         UserVM ValidateUser(string username, string password);
         ErrorResponseVM CheckUsernameOrEmailExists(UserVM userVM);
         bool CheckEmailExists(string email);
         bool Register(UserVM userVM);
         Task<bool> SendEmail(string email);
    }
}
