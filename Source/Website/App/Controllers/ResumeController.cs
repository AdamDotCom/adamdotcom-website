using System.Web.Mvc;
using AdamDotCom.Common.Website;
using AdamDotCom.Website.App.Services;

namespace AdamDotCom.Website.App.Controllers
{
    using Resume = Resume.Service.Proxy.Resume;

    [HandleError]
    public class ResumeController : Controller
    {
        private IService<Resume> resumeService;

        public ResumeController() : this(new ResumeService()) {}

        public ResumeController(IService<Resume> resumeService)
        {
            this.resumeService = resumeService;
        }

        [OutputCache(Duration = 172800, VaryByParam = "None")]
        public ActionResult Index(string id)
        {
            return View(resumeService.Find(id));
        }
    }
}