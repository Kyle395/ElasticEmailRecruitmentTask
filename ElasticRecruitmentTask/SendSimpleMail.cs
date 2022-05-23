using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using ElasticEmail.Api;
using ElasticEmail.Client;
using ElasticEmail.Model;

namespace ElasticRecruitmentTask
{
    public class SendSimpleMail : ConnectionConfig
    {
        public EmailContent SetSender(string senderName, EmailContent emailContent)
        {
            string sender = "<wojciech.lukasz99@gmail.com>";
            MailValidation mailValidation = new MailValidation();
            if (mailValidation.ValidateMessageContent(senderName, 64))
            {
                sender = sender.Insert(0, senderName);
                emailContent.From = sender;
            }
            else emailContent.From = sender;
            return emailContent;
        }
        public EmailContent SetSubject(string subject, EmailContent emailContent)
        {
            MailValidation mailValidation = new MailValidation();
            if (mailValidation.ValidateMessageContent(subject, 64))
            {
                emailContent.Subject = subject;
            }
            return emailContent;
        }
        public BodyContentType SetBodyType(string message)
        {
            if (message != HttpUtility.HtmlEncode(message))
            {
                return BodyContentType.HTML;
            }
            else
            { 
                return BodyContentType.PlainText; 
            }
        }
        public BodyPart SetBody(string message)
        {
            BodyPart bodyPart = new BodyPart();
            MailValidation mailValidation = new MailValidation();
            if(mailValidation.ValidateMessageContent(message, 256)){
                bodyPart.ContentType = SetBodyType(message);
                bodyPart.Content = message;
            }
            return bodyPart;
        }
        public EmailContent SetBodyParts(string message, EmailContent emailContent)
        {
            List<BodyPart> bodyParts = new List<BodyPart>();
            bodyParts.Add(SetBody(message));
            emailContent.Body = bodyParts;
            return emailContent;
        }
        public List<EmailRecipient> SetEmailRecipients (string[] recipients)
        {
            List<EmailRecipient> emailRecipients = new List<EmailRecipient>();

            foreach (var recipient in recipients)
            {
                EmailRecipient emailRecipient = new EmailRecipient(recipient);
                emailRecipients.Add(emailRecipient);
            }
            return emailRecipients;
        }
        public EmailMessageData SetMessageData(List<EmailRecipient> emailRecipients, EmailContent emailContent)
        {
            EmailMessageData emailMessageData = new EmailMessageData(emailRecipients, emailContent);
            return emailMessageData;

        }
        public EmailSend postEmail(string[] recipients, EmailContent emailContent)
        { 
            ConnectionConfig connectionConfig = new ConnectionConfig();
            List<EmailRecipient> emailRecipients = SetEmailRecipients(recipients);
            EmailMessageData emailMessageData = SetMessageData(emailRecipients, emailContent);
            var result= connectionConfig.config().EmailsPost(emailMessageData);
            return result;
        }

    }

}
