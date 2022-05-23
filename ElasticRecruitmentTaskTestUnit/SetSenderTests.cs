using ElasticEmail.Model;
using ElasticRecruitmentTask;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ElasticRecruitmentTaskTestUnit
{
    [TestClass]
    public class SetSenderTests
    {
        [TestMethod]
        public void SetSenderTest1()
        {
            string senderName = "          ";
            string senderMail = "<wojciech.lukasz99@gmail.com>";
            SendSimpleMail sendSimpleMail = new SendSimpleMail();
            EmailContent emailContent = new EmailContent();
            sendSimpleMail.SetSender(senderName, emailContent);
            Assert.AreEqual(senderMail, emailContent.From);
        }
        [TestMethod]
        public void SetSenderTest2()
        {
            string senderName = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            string senderMail = "<wojciech.lukasz99@gmail.com>";
            SendSimpleMail sendSimpleMail = new SendSimpleMail();
            EmailContent emailContent = new EmailContent();
            sendSimpleMail.SetSender(senderName, emailContent);
            Assert.AreEqual(senderMail, emailContent.From);
        }
        [TestMethod]
        public void SetSenderTest3()
        {
            string senderName = "Michael Scott";
            string senderMail = "<wojciech.lukasz99@gmail.com>";
            SendSimpleMail sendSimpleMail = new SendSimpleMail();
            EmailContent emailContent = new EmailContent();
            sendSimpleMail.SetSender(senderName, emailContent);
            Assert.AreEqual(senderName + senderMail, emailContent.From);
        }
    }
}
