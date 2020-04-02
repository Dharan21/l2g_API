using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l2g.Entities.BusinessEntities
{
    public class UserEmploymentDetailsVM
    {
        public int UserId { get; set; }
        public string Company { get; set; }
        public int Salary { get; set; }
        public int CreditScore { get; set; }
        public Nullable<int> EmployeeStatusId { get; set; }
        public string EmployeeStatusType { get; set; }
        public Nullable<int> ContractId { get; set; }
        public string ContractType { get; set; }
    }
}
