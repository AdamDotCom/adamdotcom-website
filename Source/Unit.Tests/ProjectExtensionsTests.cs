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
        public void ShouldVerifyRemoveTrailingCharacter()
        {
            var wordWithTrailingS = "scripts";

            Assert.AreEqual("script", wordWithTrailingS.RemoveTrailingCharacter("s"));
        }

        [Test]
        public void ShouldVerifyEnhance()
        {
            var projects = new Projects
                               {
                                   new Project {Name = "adamdotcom-script", LastModified = DateTime.Now.ToString()}
                               };

            var results = projects.Enhance();

            Assert.AreEqual("scripts", results[0].Name);
            Assert.IsFalse(string.IsNullOrEmpty(results[0].Description));
        }

    }
}
