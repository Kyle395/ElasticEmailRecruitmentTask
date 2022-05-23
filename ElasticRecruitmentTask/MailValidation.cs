using System;
using System.Net.Mail;

namespace ElasticRecruitmentTask
{
    public class MailValidation
    {
        public bool ValidateRecipientEmail(string [] recipients)
        {
            MailAddress mail; 
            foreach(var recipient in recipients)
            {
                try
                {
                    mail = new MailAddress(recipient);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Incorect mail address: {0}", recipient);
                    return false;
                }
                if (!mail.Host.Contains("."))
                {
                    Console.WriteLine("Incorect mail address: {0}", mail);
                    return false;
                }
            }
            return true;
        }
        public bool ValidateMessageContent(string text, int maxSize)
        {
            return !String.IsNullOrWhiteSpace(text) && text.Length < maxSize;
        }
    }
}
