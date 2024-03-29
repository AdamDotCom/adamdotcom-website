﻿using System;
using System.Web;
using Rhino.Mocks;

namespace Unit.Tests.Controllers
{
    public static class GreetingMockHelper
    {
        public static HttpContextBase MockedContext(this MockRepository mocks, string urlReferrer)
        {
            var request = mocks.StrictMock<HttpRequestBase>();
            SetupResult.For(request.UserHostAddress).Return("127.0.0.1");
            SetupResult.For(request.UrlReferrer).Return(new Uri(urlReferrer));

            var context = mocks.StrictMock<HttpContextBase>();
            SetupResult.For(context.Request).Return(request);

            return context;
        }
    }
}