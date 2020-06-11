using l2g.BL.Interfaces;
using l2g.DL;
using l2g.DL.Interfaces;
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
    public class UserBL: IUserBL
    {
        private IUserDL _userDL;
        public UserBL(IUserDL userDL) 
        {
            _userDL = userDL;
        }

        public bool AddBankDetails(GetUserBankDetails userVM)
        {
            string username = HttpContext.Current.User.Identity.Name;
            userVM.UserId = _userDL.GetUserId(username);
            return _userDL.AddBankDeatils(userVM);
        }

        public UserBankDetailsVM GetBankDetails()
        {
            string username = HttpContext.Current.User.Identity.Name;
            int userId = _userDL.GetUserId(username);
            return _userDL.GetBankDetails(userId);
        }

        public UserDetailsFullVM GetAllDetails()
        {
            UserDetailsFullVM user = new UserDetailsFullVM();
            string username = HttpContext.Current.User.Identity.Name;
            int userId = _userDL.GetUserId(username);
            user.PersonalDetails = _userDL.GetUserDetails(userId);
            user.EmploymentDetails = _userDL.GetUserEmploymentDetails(userId);
            user.BankDetails = _userDL.GetUserBankDetails(userId);
            return user;
        }

        public bool AddOrUpdateUserEmploymentDetails(GetUserEmploymentDetails userVM) 
        {
            string username = HttpContext.Current.User.Identity.Name;
            userVM.UserId = _userDL.GetUserId(username);
            UserEmploymentDetailsVM user = _userDL.GetUserEmploymentDetails(userVM.UserId);
            if (user.UserId > 0)
            {
                return _userDL.UpdateUserEmploymentDetails(userVM);
            }
            return _userDL.AddUserEmployementDetails(userVM);
        }

        public ErrorResponseVM CheckAccountNoExists(GetUserBankDetails userVM)
        {
            bool isExists = _userDL.CheckAccountNoExists(userVM.AccountNo);
            ErrorResponseVM error = new ErrorResponseVM();
            if (isExists)
            {
                Error err = new Error()
                {
                    ErrorMessage = "Account No Already Exists!",
                    Property = "AccountNo"
                };
                error.Errors.Add(err);
            }
            return error;
        }

        public ErrorResponseVM CheckAccountNoExistsONUpdate(GetUserBankDetails userVM)
        {
            string username = HttpContext.Current.User.Identity.Name;
            int userId = _userDL.GetUserId(username);
            bool isExists = _userDL.CheckAccountNoExists(userId, userVM.AccountNo);
            ErrorResponseVM error = new ErrorResponseVM();
            if (isExists)
            {
                Error err = new Error()
                {
                    ErrorMessage = "Account No Already Exists!",
                    Property = "AccountNo"
                };
                error.Errors.Add(err);
            }
            return error;
        }

        public bool UpdateBankDetails(GetUserBankDetails userVM)
        {
            string username = HttpContext.Current.User.Identity.Name;
            userVM.UserId = _userDL.GetUserId(username);
            return _userDL.UpdateUserBankDetails(userVM);
        }

        public bool CheckBankDetailsExists()
        {
            string username = HttpContext.Current.User.Identity.Name;
            int userId = _userDL.GetUserId(username);
            UserBankDetailsVM user = _userDL.GetUserBankDetails(userId);
            return user.UserId > 0;
        }

        //public bool AddOrUpdateUserBankDetails(GetUserBankDetails userVM)
        //{
        //    string username = HttpContext.Current.User.Identity.Name;
        //    userVM.UserId = userDL.GetUserId(username);
        //    UserBankDetailsVM user = userDL.GetUserBankDetails(userVM.UserId);
        //    if (user.UserId > 0)
        //    {
        //        return userDL.UpdateUserBankDetails(userVM);
        //    }
        //    return userDL.AddUserBankDetails(userVM);
        //}

        public UserEmploymentDetailsVM GetUserEmploymentDetails()
        {
            string username = HttpContext.Current.User.Identity.Name;
            int userId = _userDL.GetUserId(username);
            return _userDL.GetUserEmploymentDetails(userId);
        }
        public bool AddOrUpdateUserDetails(UserDetailsVM userVM)
        {
            string username = HttpContext.Current.User.Identity.Name;
            userVM.UserId = _userDL.GetUserId(username);
            UserDetailsVM userDetailsVM = _userDL.GetUserDetails(userVM.UserId);
            if (userDetailsVM.UserId > 0)
            {
                return _userDL.UpdateUserDetail(userVM);
            }
            return _userDL.AddUserDetails(userVM);
        }
        public UserDetailsVM GetUserDetails()
        {
            string username = HttpContext.Current.User.Identity.Name;
            int userId = _userDL.GetUserId(username);
            return _userDL.GetUserDetails(userId);
        }

        public EmploymentDropdowns getEmploymenttDropdown()
        {
            List<EmploymentStatus> statuses = _userDL.GetAllEmployeeStatues();
            List<Contract> contracts = _userDL.GetAllContracts();
            return new EmploymentDropdowns() { Statuses = statuses, Contracts = contracts };
        }
    }
}
