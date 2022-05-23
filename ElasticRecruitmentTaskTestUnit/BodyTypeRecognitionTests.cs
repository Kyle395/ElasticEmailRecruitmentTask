using ElasticEmail.Model;
using ElasticRecruitmentTask;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ElasticRecruitmentTaskTestUnit
{
    [TestClass]
    public class BodyTypeRecognitionTests
    {
        SendSimpleMail sendSimpleMail;
        [TestMethod]
        public void RecognizeBodyTypePlainText()
        {
            string test = "Hello, this is normal test mail message. ";
            sendSimpleMail = new SendSimpleMail();

            Assert.AreEqual(BodyContentType.PlainText, sendSimpleMail.SetBodyType(test));

        }
        [TestMethod]
        public void RecognizeBodyTypeHTML()
        {
            string test = "<html></html>";
            sendSimpleMail = new SendSimpleMail();

            Assert.AreEqual(BodyContentType.HTML, sendSimpleMail.SetBodyType(test));
        }
    }
}
