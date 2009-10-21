using System.Web.Mvc;
using AdamDotCom.Common.Website;
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

        [AcceptVerbs(HttpVerbs.Post), ValidateAntiForgeryToken]
        
        public JsonResult Index(string name, string email, string subject, string message)
        {
            //nice to have but not crucial
            try
            {
                var whois = whoisService.WhoisXml(null);

                message += string.Format("\n\n----------\n IP Address: {0}\n Organization: {1}\n Country: {2}\n",
                                         whois.DomainName, whois.RegistryData.Registrant.Name,
                                         whois.RegistryData.Registrant.Country);
            }
            catch
            {
            }

            var mailerMessage = new MailerMessage
                              {
                                  FromAddress = email,
                                  FromName = name,
                                  Body = message,
                                  Subject = string.Format("Adam.Kahtava.com response :: {0}", subject),
                                  ToAddress = MyWebPresence.EmailLink,
                                  ToName = MyWebPresence.FullName
                              };

            if(new Mailer().Send(mailerMessage))
            {
                return Json("Thanks! I'll be reading your message soon.");
            }

            return Json(string.Format("You found a bug! Now that's embarasing. Let's do this manually, here's email address {0}. Thanks!", MyWebPresence.EmailLink));
        }

        public JsonResult GetEmail()
        {
            var whois = whoisService.WhoisEnhancedXml(null, "Canada,Calgary,Alberta", null);

            if (whois.IsFriendly || whois.IsFilterMatch)
            {
                return Json(MyWebPresence.EmailLink);
            }

            Response.StatusCode = 400;
            return null;
        }
    }
}