using l2g.DL;
using l2g.Entities.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
        public async Task SendEmail(string email)
        {
            AuthDL authDL = new AuthDL();
            var users = authDL.GetUser();

            if (users.Where(s => s.Email == email).Any())
            {
                //send password in the mail
                var message = new MailMessage();
                message.To.Add(email);
                message.From = new MailAddress("Bhavya Shah <bhavya0598@gmail.com>");
                message.Subject = "Email Verification";
                message.Body = "Your Password: " + users.Where(s => s.Email == email).First().Password;
                message.IsBodyHtml = true;
                using (var smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential("bhavya0598@gmail.com", "lead2ordergenerate");
                    smtp.EnableSsl = true;
                    try
                    {
                        await smtp.SendMailAsync(message);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                }
            }
        }
    }
}
