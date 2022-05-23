using Microsoft.VisualStudio.TestTools.UnitTesting;
using ElasticRecruitmentTask;

namespace ElasticRecruitmentTaskTestUnit
{
    [TestClass]
    public class MailValidationTests
    {
        MailValidation mailValidation;
        [TestMethod]
        public void MailValidationTestCorrect()
        {
            string[] mails = new string[1];
            mails[0] = "examplemail@gmail.com";
            mailValidation = new MailValidation();
            Assert.IsTrue(mailValidation.ValidateRecipientEmail(mails));
            
        }
        [TestMethod]
        public void MailValidationTestNoDot()
        {
            string[] mails = new string[1];
            mails[0] = "examplemail@gmailcom";
            mailValidation = new MailValidation();
            Assert.IsFalse(mailValidation.ValidateRecipientEmail(mails));
        }
        [TestMethod]
        public void MailValidationTestNoAt()
        {
            string[] mails = new string[1];
            mails[0] = "examplemailgmail.com";
            mailValidation = new MailValidation();
            Assert.IsFalse(mailValidation.ValidateRecipientEmail(mails));
        }
    }
}
