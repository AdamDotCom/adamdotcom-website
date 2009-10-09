using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdamDotCom_website.App.Models;
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
