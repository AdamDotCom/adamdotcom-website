using System.Net;
using System.Web.Mvc;
using AdamDotCom.Website.App.Extensions;
using AdamDotCom.Website.App.Models;
using AdamDotCom.Whois.Service.Proxy;

namespace AdamDotCom.Website.App.Controllers
{
    [HandleError]
    public class GreetingController : Controller
    {
        private readonly IWhois whoisService;

        public GreetingController():this(new WhoisService())
        {
        }

        public GreetingController(IWhois whoisService)
        {
            this.whoisService = whoisService;
        }

        public ActionResult Index()
        {
            if (HttpContext.Request != null)
            {
                var ipAddress = HttpContext.Request.UserHostAddress;
                var referrer = (HttpContext.Request.UrlReferrer != null) ? HttpContext.Request.UrlReferrer.ToString() : string.Empty;

                var whois = whoisService.WhoisEnhancedXml(ipAddress, "Canada,Calgary,Alberta", referrer);

                return Content(new Greeting().Translate(whois).ToString());
            }

            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return null;
        }
    }
}