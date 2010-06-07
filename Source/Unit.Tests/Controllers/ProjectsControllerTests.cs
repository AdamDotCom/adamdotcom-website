using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using AdamDotCom.Common.Website;
using AdamDotCom.OpenSource.Service.Proxy;
using AdamDotCom.Website.App.Controllers;
using NUnit.Framework;
using Rhino.Mocks;

namespace Unit.Tests.Controllers
{
    [TestFixture]
    public class ProjectsControllerTests
    {
        public void ShouldVerify_Index()
        {
            var mocks = new MockRepository();

            var reviewListService = mocks.StrictMock<IService<Projects>>();
            Expect.Call(reviewListService.Find(null)).IgnoreArguments().Return(new Projects());

            var context = mocks.DynamicMock<HttpContextBase>();

            mocks.ReplayAll();

            var controller = new ProjectsController(reviewListService);
            controller.ControllerContext = new ControllerContext(context, new RouteData(), controller);
            var result = controller.Index("my-github-username", "my-googlecode-username") as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsTrue(result.ViewData.Keys.Contains(typeof(Projects).FullName));

            mocks.VerifyAll();
        }
    }
}
