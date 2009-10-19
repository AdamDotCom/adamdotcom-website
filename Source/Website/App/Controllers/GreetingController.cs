using System.Web;
using System.Web.Mvc;
using AdamDotCom.Website.App.Extensions;
using AdamDotCom.Website.App.Models;
using AdamDotCom.Whois.Service.Proxy;
using AdamDotCom.Common.Website;

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

        public JsonResult Index()
        {
            var whois = whoisService.WhoisEnhancedXml(null, "Canada,Calgary,Alberta", Request.UrlReferrer.ToString());

            var greeting = new Greeting().GenerateGreeting(whois);
            
            return Json(greeting);
        }
    }
}