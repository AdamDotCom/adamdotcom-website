using System;
using AdamDotCom.Common.Website;
using AdamDotCom.Resume.Service.Proxy;
using NUnit.Framework;

namespace Unit.Tests
{
    [TestFixture]
    public class RepositoryTests
    {
        public void ShouldVerifyRepository()
        {
            var resume = new Resume {Summary = Guid.NewGuid().ToString()};

            var repository = new Repository();

            Assert.IsTrue(repository.Save(resume));

            var result = repository.Find<Resume>();

            Assert.IsNotNull(result);
            Assert.AreEqual(resume.Summary, result.Summary);
        }
    }
}
