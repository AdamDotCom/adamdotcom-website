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
        public void ShouldVerifyLoadFromServiceAndSave()
        {

        }

        [Test]
        public void ShouldVerifyAcryonymHtml()
        {
            var result = ResumeExtensions.AcronymMarkup("CSS", "Cascading Style Sheets");
         
            Console.WriteLine(result);
            Assert.IsTrue(result.Contains("&lt;acronym title=\"Cascading Style Sheets\"&gt;"));
        }

        [Test]
        public void ShouldVerifyAcronymEnricher()
        {
            var resume = new Resume {Positions = new List<Position> {new Position {Description = "CSS, IIS"}}};
            var result = resume.Enrich();

            Assert.IsTrue(result.Positions[0].Description.ToLower().Contains("acronym title="));
        }
    }
}
