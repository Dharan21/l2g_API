using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l2g.Entities.BusinessEntities
{
    public class EmploymentDropdowns
    {
        public List<EmploymentStatus> Statuses { get; set; }
        public List<Contract> Contracts { get; set; }
    }

    public class Contract
    {
        public int ContractId { get; set; }
        public string ContractType { get; set; }
    }
    public class EmploymentStatus
    {
        public int EmployeeStatusId { get; set; }
        public string EmployeeStatusType { get; set; }
    }
}
