using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l2g.Entities.BusinessEntities
{
    public class UserBankDetailsVM
    {
        public int UserId { get; set; }
        
        public string AccountNo { get; set; }

        public string AccountHolderName { get; set; }

        public string AccountType { get; set; }
    }
}
