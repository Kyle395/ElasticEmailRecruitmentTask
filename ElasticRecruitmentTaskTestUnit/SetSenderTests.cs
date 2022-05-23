using ElasticEmail.Model;
using ElasticRecruitmentTask;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ElasticRecruitmentTaskTestUnit
{
    [TestClass]
    public class SetSenderTests
    {
        SendSimpleMail sendSimpleMail;
        EmailContent emailContent;
        [TestMethod]
        public void SetSenderTestEmptyName()
        {
            string senderName = "          ";
            string senderMail = "<wojciech.lukasz99@gmail.com>";
            sendSimpleMail = new SendSimpleMail();
            emailContent = new EmailContent();
            sendSimpleMail.SetSender(senderName, emailContent);
            Assert.AreEqual(senderMail, emailContent.From);
        }
        [TestMethod]
        public void SetSenderTestToLongName()
        {
            string senderName = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            string senderMail = "<wojciech.lukasz99@gmail.com>";
            sendSimpleMail = new SendSimpleMail();
            emailContent = new EmailContent();
            sendSimpleMail.SetSender(senderName, emailContent);
            Assert.AreEqual(senderMail, emailContent.From);
        }
        [TestMethod]
        public void SetSenderTestCorrectName()
        {
            string senderName = "Michael Scott";
            string senderMail = "<wojciech.lukasz99@gmail.com>";
            sendSimpleMail = new SendSimpleMail();
            emailContent = new EmailContent();
            sendSimpleMail.SetSender(senderName, emailContent);
            Assert.AreEqual(senderName + senderMail, emailContent.From);
        }
    }
}
