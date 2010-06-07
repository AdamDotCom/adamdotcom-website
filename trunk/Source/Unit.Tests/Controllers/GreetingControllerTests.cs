using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;
using AdamDotCom.Website.App.Controllers;
using AdamDotCom.Whois.Service.Proxy;
using NUnit.Framework;
using Rhino.Mocks;

namespace Unit.Tests.Controllers
{
    [TestFixture]
    public class GreetingControllerTests
    {
        [Test]
        public void ShouldVerify_Index_GoogleFriendly()
        {
            var mocks = new MockRepository();

            var context = mocks.MockedContext("http://www.google.com");
            
            var service = mocks.StrictMock<IWhois>();
            Expect.Call(service.WhoisEnhancedXml(null, null, null)).IgnoreArguments().Return(new WhoisEnhancedRecord
                                                                                                 {
                                                                                                     IsFriendly = true,
                                                                                                     FriendlyMatches = new List<string> {"google"}
                                                                                                 });
            
            mocks.ReplayAll();
            
            var controller = new GreetingController(service);
            controller.ControllerContext = new ControllerContext(context, new RouteData(),  controller);
            var result = controller.Index() as ContentResult;

            Assert.IsNotNull(result);
            Assert.IsNotNull((result.Content.Contains("Google")));

            mocks.VerifyAll();
        }

        [Test]
        public void ShouldVerify_Index_TwitterReferrer()
        {
            var mocks = new MockRepository();

            var service = mocks.StrictMock<IWhois>();
            var context = mocks.MockedContext("http://www.twitter.com");

            Expect.Call(service.WhoisEnhancedXml(null, null, null)).IgnoreArguments().Return(new WhoisEnhancedRecord
                                                                                                 {
                                                                                                     IsReferrerMatch = true,
                                                                                                     ReferrerMatches = new List<string> {"twitter"}
                                                                                                 });

            mocks.ReplayAll();

            var controller = new GreetingController(service);
            controller.ControllerContext = new ControllerContext(context, new RouteData(), controller);
            var result = controller.Index() as ContentResult;

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Content.Contains("Twitter"));

            mocks.VerifyAll();
        }

        [Test, ExpectedException(typeof(NullReferenceException))]
        public void ShouldVerify_Index_WhoisFail()
        {
            var service = MockRepository.GenerateStub<IWhois>();

            service.Stub(s => s.WhoisEnhancedXml(null, null, null)).IgnoreArguments().Return(null);

            new GreetingController(service).Index();
        }
    }
}