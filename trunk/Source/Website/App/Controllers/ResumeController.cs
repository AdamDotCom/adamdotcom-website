using System;
using System.Runtime.Remoting.Messaging;
using System.Web.Mvc;
using AdamDotCom.Resume.Service.Proxy;
using AdamDotCom.Website.App.Helpers;

namespace AdamDotCom.Website.App.Controllers
{
    using Resume = Resume.Service.Proxy.Resume;

    [HandleError]
    public class ResumeController : Controller
    {
        public ActionResult Index(string firstnameAndLastname)
        {
            var resume = new Resume().FromLocal();

            if (resume == null)
            {
                resume = new Resume().FromService(firstnameAndLastname);
            }
            else if(resume.IsStale())
            {
                var callback = new AsyncCallback(AsyncServiveCall);
            }

            ViewData["Resume"] = resume;

            return View();
        }

        private static void AsyncServiveCall(IAsyncResult asyncResult)
        {
            var resume = new Resume().FromService("");
            if (resume != null)
            {
                resume.SaveLocal();
            }
        }

        public ActionResult About()
        {
            return View();
        }
    }
}