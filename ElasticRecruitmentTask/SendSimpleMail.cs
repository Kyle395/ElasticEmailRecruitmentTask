using System.Collections.Generic;
using System.Web;
using ElasticEmail.Model;

namespace ElasticRecruitmentTask
{
    public class SendSimpleMail : ConnectionConfig
    {
        private const int maxMailBodySize = 256;
        private const int maxMailFieldSize = 64;
        private string sender = "<wojciech.lukasz99@gmail.com>";
        MailValidation mailValidation;
        List<EmailRecipient> emailRecipients;
        EmailMessageData emailMessageData;
        public SendSimpleMail()
        {
            mailValidation = new MailValidation();
        }
        public EmailContent SetSender(string senderName, EmailContent emailContent)
        {              
            if (mailValidation.ValidateMessageContent(senderName, maxMailFieldSize))
            {
                sender = sender.Insert(0, senderName);
            }
            emailContent.From = sender;
            return emailContent;
        }
        public EmailContent SetSubject(string subject, EmailContent emailContent)
        {
            if (mailValidation.ValidateMessageContent(subject, maxMailFieldSize))
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
            if(mailValidation.ValidateMessageContent(message, maxMailBodySize)){
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
        private void setEmailRecipients (string[] recipients)
        {
            emailRecipients = new List<EmailRecipient>();
            foreach (var recipient in recipients)
            {
                EmailRecipient emailRecipient = new EmailRecipient(recipient);
                emailRecipients.Add(emailRecipient);
            }
        }
        private void setMessageData(List<EmailRecipient> emailRecipients, EmailContent emailContent)
        {
            emailMessageData = new EmailMessageData(emailRecipients, emailContent);
        }
        public EmailSend PostEmail(string[] recipients, EmailContent emailContent)
        { 
            ConnectionConfig connectionConfig = new ConnectionConfig();
            setEmailRecipients(recipients);
            setMessageData(emailRecipients, emailContent); 
            return connectionConfig.Config().EmailsPost(emailMessageData);
        }
    }
}
