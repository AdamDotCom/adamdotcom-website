using AdamDotCom.Resume.Service.Proxy;
using NUnit.Framework;

namespace Integration.Tests
{
    [TestFixture]
    public class ResumeModelTests
    {
        [Test]
        public void ShouldGetExternalResume()
        {
            var resume = new Resume();

            Assert.IsNotNull(resume);
        }
    }
}
