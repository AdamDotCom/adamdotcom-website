using System;
using System.Collections.Generic;
using AdamDotCom.Resume.Service.Proxy;
using AdamDotCom.Website.App.Extensions;
using NUnit.Framework;

namespace Unit.Tests
{
    [TestFixture]
    public class ResumeExtensionsTests
    {
        [Test]
        public void ShouldVerify_AcryonymHtml()
        {
            var result = ResumeExtensions.AcronymMarkup("CSS", "Cascading Style Sheets");
         
            Console.WriteLine(result);
            Assert.IsTrue(result.Contains("<acronym title=\"Cascading Style Sheets\">"));
        }

        [Test]
        public void ShouldVerify_AcronymEnricher()
        {
            var resume = new Resume {Positions = new List<Position> {new Position {Description = "CSS, IIS"}}};
            var result = resume.Enrich();

            Assert.IsTrue(result.Positions[0].Description.ToLower().Contains("acronym title="));
        }
    }
}
