using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using AdamDotCom.Amazon.Service.Proxy;
using AdamDotCom.Common.Website;
using AdamDotCom.Website.App.Controllers;
using AdamDotCom.Website.App.Models;
using NUnit.Framework;
using Rhino.Mocks;

namespace Unit.Tests.Controllers
{
    [TestFixture]
    public class AmazonControllerTests
    {
        [Test]
        public void ShouldVerify_Reviews()
        {
            var mocks = new MockRepository();

            var reviewListService = mocks.StrictMock<IService<Reviews>>();
            Expect.Call(reviewListService.Find(null)).IgnoreArguments().Return(new Reviews());

            var context = mocks.DynamicMock<HttpContextBase>();

            mocks.ReplayAll();

            var controller = new AmazonController(null, null, reviewListService);
            controller.ControllerContext = new ControllerContext(context, new RouteData(), controller);
            var result = controller.Reviews("some-id") as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsTrue(result.ViewData.Model.GetType().FullName == (typeof(Reviews).FullName));

            mocks.VerifyAll();
        }

        [Test]
        public void ShouldVerify_ReadingLists()
        {
            var mocks = new MockRepository();

            var haveReadListService = mocks.StrictMock<IService<HaveReadList>>();
            Expect.Call(haveReadListService.Find(null)).IgnoreArguments().Return(new HaveReadList());

            var toReadListService = mocks.StrictMock<IService<ToReadList>>();
            Expect.Call(toReadListService.Find(null)).IgnoreArguments().Return(new ToReadList());

            var context = mocks.DynamicMock<HttpContextBase>();

            mocks.ReplayAll();

            var controller = new AmazonController(haveReadListService, toReadListService, null);
            controller.ControllerContext = new ControllerContext(context, new RouteData(), controller);
            var result = controller.ReadingLists("have-read-list-id", "to-read-list-id") as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsTrue(result.ViewData.Model.GetType().FullName == (typeof(ReadingLists).FullName));

            mocks.VerifyAll();
        }
    }
}
