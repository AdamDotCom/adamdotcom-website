using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;
using AdamDotCom.Website.App.Controllers;
using AdamDotCom.Website.App.Models;
using AdamDotCom.Whois.Service.Proxy;
using NUnit.Framework;
using Rhino.Mocks;

namespace Unit.Tests
{
    [TestFixture]
    public class GreetingControllerTests
    {
        [Test]
        public void ShouldVerifyLoadFromService()
        {
            var mocks = new MockRepository();

            var service = mocks.StrictMock<IWhois>();
            var context = mocks.FakeHttpContext("http://www.sanity-check-this-could-be-any-url.com");

            Expect.Call(service.WhoisEnhancedXml(null, null, null)).IgnoreArguments().Return(new WhoisEnhancedRecord());
            
            mocks.ReplayAll();
            
            var controller = new GreetingController(service);
            controller.ControllerContext = new ControllerContext(context, new RouteData(),  controller);
            controller.Index();

            mocks.VerifyAll();
        }

        [Test]
        public void ShouldVerifyLoadFromService_IsFriendly()
        {
            var mocks = new MockRepository();

            var service = mocks.StrictMock<IWhois>();
            var context = mocks.FakeHttpContext("http://www.twitter.com");

            Expect.Call(service.WhoisEnhancedXml(null, null, null)).IgnoreArguments().Return(new WhoisEnhancedRecord
                                                                                                 {
                                                                                                     IsReferrerMatch = true,
                                                                                                     ReferrerMatches = new List<string> {"twitter"}
                                                                                                 });

            mocks.ReplayAll();

            var controller = new GreetingController(service);
            controller.ControllerContext = new ControllerContext(context, new RouteData(), controller);
            var result = controller.Index();

            mocks.VerifyAll();

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);

            var greeting = ((Greeting) result.Data);

            Assert.IsFalse(string.IsNullOrEmpty(greeting.Message));

            Console.Write(greeting.Message);
        }

        [Test]
        public void ShouldVerifyWhenThingsGoBad()
        {
            var mocks = new MockRepository();

            var service = mocks.StrictMock<IWhois>();

            //
            //service.Stub(WhoisEnhancedXml).IgnoreArguments().Return(null);

            Assert.Fail();
        }
    }
}