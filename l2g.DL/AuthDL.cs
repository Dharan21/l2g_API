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
            l2g_tbl_User user = db.l2g_tbl_User.FirstOrDefault(u =>
            u.Username.Equals(username, StringComparison.OrdinalIgnoreCase)
            && u.Password == password);
            if(user == null)
            {
                return null;
            }
            return MappingConfig.UserToBusinessEntity(user);
        }

        public bool CheckEmailExists(string email)
        {
            return db.l2g_tbl_User.Any(user => user.Email == email);
        }

        public bool CheckUsernameExists(string username)
        {
            return db.l2g_tbl_User.Any(user => user.Username == username); 
        }

        public bool RegisterUser(UserVM userVM)
        {
            l2g_tbl_User user = MappingConfig.UserToDataEntity(userVM);
            user.CreatedDate = DateTime.Now;
            try
            {
                db.l2g_tbl_User.Add(user);
                db.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public string GetPassword(string email)
        {
            return db.l2g_tbl_User.Where(s => s.Email == email).FirstOrDefault().Password;
        }

        public string GetUsername(string email)
        {
            return db.l2g_tbl_User.Where(s => s.Email == email).FirstOrDefault().Username;
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
