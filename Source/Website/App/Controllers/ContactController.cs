using System.Net;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using AdamDotCom.Common.Website;
using AdamDotCom.Website.App.Extensions;
using AdamDotCom.Whois.Service.Proxy;

namespace AdamDotCom.Website.App.Controllers
{
    [HandleError]
    public class ContactController : Controller
    {
        private readonly IWhois whoisService;
        private readonly IMailer mailer;

        public ContactController() : this(new WhoisService(), new Mailer()) {}

        public ContactController(IWhois whoisService, IMailer mailer)
        {
            this.whoisService = whoisService;
            this.mailer = mailer;
        }

        public ActionResult Thanks()
        {
            return View();
        }

        public ActionResult IsFriendly()
        {
            if (HttpContext.Request != null)
            {
                var ipAddress = HttpContext.Request.UserHostAddress;
                var referrer = (HttpContext.Request.UrlReferrer != null) ? HttpContext.Request.UrlReferrer.ToString() : string.Empty;

                var whois = whoisService.WhoisEnhancedXml(ipAddress, "Canada,Calgary,Alberta", referrer);

                if (whois.IsFriendly || whois.IsFilterMatch)
                {
                    return Content(string.Format("mailto:{0}?subject=I found your site and...", MyWebPresence.EmailAccount));
                }
            }

            Response.StatusCode = (int) HttpStatusCode.BadRequest;
            return Content("Unknown");
        }

        public ActionResult Index()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post), ValidateAntiForgeryToken, ValidateInput(false)]  
        public ActionResult Send()
        {
            MailerMessage mailerMessage = GetMailerMessage();

            if(!mailerMessage.IsValid())
            {
                HttpContext.Response.StatusCode = (int) HttpStatusCode.NotAcceptable;
                return Content("Your <span>email</span> and <span>message</span> are required, ensure those fields are correct. Then try, try, try again.");
            }

            mailerMessage.AppendWhois(whoisService, HttpContext.Request.UserHostAddress);

            if(mailer.Send(mailerMessage))
            {
                return RedirectToAction("Thanks");
            }

            if(mailer.Errors.Count != 0)
            {
                HttpContext.Response.StatusCode = (int) HttpStatusCode.BadRequest;
                return Content("The server gremlins are at it again! they marked your message as spam. Check that your <span>email</span> is valid and that the <span>message</span> doesn't contain any weird characters. Thanks!");
            }

            HttpContext.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
            return Content(string.Format("Now that's embarrassing. You found a bug! Let's take this off my site, here's email address {0}. Thanks!", MyWebPresence.EmailLink));
        }

        private MailerMessage GetMailerMessage()
        {
            var mailerMessage = new MailerMessage();
            TryUpdateModel(mailerMessage);
            mailerMessage.Subject = string.Format("Adam.Kahtava.com response :: {0}", mailerMessage.Subject);
            mailerMessage.ToAddress = MyWebPresence.EmailAccount;
            mailerMessage.ToName = MyWebPresence.FullName;
            return mailerMessage;
        }
    }
}   