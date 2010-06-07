using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using AdamDotCom.Common.Website;
using AdamDotCom.Website.App;
using AdamDotCom.Website.App.Controllers;
using AdamDotCom.Whois.Service.Proxy;
using NUnit.Framework;
using Rhino.Mocks;

namespace Unit.Tests.Controllers
{
    [TestFixture]
    public class ContactControllerTests
    {
        private HttpRequestBase MockedRequest(MockRepository mocks)
        {
            var request = mocks.StrictMock<HttpRequestBase>();
            SetupResult.For(request.UserHostAddress).Return("127.0.0.1");
            SetupResult.For(request.UrlReferrer).Return(new Uri("http://www.google.com"));
            SetupResult.For(request.QueryString).Return(new NameValueCollection());
            SetupResult.For(request.Files).Return(MockRepository.GenerateStub<HttpFileCollectionBase>());
            return request;
        }

        private NameValueCollection MailerFormValues()
        {
            var form = new FormCollection();
            form.Add("name", "name");
            form.Add("FromAddress", "test@test.com");
            form.Add("Body", "Hello world!");
            return form;
        }
            
        [Test]
        public void ShouldVerify_IsFriendly()
        {
            var mocks = new MockRepository();

            var context = mocks.DynamicMock<HttpContextBase>();
            SetupResult.For(context.Request).Return(MockedRequest(mocks));
            
            var whoisService = mocks.StrictMock<IWhois>();

            Expect.Call(whoisService.WhoisEnhancedXml(null, null, null)).IgnoreArguments().Return(new WhoisEnhancedRecord {IsFriendly = true});

            mocks.ReplayAll();

            var controller = new ContactController(whoisService, null);
            controller.ControllerContext = new ControllerContext(context, new RouteData(), controller);
            var result = controller.IsFriendly() as ContentResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(MyWebPresence.EmailAccount, result.Content);

            mocks.VerifyAll();
        }

        [Test]
        public void ShouldVerify_IsNotFriendly()
        {
            var mocks = new MockRepository();

            var context = mocks.DynamicMock<HttpContextBase>();
            SetupResult.For(context.Request).Return(MockedRequest(mocks));

            var response = mocks.StrictMock<HttpResponseBase>();
            SetupResult.For(response.StatusCode).PropertyBehavior();
            SetupResult.For(context.Response).Return(response);

            var whoisService = mocks.StrictMock<IWhois>();

            Expect.Call(whoisService.WhoisEnhancedXml(null, null, null)).IgnoreArguments().Return(new WhoisEnhancedRecord {IsFriendly = false});

            mocks.ReplayAll();

            var controller = new ContactController(whoisService, null);
            controller.ControllerContext = new ControllerContext(context, new RouteData(), controller);
            var result = controller.IsFriendly() as ContentResult;

            Assert.IsNotNull(result);
            Assert.AreNotEqual(MyWebPresence.EmailAccount, result.Content);
            Assert.IsTrue(controller.Response.StatusCode == (int) HttpStatusCode.BadRequest);

            mocks.VerifyAll();
        }

        [Test]
        public void ShouldVerify_MailerSend_Success()
        {
            var mocks = new MockRepository();

            var context = mocks.DynamicMock<HttpContextBase>();

            var request = MockedRequest(mocks);
            SetupResult.For(request.Form).Return(MailerFormValues());
            SetupResult.For(context.Request).Return(request);
            
            var whoisService = mocks.StrictMock<IWhois>();
            Expect.Call(whoisService.WhoisXml(null)).IgnoreArguments().Return(new WhoisRecord());

            var mailer = mocks.StrictMock<IMailer>();
            Expect.Call(mailer.Send(null)).IgnoreArguments().Return(true);

            mocks.ReplayAll();

            var controller = new ContactController(whoisService, mailer);
            controller.ControllerContext = new ControllerContext(context, new RouteData(), controller);
            
            var result = controller.Send() as RedirectToRouteResult;

            Assert.IsNotNull(result);

            Assert.IsTrue(result.RouteValues.ContainsValue("Thanks"));

            mocks.VerifyAll();
        }

        [Test]
        public void ShouldVerify_SendFailure_MailerMessage_Fail()
        {
            var mocks = new MockRepository();

            var context = mocks.DynamicMock<HttpContextBase>();

            var request = MockedRequest(mocks);
            SetupResult.For(request.Form).Return(new NameValueCollection());
            SetupResult.For(context.Request).Return(request);

            var response = mocks.StrictMock<HttpResponseBase>();
            SetupResult.For(response.StatusCode).PropertyBehavior();
            SetupResult.For(context.Response).Return(response);

            var whoisService = mocks.StrictMock<IWhois>();           

            var mailer = mocks.StrictMock<IMailer>();

            mocks.ReplayAll();

            var controller = new ContactController(whoisService, mailer);
            controller.ControllerContext = new ControllerContext(context, new RouteData(), controller);

            var result = controller.Send() as ContentResult;

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Content);

            Assert.IsTrue(controller.Response.StatusCode == (int) HttpStatusCode.NotAcceptable);

            mocks.VerifyAll();
        }

        [Test]
        public void ShouldVerify_SendFailure_MailerSend_FailFromErrors()
        {
            var mocks = new MockRepository();

            var context = mocks.DynamicMock<HttpContextBase>();

            var request = MockedRequest(mocks);
            SetupResult.For(request.Form).Return(MailerFormValues());
            SetupResult.For(context.Request).Return(request);

            var response = mocks.StrictMock<HttpResponseBase>();
            SetupResult.For(response.StatusCode).PropertyBehavior();
            SetupResult.For(context.Response).Return(response);

            var whoisService = mocks.StrictMock<IWhois>();
            Expect.Call(whoisService.WhoisXml(null)).IgnoreArguments().Return(new WhoisRecord());

            var mailer = mocks.StrictMock<IMailer>();
            Expect.Call(mailer.Send(null)).IgnoreArguments().Return(false);
            Expect.Call(mailer.Errors).Return(new List<string> {"error"});

            mocks.ReplayAll();

            var controller = new ContactController(whoisService, mailer);
            controller.ControllerContext = new ControllerContext(context, new RouteData(), controller);

            var result = controller.Send() as ContentResult;

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Content);

            Assert.IsTrue(controller.Response.StatusCode == (int) HttpStatusCode.BadRequest);

            mocks.VerifyAll();
        }

        [Test]
        public void ShouldVerify_SendFailure_MailerSend_FailFromUnknown()
        {
            var mocks = new MockRepository();

            var context = mocks.DynamicMock<HttpContextBase>();

            var request = MockedRequest(mocks);
            SetupResult.For(request.Form).Return(MailerFormValues());
            SetupResult.For(context.Request).Return(request);

            var response = mocks.StrictMock<HttpResponseBase>();
            SetupResult.For(response.StatusCode).PropertyBehavior();
            SetupResult.For(context.Response).Return(response);

            var whoisService = mocks.StrictMock<IWhois>();
            Expect.Call(whoisService.WhoisXml(null)).IgnoreArguments().Return(new WhoisRecord());

            var mailer = mocks.StrictMock<IMailer>();
            Expect.Call(mailer.Send(null)).IgnoreArguments().Return(false);
            Expect.Call(mailer.Errors).Return(new List<string>());

            mocks.ReplayAll();

            var controller = new ContactController(whoisService, mailer);
            controller.ControllerContext = new ControllerContext(context, new RouteData(), controller);

            var result = controller.Send() as ContentResult;

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Content);

            Assert.IsTrue(controller.Response.StatusCode == (int) HttpStatusCode.InternalServerError);

            mocks.VerifyAll();
        }
    }
}
