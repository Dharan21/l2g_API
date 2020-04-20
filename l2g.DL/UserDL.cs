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
    public class UserDL: IDisposable
    {
        Lead2OrderGenerateDbEntities db = new Lead2OrderGenerateDbEntities();

        public int GetUserId(string username)
        {
            int id = db.l2g_tbl_User.Where(x => x.Username == username).Select(x => x.UserId).First();
            return id;
        }

        public bool AddBankDeatils(UserBankDetailsVM userVM)
        {
            l2g_tbl_UserBankDetails user = MappingConfig.UserBankDetailsToDataEntity(userVM);
            user.CreatedDate = DateTime.Now;
            try
            {
                db.l2g_tbl_UserBankDetails.Add(user);
                db.SaveChanges();
            }
            catch(Exception)
            {
                return false;
            }
            return true;
        }

        public UserBankDetailsVM GetBankDetails(int userId)
        {
            l2g_tbl_UserBankDetails user = db.l2g_tbl_UserBankDetails.Where(x => x.UserId == userId).First();
            if(user != null)
            {
                return MappingConfig.UserBankDetailsToBusinessEntity(user);
            }
            return new UserBankDetailsVM();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
