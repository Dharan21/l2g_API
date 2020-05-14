using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l2g.Entities.BusinessEntities
{
    public class GetQuoteDetails
    {
        //userPersonalDetails
        [Required(ErrorMessage = "Required")]
        [MinLength(3, ErrorMessage = "Length must be 3-15")]
        [MaxLength(15, ErrorMessage = "Length must be 3-15")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Required")]
        [MinLength(3, ErrorMessage = "Length must be 3-15")]
        [MaxLength(15, ErrorMessage = "Length must be 3-15")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "Required")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0: dd/MM/yyyy}")]
        public System.DateTime DOB { get; set; }

        [Required(ErrorMessage = "Required")]
        [RegularExpression(@"^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\s\./0-9]*$", ErrorMessage = "Enter valid contact no")]
        public string Contact { get; set; }

        [Required(ErrorMessage = "Required")]
        public int HouseNo { get; set; }

        [Required(ErrorMessage = "Required")]
        [MinLength(3, ErrorMessage = "Length must be 3-20")]
        [MaxLength(20, ErrorMessage = "Length must be 3-20")]
        public string Street { get; set; }

        [Required(ErrorMessage = "Required")]
        [MinLength(5, ErrorMessage = "Length must be 5-8")]
        [MaxLength(8, ErrorMessage = "Length must be 5-8")]
        public string PIN { get; set; }

        [Required(ErrorMessage = "Required")]
        [MinLength(3, ErrorMessage = "Length must be 3-30")]
        [MaxLength(30, ErrorMessage = "Length must be 3-30")]
        public string Town { get; set; }

        //userEmploymentDetails
        [Required(ErrorMessage = "Required!")]
        [MaxLength(100, ErrorMessage = "Length must be less than 100")]
        public string Company { get; set; }

        [Required(ErrorMessage = "Required!")]
        [Range(1, int.MaxValue, ErrorMessage = "Enter valid Salary")]
        public int Salary { get; set; }

        [Required(ErrorMessage = "Required!")]
        [Range(1, int.MaxValue, ErrorMessage = "Enter valid Credit Score")]
        public int CreditScore { get; set; }

        [Required(ErrorMessage = "Required!")]
        [Range(1, int.MaxValue, ErrorMessage = "Chooes Employee Status from given list")]
        public int EmployeeStatusId { get; set; }

        [Required(ErrorMessage = "Required!")]
        [Range(1, int.MaxValue, ErrorMessage = "Chooes Employee Status from given list")]
        public int ContractId { get; set; }

        //userBankDetails
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
