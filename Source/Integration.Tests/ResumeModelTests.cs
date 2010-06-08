using AdamDotCom.Resume.Service.Proxy;
using NUnit.Framework;

namespace AdamDotCom.Integration.Tests
{
    [TestFixture]
    public class ResumeModelTests
    {
        [Test, Ignore]
        //ToDo: consider integration test in the future
        public void ShouldGetExternalResume()
        {
            var resume = new ResumeService().ResumeXml("Adam-Kahtava");
            
            Assert.IsNotNull(resume);
        }
    }
}