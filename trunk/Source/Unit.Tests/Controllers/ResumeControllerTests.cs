using AdamDotCom.Common.Website;
using AdamDotCom.Resume.Service.Proxy;
using AdamDotCom.Website.App.Controllers;
using NUnit.Framework;
using Rhino.Mocks;

namespace Unit.Tests.Controllers
{
    [TestFixture]
    public class ResumeControllerTests
    {
        [Test]
        public void ShouldVerifyLoadFromServiceAndSaveWhenRepository_IsEmpty()
        {
            var mocks = new MockRepository();

            var repository = mocks.StrictMock<IRepository>();
            var service = mocks.StrictMock<IResume>();

            Expect.Call(repository.Find<Resume>()).IgnoreArguments().Return(null);
            Expect.Call(service.ResumeXml(string.Empty)).IgnoreArguments().Return(new Resume());
            Expect.Call(repository.Save(new Resume())).IgnoreArguments().Return(true);
            
            mocks.ReplayAll();
            
            new ResumeController(repository, service).Index(string.Empty);

            mocks.VerifyAll();
        }

        [Test]
        public void ShouldVerifyLoadFromServiceAndSaveWhenRepository_IsStale()
        {
            var mocks = new MockRepository();

            var repository = mocks.StrictMock<IRepository>();
            var service = mocks.StrictMock<IResume>();

            Expect.Call(repository.Find<Resume>()).IgnoreArguments().Return(new Resume());
            Expect.Call(repository.IsStale<Resume>()).IgnoreArguments().Return(true);
            Expect.Call(service.ResumeXml(string.Empty)).IgnoreArguments().Return(new Resume());
            Expect.Call(repository.Save(new Resume())).IgnoreArguments().Return(true);

            mocks.ReplayAll();

            new ResumeController(repository, service).Index(string.Empty);

            mocks.VerifyAll();
        }
    }
}