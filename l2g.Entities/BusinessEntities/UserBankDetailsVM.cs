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
        [Key]
        public int UserId { get; set; }
        
        [Required(ErrorMessage = "AccountNo is required!")]
        [RegularExpression("[0-9]{9,18}", ErrorMessage = "Invalid Account No.")]
        public string AccountNo { get; set; }

        [Required(ErrorMessage = "Account Holder's Name is required!")]
        [RegularExpression(@"[\w ]{6,18}", ErrorMessage = "Invalid Account Holder's Name")]
        public string AccountHolderName { get; set; }

        [Required(ErrorMessage = "Account Type is required!")]
        [RegularExpression(@"[\w ]{3,16}", ErrorMessage = "Invalid Account Type!")]
        public string AccountType { get; set; }
    }
}
