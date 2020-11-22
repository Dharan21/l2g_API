using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l2g.Entities.BusinessEntities
{
    public class GetUserEmploymentDetails
    {
        public int UserId { get; set; }
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
    }
}
