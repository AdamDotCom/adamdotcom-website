using System;
using System.Web.Mvc;
using AdamDotCom.Common.Website;
using AdamDotCom.Whois.Service.Proxy;

namespace AdamDotCom.Website.App.Controllers
{
    [HandleError]
    public class ContactController : Controller
    {
        private readonly IWhois whoisService;

        public ContactController() : this(new WhoisService()) {}

        public ContactController(IWhois whoisService)
        {
            this.whoisService = whoisService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post), ValidateAntiForgeryToken, ValidateInput(false)]  
        public JsonResult Index(string name, string email, string subject, string message)
        {
            var mailerMessage = new MailerMessage
                              {
                                  FromAddress = email,
                                  FromName = name,
                                  Body = message,
                                  Subject = string.Format("Adam.Kahtava.com response :: {0}", subject),
                                  ToAddress = MyWebPresence.EmailAccount,
                                  ToName = MyWebPresence.FullName
                              };

            if(!mailerMessage.IsValid())
            {
                return Json(new[]{"again", "The <span>email</span> and <span>message</span> are mandatory. Fill those fields out and try-try-try again."});
            }

            try
            {
                var whois = whoisService.WhoisXml(string.Empty);

                mailerMessage.Body += string.Format("\n\n----------\n IP Address: {0}", whois.DomainName);
                if (whois.RegistryData.Registrant != null)
                {
                    mailerMessage.Body += string.Format("\n Organization: {0}\n Country: {1}\n", whois.RegistryData.Registrant.Name, whois.RegistryData.Registrant.Country);
                }
            }
            catch
            {
            }

            var mailer = new Mailer();

            if(mailer.Send(mailerMessage))
            {
                return Json(new[]{"success", "Thanks! I'll be reading your message soon."});
            }

            if(mailer.Errors.Count != 0)
            {
                return Json(new[]{"again", "Oh no!! The server gremlins marked your message as spam. Check that your <span>email</span> is valid and that the <span>message</span> don't contain any weird characters. Thanks!"});
            }

            return Json(new[]{"fail", string.Format("Now that's embarasing. You found a bug! Let's take this off my site, here's email address {0}. Thanks!", MyWebPresence.EmailLink)});
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