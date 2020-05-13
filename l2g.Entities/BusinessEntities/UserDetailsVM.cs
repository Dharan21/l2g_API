using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l2g.Entities.BusinessEntities
{
    public class UserDetailsVM
    {
        [Key]
        public int UserId { get; set; }
        
        [Required(ErrorMessage ="Required")]
        [MinLength(3, ErrorMessage ="Length must be 3-15")]
        [MaxLength(15, ErrorMessage ="Length must be 3-15")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Required")]
        [MinLength(3, ErrorMessage = "Length must be 3-15")]
        [MaxLength(15, ErrorMessage = "Length must be 3-15")]
        public string Lastname { get; set; }
        
        [Required(ErrorMessage = "Required")]
        public System.DateTime DOB { get; set; }

        [Required(ErrorMessage = "Required")]
        [RegularExpression(@"^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\s\./0-9]*$", ErrorMessage = "Must be a number")]
        public string Contact { get; set; }

        [Required(ErrorMessage = "Required")]
        [MinLength(1, ErrorMessage = "Length must be 1-15")]
        [MaxLength(15, ErrorMessage = "Length must be 1-15")] 
        public int HouseNo { get; set; }

        [Required(ErrorMessage = "Required")]
        [MinLength(2, ErrorMessage = "Length must be 2-15")]
        [MaxLength(15, ErrorMessage = "Length must be 3-15")] 
        public string Street { get; set; }

        [Required(ErrorMessage = "Required")]
        [MinLength(6, ErrorMessage = "Length must be 6-8")]
        [MaxLength(8, ErrorMessage = "Length must be 6-8")]
        public string PIN { get; set; }

        [Required(ErrorMessage = "Required")]
        [MinLength(3, ErrorMessage = "Length must be 3-25")]
        [MaxLength(25, ErrorMessage = "Length must be 3-25")]
        public string Town { get; set; }
    }
}
