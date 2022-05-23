using ElasticEmail.Client;
using ElasticEmail.Model;
using System;
using System.Diagnostics;
using System.Linq;

namespace ElasticRecruitmentTask
{
    class MenuElements
    {
        private SendSimpleMail sendSimpleMail;
        private EmailContent emailContent;
        private MailValidation mailValidation;
        private CsvFileReader csvFile;
        private DialogWindow dialogWindow;
        private string[] recipients;
        public MenuElements()
        {
            sendSimpleMail = new SendSimpleMail();
            emailContent = new EmailContent();
            mailValidation = new MailValidation();
            csvFile = new CsvFileReader();
            dialogWindow = new DialogWindow();
        }
        public void DisplayMainMenu()
        {
            Console.Clear();
            Console.WriteLine("Choose an action:");
            Console.WriteLine("1) write and send an E-Mail:");
            Console.WriteLine("2) send an E-Mail from csv file:");
            Console.WriteLine("3) exit:");
        }
        public bool DisplayTask(bool loadRecipientsFromCsv = false)
        {
            Console.Clear();
            loadSender();
            if (loadRecipientsFromCsv)
            {
                recipients = csvFile.ReadCsvFile(dialogWindow.OpenDialogWindow());
                if (recipients == null)
                {
                    return true;
                }
            }
            else loadRecipients();
            loadSubject();
            loadMailBody();
            return sendEmail();

        }

        private bool sendEmail()
        {
            Console.WriteLine("Would you like send this Email [y/n]");
            if (Console.ReadLine() == "y")
            {
                try
                {
                    var result = sendSimpleMail.PostEmail(recipients, emailContent);
                    return true;
                }
                catch (ApiException e)
                {
                    Debug.Print("Exception when calling EmailsPost: " + e.Message);
                    Debug.Print("Status Code: " + e.ErrorCode);
                    Debug.Print(e.StackTrace);
                }
            }
            return false;
        }

        private void loadMailBody()
        {
            Console.Write("Mail body: ");
            sendSimpleMail.SetBodyParts(Console.ReadLine(), emailContent);
        }

        private void loadSubject()
        {
            Console.Write("Subject: ");
            sendSimpleMail.SetSubject(Console.ReadLine(), emailContent);
        }

        private void loadSender()
        {
            Console.Write("From: ");
            sendSimpleMail.SetSender(Console.ReadLine(), emailContent);
        }

        private void loadRecipients()
        {
            do
            {
                Console.Write("To: ");
                recipients = Console.ReadLine().Split(',', ' ').Where(x => !String.IsNullOrWhiteSpace(x)).ToArray();
            }
            while (!mailValidation.ValidateRecipientEmail(recipients));
        }
    }
}
