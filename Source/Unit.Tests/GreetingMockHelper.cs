using System;
using System.Web;
using Rhino.Mocks;

namespace Unit.Tests
{
    public static class GreetingMockHelper
    {
        public static HttpContextBase FakeHttpContext(this MockRepository mocks, string urlReferrer)
        {
            var request = mocks.StrictMock<HttpRequestBase>();
            SetupResult.For(request.UrlReferrer).Return(new Uri(urlReferrer));
            var context = mocks.StrictMock<HttpContextBase>();
            SetupResult.For(context.Request).Return(request);
            return context;
        }
    }
}
