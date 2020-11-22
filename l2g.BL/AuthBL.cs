using l2g.BL.Interfaces;
using l2g.DL;
using l2g.DL.Interfaces;
using l2g.Entities.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace l2g.BL
{
    public class AuthBL:IDisposable
    {
        AuthDL _authDL = new AuthDL();

        public UserVM ValidateUser(string username, string password)
        {
            return _authDL.ValidateUser(username, password);
        }

        public ErrorResponseVM CheckUsernameOrEmailExists(UserVM userVM)
        {
            ErrorResponseVM errorRes = new ErrorResponseVM();
            bool isUsernameExists = _authDL.CheckUsernameExists(userVM.Username);
            if (isUsernameExists)
            {
                Error error = new Error()
                {
                    ErrorMessage = "Username Exists!",
                    Property = "Username",
                };
                errorRes.Errors.Add(error);
            }
            bool isEmailExists = _authDL.CheckEmailExists(userVM.Email);
            if (isEmailExists)
            {
                Error error = new Error()
                {
                    ErrorMessage = "Email Exists!",
                    Property = "Email"
                };
                errorRes.Errors.Add(error);
            }
            return errorRes;
        }
        public bool CheckEmailExists(string email)
        {
            return _authDL.CheckEmailExists(email);
        }

        public bool Register(UserVM userVM)
        {
            return _authDL.RegisterUser(userVM);
        }

        public async Task<bool> SendEmail(string email)
        {
            //send password in the mail
            var message = new MailMessage();
            message.To.Add(email);
            message.From = new MailAddress("Bhavya Shah <bhavya0598@gmail.com>");
            message.Subject = "Check Your Password Here";
            message.Body = "Your Password: " + _authDL.GetPassword(email);
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
                catch (Exception)
                {
                    return false;
                }
            }
            return true;
        }
        public void Dispose()
        {
            _authDL.Dispose();
        }
    }
}
