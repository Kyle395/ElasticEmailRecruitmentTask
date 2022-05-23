using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ElasticRecruitmentTask
{
    public class MailValidation
    {
        public bool ValidateRecipientEmail(string [] recipients)
        {
            bool isEmailValid;
            MailAddress mail; 
            foreach(var recipient in recipients)
            {
                try
                {
                    mail = new MailAddress(recipient);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Incorect mail address: {0}",recipient);
                    return false;
                }
                isEmailValid = mail.Host.Contains(".");
                if (!isEmailValid)
                {
                    Console.WriteLine("Incorect mail address: {0}", mail);
                    return false;
                }
            }
            return true;
        }
        public bool ValidateMessageContent(string text, int maxSize)
        {
            if (!String.IsNullOrWhiteSpace(text) && text.Length < maxSize)
            {
                return true;
            }
            else return false;
        }
    }
}
