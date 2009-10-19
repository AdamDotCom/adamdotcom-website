using System;
using System.Collections.Generic;
using AdamDotCom.Common.Website;
using AdamDotCom.Resume.Service.Proxy;
using NUnit.Framework;

namespace Unit.Tests
{
    [TestFixture]
    public class LocalDataExtensionsTests
    {
        [Test]
        public void ShouldVerifySaveAndLoadFromLocal()
        {
            var resume = new Resume
                             {
                                 Summary = string.Format("test-summary-{0}", Guid.NewGuid()),
                                 Educations = new List<Education> {new Education {Certificate = "test-certificate", Institute = string.Format("test-institute-{0}", Guid.NewGuid())}},
                                 Positions = new List<Position> {new Position
                                                                     {
                                                                         Company = "test-company",
                                                                         Description = string.Format("test-description-{0}", Guid.NewGuid()),
                                                                         Period = "test-period",
                                                                         Title = "test-title"
                                                                     }
                                                                },
                                 Specialties = "test-specialities"
                             };
            LocalDataExtensions.SaveLocal(resume);

            var resumeFromLoad = LocalDataExtensions.FindLocal(resume) as Resume;
            
            Assert.IsNotNull(resumeFromLoad);
            Assert.AreEqual(resume.Summary, resumeFromLoad.Summary);
            Assert.AreEqual(resume.Educations[0].Institute, resume.Educations[0].Institute);
            Assert.AreEqual(resume.Positions[0].Description, resumeFromLoad.Positions[0].Description);
        }

        [Test]
        public void ShouldVerifyStaleness()
        {
            var resume = new Resume();

            LocalDataExtensions.SaveLocal(resume);

            LocalDataExtensions.StalenessInDays = 1;
            Assert.IsFalse(resume.IsLocalStale());

            LocalDataExtensions.StalenessInDays = -1;
            Assert.IsTrue(resume.IsLocalStale());
        }
    }
}
