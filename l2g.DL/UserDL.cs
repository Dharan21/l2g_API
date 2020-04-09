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
    public class UserDL
    {
        public List<UserVM> GetUser() 
        {
            using (var db = new Lead2OrderGenerateDbEntities())
            {
                List<l2g_tbl_User> users = db.l2g_tbl_User.ToList();
                List<UserVM> userVMs = new List<UserVM>();
                foreach (var user in users) {
                    userVMs.Add(MappingConfig.UserToBusinessEntity(user));
                }
                return userVMs; //returns all users in the user table
            }
        }
    }
}
