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

        public ContactController() : this(new WhoisService()) {}

        public ContactController(IWhois whoisService)
        {
            this.whoisService = whoisService;
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
                    return Content(MyWebPresence.EmailAccount);
                }
            }

            Response.StatusCode = (int) HttpStatusCode.BadRequest;
            return null;
        }

        public ActionResult Index()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post), ValidateAntiForgeryToken, ValidateInput(false)]  
        public ActionResult Send()
        {
            var mailerMessage = new MailerMessage();
            TryUpdateModel(mailerMessage);

            mailerMessage.Body = mailerMessage.Body;
            mailerMessage.Subject = string.Format("Adam.Kahtava.com response :: {0}", mailerMessage.Subject);
            mailerMessage.ToAddress = MyWebPresence.EmailAccount;
            mailerMessage.ToName = MyWebPresence.FullName;

            if(!mailerMessage.IsValid())
            {
                HttpContext.Response.StatusCode = (int) HttpStatusCode.NotAcceptable;
                return Content("The <span>email</span> and <span>message</span> ensure those fields are correct. Then try, try, try again.");
            }

            mailerMessage.AppendWhois(whoisService, HttpContext.Request.UserHostAddress);

            var mailer = new Mailer();

            if(mailer.Send(mailerMessage))
            {
                return RedirectToAction("Thanks");
            }

            if(mailer.Errors.Count != 0)
            {
                HttpContext.Response.StatusCode = (int) HttpStatusCode.BadRequest;
                return Content("The server gremlins are at it again! they marked your message as spam. Check that your <span>email</span> is valid and that the <span>message</span> don't contain any weird characters. Thanks!");
            }

            HttpContext.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
            return Content(string.Format("Now that's embarrassing. You found a bug! Let's take this off my site, here's email address {0}. Thanks!", MyWebPresence.EmailLink));
        }
    }
}