﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l2g.Entities.BusinessEntities
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Username is required!")]
        [RegularExpression(@"^[a-zA-Z0-9]{3,20}$", ErrorMessage = "Username must be an alphanumeric string with 3-20 characters!")]
        public string Username { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required!")]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,16}$", ErrorMessage = "Password must contain 6-16 characters with uppercase letters, lowercase letters and at least one number!")]
        public string Password { get; set; }

    }
}
