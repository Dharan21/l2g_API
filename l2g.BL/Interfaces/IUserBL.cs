using l2g.Entities.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l2g.BL.Interfaces
{
    public interface IUserBL
    {
        bool AddBankDetails(GetUserBankDetails userVM);
        UserBankDetailsVM GetBankDetails();
        UserDetailsFullVM GetAllDetails();
        bool AddOrUpdateUserEmploymentDetails(GetUserEmploymentDetails userVM);
        ErrorResponseVM CheckAccountNoExists(GetUserBankDetails userVM);
        ErrorResponseVM CheckAccountNoExistsONUpdate(GetUserBankDetails userVM);
        bool UpdateBankDetails(GetUserBankDetails userVM);
        bool CheckBankDetailsExists();
        UserEmploymentDetailsVM GetUserEmploymentDetails();
        bool AddOrUpdateUserDetails(UserDetailsVM userVM);
        UserDetailsVM GetUserDetails();
        EmploymentDropdowns getEmploymenttDropdown();
    }
}
