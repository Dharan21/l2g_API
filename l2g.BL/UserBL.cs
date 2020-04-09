using l2g.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Net;

namespace l2g.BL
{
    public class UserBL
    {
        public async Task SendEmail(string email) 
        {
            UserDL userDL = new UserDL();
            var users = userDL.GetUser();

            if (users.Where(s=>s.Email==email).Any())
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
