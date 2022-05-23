using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ElasticRecruitmentTask;

namespace ElasticRecruitmentTaskTestUnit
{
    [TestClass]
    public class MailValidationTests
    {
        [TestMethod]
        public void MailValidationTest1()
        {
            string[] mails = new string[1];
            mails[0] = "examplemail@gmail.com";
            MailValidation mailValidation = new MailValidation();
            Assert.IsTrue(mailValidation.ValidateRecipientEmail(mails));
            
        }
        [TestMethod]
        public void MailValidationTest2()
        {
            string[] mails = new string[1];
            mails[0] = "examplemail@gmailcom";
            MailValidation mailValidation = new MailValidation();
            Assert.IsFalse(mailValidation.ValidateRecipientEmail(mails));
        }
        [TestMethod]
        public void MailValidationTest3()
        {
            string[] mails = new string[1];
            mails[0] = "examplemailgmail.com";
            MailValidation mailValidation = new MailValidation();
            Assert.IsFalse(mailValidation.ValidateRecipientEmail(mails));
        }
    }
}
