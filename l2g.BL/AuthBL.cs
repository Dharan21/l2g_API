using l2g.DL;
using l2g.Entities.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l2g.BL
{
    public class AuthBL
    {
        public UserVM ValidateUser(string username, string password)
        {
            AuthDL authDL = new AuthDL();
            return authDL.ValidateUser(username, password);
        }

        public ErrorResponseVM Register(UserVM userVM)
        {
            AuthDL authDL = new AuthDL();
            ErrorResponseVM errorRes = new ErrorResponseVM();

            if (String.IsNullOrEmpty(userVM.Username))
            {
                Error error = new Error()
                {
                    message = "Username is Required!",
                    property = "Username"
                };
                errorRes.isValid = false;
                errorRes.errors.Add(error);
            }
            else
            {
                bool isUsernameExists = authDL.CheckUsernameExists(userVM.Username);
                if (isUsernameExists)
                {
                    Error error = new Error()
                    { 
                        message = "Username Exists",
                        property = "Username",
                    };
                    errorRes.isValid = false;
                    errorRes.errors.Add(error);
                }
            }
            if (String.IsNullOrEmpty(userVM.Email))
            {
                Error error = new Error()
                {
                    message = "Email is Required!",
                    property = "Email"
                };
                errorRes.isValid = false;
                errorRes.errors.Add(error);
            }
            else
            {
                bool isEmailExists = authDL.CheckEmailExists(userVM.Email);
                if (isEmailExists)
                {
                    Error error = new Error()
                    {
                        message = "Email Exists!",
                        property = "Email"
                    };
                    errorRes.isValid = false;
                    errorRes.errors.Add(error);
                }
            }
            if (String.IsNullOrEmpty(userVM.Password)) {
                Error error = new Error()
                {
                    message = "Password is Required!",
                    property = "Password"
                };
                errorRes.isValid = false;
                errorRes.errors.Add(error);
            }
            if(errorRes.errors.Count == 0)
            {
                bool isRegistred = authDL.RegisterUser(userVM);
                if(!isRegistred)
                {
                    errorRes.isInternalServerError = true;
                }
                else
                {
                    errorRes.isSuccess = true;
                }
            }
            return errorRes;
        }
    }
}
