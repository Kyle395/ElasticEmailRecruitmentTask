using Microsoft.VisualStudio.TestTools.UnitTesting;
using ElasticRecruitmentTask;

namespace ElasticRecruitmentTaskTestUnit
{
    [TestClass]
    public class SetBodyTests
    {       
        [TestMethod]
        public void SetBodyTestEmptyString()
        {
            string message = "                \n\n\n\n\r";
            SendSimpleMail sendSimpleMail = new SendSimpleMail();         
            
            Assert.AreEqual(null, sendSimpleMail.SetBody(message).Content);
        }
        [TestMethod]
        public void SetBodyTestCorrectString()
        {
            string message = "          \n\n\n\n czesc";
            SendSimpleMail sendSimpleMail = new SendSimpleMail();

            Assert.AreEqual(message, sendSimpleMail.SetBody(message).Content);
        }
    }
}
