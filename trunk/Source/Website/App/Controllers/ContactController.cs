using System;
using System.Net;
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

        public ActionResult Thanks()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post), ValidateAntiForgeryToken, ValidateInput(false)]  
        public ActionResult Index(string name, string email, string subject, string message)
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
                HttpContext.Response.StatusCode = (int) HttpStatusCode.NotAcceptable;
                return Json("The <span>email</span> and <span>message</span> are mandatory. Fill those fields out and try, try, try again.");
            }

            mailerMessage = AppendWhois(mailerMessage);

            var mailer = new Mailer();

            if(mailer.Send(mailerMessage))
            {
                return Redirect("Thanks");
            }

            if(mailer.Errors.Count != 0)
            {
                HttpContext.Response.StatusCode = (int) HttpStatusCode.BadRequest;
                return Json("Oh no!! The server gremlins are at it again, they marked your message as spam. Check that your <span>email</span> is valid and that the <span>message</span> don't contain any weird characters. Thanks!");
            }

            HttpContext.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
            return Json(string.Format("Now that's embarrassing. You found a bug! Let's take this off my site, here's email address {0}. Thanks!", MyWebPresence.EmailLink));
        }

        private MailerMessage AppendWhois(MailerMessage mailerMessage)
        {
            //This really isn't important, if it works HURRAY! If not oh well.
            try
            {
                var whois = whoisService.WhoisXml(HttpContext.Request.UserHostAddress);

                mailerMessage.Body += string.Format("\n\n----------\n IP Address: {0}", whois.DomainName);
                if (whois.RegistryData.Registrant != null)
                {
                    mailerMessage.Body += string.Format("\n Organization: {0}\n Country: {1}\n", whois.RegistryData.Registrant.Name, whois.RegistryData.Registrant.Country);
                }
            }
            catch
            {
            }
            return mailerMessage;
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