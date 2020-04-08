using l2g.DL;
using l2g.Entities.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l2g.BL
{
    public class AuthBL
    {
        public UserVM ValidateUser(string username, string password)
        {
            AuthDL authDL = new AuthDL();
            return authDL.ValidateUser(username, password);
        } 
    }
}
