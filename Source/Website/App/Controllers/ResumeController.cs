using System.Web.Mvc;
using AdamDotCom.Resume.Service.Proxy;
using AdamDotCom.Common.Website;
using AdamDotCom.Website.App.Extensions;

namespace AdamDotCom.Website.App.Controllers
{
    using Resume = Resume.Service.Proxy.Resume;

    [HandleError]
    public class ResumeController : Controller
    {
        private readonly IRepository repository;
        private readonly IResume resumeService;

        public ResumeController():this(new Repository(), new ResumeService())
        {   
        }

        public ResumeController(IRepository repository, IResume resumeService)
        {
            this.repository = repository;
            this.resumeService = resumeService;
        }

        public ActionResult Index(string id)
        {
            var resume = repository.Find<Resume>();

            if (resume == null)
            {
                resume = UpdateResumeFromService(id);
            }
            else if(repository.IsStale<Resume>())
            {
                new AsynchronousBroker().FireAndForget<Resume>(UpdateResumeFromService, id);
            }

            ViewData.Add(resume);

            return View();
        }

        internal Resume UpdateResumeFromService(string firstAndLastname)
        {
            var resume = resumeService.ResumeXml(firstAndLastname).Enrich();
            repository.Save(resume);
            return resume;
        }
    }
}