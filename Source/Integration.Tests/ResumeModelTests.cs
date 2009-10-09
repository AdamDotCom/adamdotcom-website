using NUnit.Framework;

namespace AdamDotCom.Integration.Tests
{
    [TestFixture]
    public class ResumeModelTests
    {
        [Test]
        public void ShouldGetExternalResume()
        {
            var resume = new Resume.Service.Proxy.Resume();

            Assert.IsNotNull(resume);
        }
    }
}