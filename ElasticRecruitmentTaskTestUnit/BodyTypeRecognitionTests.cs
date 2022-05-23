using ElasticEmail.Model;
using ElasticRecruitmentTask;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ElasticRecruitmentTaskTestUnit
{
    [TestClass]
    public class BodyTypeRecognitionTests
    {
        [TestMethod]
        public void RecognizeBodyTypePlainText()
        {
            string test = "Hello, this is normal test mail message. ";
            SendSimpleMail sendSimpleMail = new SendSimpleMail();

            Assert.AreEqual(BodyContentType.PlainText, sendSimpleMail.SetBodyType(test));

        }
        [TestMethod]
        public void RecognizeBodyTypeHTML()
        {
            string test = "<html></html>";
            SendSimpleMail sendSimpleMail = new SendSimpleMail();

            Assert.AreEqual(BodyContentType.HTML, sendSimpleMail.SetBodyType(test));
        }
    }
}
