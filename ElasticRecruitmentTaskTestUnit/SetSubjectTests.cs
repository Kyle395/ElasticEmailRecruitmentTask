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
        public void SetSubjectTestEmptySubject()
        {
            string subject = "\r\n        ";
            SendSimpleMail sendSimpleMail = new SendSimpleMail();
            EmailContent emailContent = new EmailContent();
            sendSimpleMail.SetSubject(subject, emailContent);
            Assert.AreEqual(null, emailContent.Subject);
        }
        [TestMethod]
        public void SetSubjectTestCorrectSubject()
        {
            string subject = "Dunder mifflin is taking over the world";
            SendSimpleMail sendSimpleMail = new SendSimpleMail();
            EmailContent emailContent = new EmailContent();
            sendSimpleMail.SetSubject(subject, emailContent);
            Assert.AreEqual(subject, emailContent.Subject);
        }
    }
}
