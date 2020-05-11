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
        public bool AddUserEmploymentDetails(UserEmploymentDetailsVM userVM) 
        {
            string username = HttpContext.Current.User.Identity.Name;
            userVM.UserId = userDL.GetUserId(username);
            userVM.EmployeeStatusId = userDL.GetEmployeeStatusId(userVM.EmployeeStatusType);
            userVM.ContractId = userDL.GetContractId(userVM.ContractType);
            return userDL.AddUserEmployementDetails(userVM);
        }
        public UserEmploymentDetailsVM GetUserEmploymentDetails()
        {
            string username = HttpContext.Current.User.Identity.Name;
            int userId = userDL.GetUserId(username);
            return userDL.GetUserEmploymentDetails(userId);
        }
        public bool AddUserDetails(UserDetailsVM userVM)
        {
            string username = HttpContext.Current.User.Identity.Name;
            userVM.UserId = userDL.GetUserId(username);
            return userDL.AddUserDetails(userVM);
        }
        public UserDetailsVM GetUserDetails()
        {
            string username = HttpContext.Current.User.Identity.Name;
            int userId = userDL.GetUserId(username);
            return userDL.GetUserDetails(userId);
        }

        public void Dispose()
        {
            userDL.Dispose();
        }
    }
}
