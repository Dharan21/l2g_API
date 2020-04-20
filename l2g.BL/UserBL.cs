using l2g.DL;
using l2g.Entities.BusinessEntities;
using l2g.Entities.DataEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace l2g.BL
{
    public class UserBL: IDisposable
    {
        UserDL userDL = new UserDL();

        public void Dispose()
        {
            userDL.Dispose();
        }

        public bool AddBankDetails(UserBankDetailsVM userVM)
        {
            string username = HttpContext.Current.User.Identity.Name;
            userVM.UserId = userDL.GetUserId(username);
            return userDL.AddBankDeatils(userVM);
        }

        public UserBankDetailsVM GetBankDetails()
        {
            string username = HttpContext.Current.User.Identity.Name;
            int userId = userDL.GetUserId(username);
            return userDL.GetBankDetails(userId);
        }
    }
}
