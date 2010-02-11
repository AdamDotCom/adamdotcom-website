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
        public ActionResult Index(string gitHubId, string googleCodeId)
        {
            var projects = new Projects();
            if (!string.IsNullOrEmpty(gitHubId))
            {
                projects.AddRange(new GitHubProjectsService().Find(gitHubId));
            }
            if (!string.IsNullOrEmpty(googleCodeId))
            {
                projects.AddRange(new GoogleCodeProjectsService().Find(googleCodeId));
            }
           
            ViewData.Add(projects.RemoveOldDuplicates().Enhance());

            return View();
        }
    }
}