using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l2g.Entities.BusinessEntities
{
    public class UserEmploymentDetailsVM
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Required")]
        [MinLength(3, ErrorMessage ="Length must be 3-15")]
        [MaxLength(15 ,ErrorMessage = "Length must be 3-15")]
        public string Company { get; set; }

        [Required(ErrorMessage = "Required")]
        public int Salary { get; set; }

        [Required(ErrorMessage = "Required")]
        [Range(1,850, ErrorMessage ="Credit score must be in 1-850")]
        public int CreditScore { get; set; }

        //[Required(ErrorMessage = "Required")]
        public Nullable<int> EmployeeStatusId { get; set; }

        [Required(ErrorMessage = "Required")]
        public string EmployeeStatusType { get; set; }

        //[Required(ErrorMessage = "Required")]
        public Nullable<int> ContractId { get; set; }

        [Required(ErrorMessage = "Required")]
        public string ContractType { get; set; }
    }
}
