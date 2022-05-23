using ElasticEmail.Client;
using ElasticEmail.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElasticRecruitmentTask
{
    class MenuElements
    {
        public void displayMainMenu()
        {
            Console.Clear();
            Console.WriteLine("Choose an action:");
            Console.WriteLine("1) write and send an E-Mail:");
            Console.WriteLine("2) send an E-Mail from csv file:");
            Console.WriteLine("3) exit:");
        }
        public bool displayFirstTask()
        {
            SendSimpleMail sendSimpleMail = new SendSimpleMail();
            EmailContent emailContent = new EmailContent();
            MailValidation mailValidation = new MailValidation();
            string[] recipients;
            Console.Clear();
            Console.Write("From: ");
            sendSimpleMail.SetSender(Console.ReadLine(), emailContent);
            do
            {
                Console.Write("To: ");
                recipients = Console.ReadLine().Split(',', ' ').Where(x => !String.IsNullOrWhiteSpace(x)).ToArray();
            }
            while (!mailValidation.ValidateRecipientEmail(recipients));
            Console.Write("Subject: ");
            sendSimpleMail.SetSubject(Console.ReadLine(), emailContent);
            Console.Write("Mail body: ");
            sendSimpleMail.SetBodyParts(Console.ReadLine(), emailContent);
            Console.WriteLine("Would you like send this Email [y/n]");
            if (Console.ReadLine() == "y")
            {
                try
                {
                    var result = sendSimpleMail.postEmail(recipients, emailContent);
                    return true;
                }
                catch (ApiException e)
                {
                    Debug.Print("Exception when calling EmailsPost: " + e.Message);
                    Debug.Print("Status Code: " + e.ErrorCode);
                    Debug.Print(e.StackTrace);
                    return false;
                }
            }
            else return false;
            
        }
        public bool displaySecondTask()
        {
            DialogWindow dialogWindow = new DialogWindow();
            CsvFileReader csvFile = new CsvFileReader();
            SendSimpleMail sendSimpleMail = new SendSimpleMail();
            EmailContent emailContent = new EmailContent();
            Console.Clear();
            string[] recipients=csvFile.ReadCsvFile(dialogWindow.OpenDialogWindow());
            if (recipients == null)
            {
                return true;
            }
            Console.Write("From: ");
            sendSimpleMail.SetSender(Console.ReadLine(), emailContent);
            Console.Write("Subject: ");
            sendSimpleMail.SetSubject(Console.ReadLine(), emailContent);
            Console.Write("Mail body: ");
            sendSimpleMail.SetBodyParts(Console.ReadLine(), emailContent);
            Console.WriteLine("Would you like send this Email [y/n]");
                if (Console.ReadLine() == "y")
                {
                    try
                    {
                        var result = sendSimpleMail.postEmail(recipients, emailContent);
                        return true;
                    }
                    catch (ApiException e)
                    {
                        Debug.Print("Exception when calling EmailsPost: " + e.Message);
                        Debug.Print("Status Code: " + e.ErrorCode);
                        Debug.Print(e.StackTrace);
                        return false;
                    }
                }
                else return false;
        }
    }
}
