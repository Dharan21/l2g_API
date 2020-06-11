using l2g.Entities.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l2g.DL.Interfaces
{
    public interface IUserDL
    {
        int GetUserId(string username);
        bool AddBankDeatils(GetUserBankDetails userVM);
        UserBankDetailsVM GetBankDetails(int userId);
        bool UpdateUserEmploymentDetails(GetUserEmploymentDetails userVM);
        bool CheckAccountNoExists(int userId, string accountNo);
        bool CheckAccountNoExists(string accountNo);
        bool AddUserBankDetails(GetUserBankDetails userVM);
        bool UpdateUserBankDetails(GetUserBankDetails userVM);
        UserBankDetailsVM GetUserBankDetails(int userId);
        int? GetContractId(string contractType);
        int GetEmployeeStatusId(string employeeStatusType);
        bool AddUserEmployementDetails(GetUserEmploymentDetails userVM);
        UserEmploymentDetailsVM GetUserEmploymentDetails(int userId);
        List<Contract> GetAllContracts();
        List<EmploymentStatus> GetAllEmployeeStatues();
        bool AddUserDetails(UserDetailsVM userVM);
        bool UpdateUserDetail(UserDetailsVM userVM);
        UserDetailsVM GetUserDetails(int userId);

    }
}
