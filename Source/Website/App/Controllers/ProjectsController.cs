using System.Web.Mvc;
using AdamDotCom.Common.Website;
using AdamDotCom.OpenSource.Service.Proxy;
using AdamDotCom.Website.App.Extensions;
using AdamDotCom.Website.App.Services;

namespace AdamDotCom.Website.App.Controllers
{
    [HandleError]
    public class ProjectsController : Controller
    {
        private IService<Projects> projectsService;

        public ProjectsController() : this(new ProjectsService()) {}

        public ProjectsController(IService<Projects> projectsService)
        {
            this.projectsService = projectsService;
        }

        [OutputCache(Duration = 172800, VaryByParam = "None")]
        public ActionResult Index(string gitHubId, string googleCodeId)
        {
            string projectHostUsernamePairs = string.Empty;          
            if (!string.IsNullOrEmpty(gitHubId))
            {
                projectHostUsernamePairs += BuildProjectHostUsernamePair(ProjectHost.GitHub, gitHubId);
            }
            if (!string.IsNullOrEmpty(googleCodeId))
            {
                projectHostUsernamePairs += BuildProjectHostUsernamePair(ProjectHost.GoogleCode, googleCodeId);
            }
            
            ViewData.Add(projectsService.Find(projectHostUsernamePairs).Clean().Enhance());

            return View();
        }

        private string BuildProjectHostUsernamePair(ProjectHost projectHost, string username)
        {
            return string.Format("{0}:{1},", projectHost, username);
        }
    }
}