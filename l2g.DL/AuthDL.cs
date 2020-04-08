using l2g.DL.Mapping;
using l2g.Entities.BusinessEntities;
using l2g.Entities.DataEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l2g.DL
{
    public class AuthDL : IDisposable
    {
        Lead2OrderGenerateDbEntities db = new Lead2OrderGenerateDbEntities();
        public UserVM ValidateUser(string username, string password)
        {
            return MappingConfig.UserToBusinessEntity(db.l2g_tbl_User.FirstOrDefault(user =>
            user.Username.Equals(username, StringComparison.OrdinalIgnoreCase)
            && user.Password == password));
        }
        public void Dispose()
        {
            db.Dispose();
        }

    }
}
