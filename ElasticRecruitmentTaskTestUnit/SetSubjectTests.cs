using ElasticEmail.Model;
using ElasticRecruitmentTask;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ElasticRecruitmentTaskTestUnit
{
    [TestClass]
    public class SetSubjectTests
    {
        [TestMethod]
        public void SetSubjectTest1()
        {
            string subject = "\r\n        ";
            SendSimpleMail sendSimpleMail = new SendSimpleMail();
            EmailContent emailContent = new EmailContent();
            sendSimpleMail.SetSubject(subject, emailContent);
            Assert.AreEqual(null, emailContent.Subject);
        }
        [TestMethod]
        public void SetSubjectTest2()
        {
            string subject = "Dunder mifflin is taking over the world";
            SendSimpleMail sendSimpleMail = new SendSimpleMail();
            EmailContent emailContent = new EmailContent();
            sendSimpleMail.SetSubject(subject, emailContent);
            Assert.AreEqual(subject, emailContent.Subject);
        }
    }
}
