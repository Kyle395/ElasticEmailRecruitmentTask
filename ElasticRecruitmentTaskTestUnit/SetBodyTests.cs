using Microsoft.VisualStudio.TestTools.UnitTesting;
using ElasticRecruitmentTask;
using System;
using ElasticEmail.Api;
using ElasticEmail.Client;
using ElasticEmail.Model;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace ElasticRecruitmentTaskTestUnit
{
    [TestClass]
    public class SetBodyTests
    {       
        [TestMethod]
        public void SetBodyTest1()
        {
            string message = "                \n\n\n\n\r";
            SendSimpleMail sendSimpleMail = new SendSimpleMail();         
            
            Assert.AreEqual(null, sendSimpleMail.SetBody(message).Content);
        }
        [TestMethod]
        public void SetBodyTest2()
        {
            string message = "          \n\n\n\n czesc";
            SendSimpleMail sendSimpleMail = new SendSimpleMail();

            Assert.AreEqual(message, sendSimpleMail.SetBody(message).Content);
        }
    }
}
