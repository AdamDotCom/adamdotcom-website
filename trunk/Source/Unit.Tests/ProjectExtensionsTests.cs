using System;
using AdamDotCom.OpenSource.Service.Proxy;
using AdamDotCom.Website.App.Extensions;
using NUnit.Framework;

namespace Unit.Tests
{
    [TestFixture]
    public class ProjectExtensionsTests
    {
        [Test]
        public void ShouldVerify_RemoveTrailingCharacter()
        {
            var wordWithTrailingS = "scripts";

            Assert.AreEqual("script", wordWithTrailingS.RemoveTrailingCharacter("s"));
        }

        [Test]
        public void ShouldVerify_CleanAndEnhance()
        {
            var projects = new Projects
                               {
                                   new Project {Name = "script", Url = string.Empty, LastModified = DateTime.Now.ToString()}
                               };

            var results = projects.Clean().Enhance();

            Assert.AreEqual("Scripts", results[0].Name);
            Assert.IsFalse(string.IsNullOrEmpty(results[0].Description));
        }

    }
}
