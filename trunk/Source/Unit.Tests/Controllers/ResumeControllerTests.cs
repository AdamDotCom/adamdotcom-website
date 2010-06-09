using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
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
        public void ShouldVerify_Index()
        {
            var mocks = new MockRepository();

            var service = mocks.StrictMock<IService<Resume>>();
            Expect.Call(service.Find(null)).IgnoreArguments().Return(new Resume());

            var context = mocks.DynamicMock<HttpContextBase>();

            mocks.ReplayAll();

            var controller = new ResumeController(service);
            controller.ControllerContext = new ControllerContext(context, new RouteData(), controller);
            var result = controller.Index("adam-kahtava") as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsTrue(result.ViewData.Model.GetType().FullName == (typeof(Resume).FullName));

            mocks.VerifyAll();
        }
    }
}
