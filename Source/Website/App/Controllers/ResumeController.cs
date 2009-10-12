using System.Web.Mvc;
using AdamDotCom.Website.App.Extensions;
using AdamDotCom.Common.Website;

namespace AdamDotCom.Website.App.Controllers
{
    using Resume = Resume.Service.Proxy.Resume;

    [HandleError]
    public class ResumeController : Controller
    {
        internal delegate Resume FireAndForget(string firstAndLastname);

        public ActionResult Index(string firstAndLastname)
        {
            firstAndLastname = "Adam-Kahtava";

            var resume = new Resume().FromLocal();

            if (resume == null)
            {
                resume = UpdateResumeFromService(firstAndLastname);
            }
            else if(resume.IsStale())
            {
                FireAndForget fireAndForget = UpdateResumeFromService;
                fireAndForget.BeginInvoke(firstAndLastname, null, null);
            }

            ViewData.Add(resume);

            return View();
        }

        internal static Resume UpdateResumeFromService(string firstAndLastname)
        {
            var resume = new Resume().FromService(firstAndLastname);
            resume.SaveLocal();
            return resume;
        }
    }
}