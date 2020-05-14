using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l2g.Entities.BusinessEntities
{
    public class UserDetailsFullVM
    {
        public UserDetailsVM PersonalDetails { get; set; }
        public UserEmploymentDetailsVM EmploymentDetails { get; set; }
        public UserBankDetailsVM BankDetails { get; set; }
    }
}
