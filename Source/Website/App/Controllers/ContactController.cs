using System.Web.Mvc;
using AdamDotCom.Whois.Service.Proxy;

namespace AdamDotCom.Website.App.Controllers
{
    [HandleError]
    public class ContactController : Controller
    {
        private readonly IWhois whoisService;

        public ContactController():this(new WhoisService())
        {
        }

        public ContactController(IWhois whoisService)
        {
            this.whoisService = whoisService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        //, RequiresXhr]
        public ActionResult Index(string name, string email, string message)
        {

            return View();
        }

        public JsonResult GetEmail()
        {
            var whois = whoisService.WhoisEnhancedXml(null, "Canada,Calgary,Alberta", null);

            if (whois.IsFriendly || whois.IsFilterMatch)
            {
                return Json(MyWebPresence.EmailAccount);
            }

            Response.StatusCode = 400;
            return null;
        }
    }
}