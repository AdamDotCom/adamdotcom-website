using AdamDotCom.Common.Website;
using AdamDotCom.OpenSource.Service.Proxy;
using AdamDotCom.Website.App.Models;

namespace AdamDotCom.Website.App.Services
{
    public class GoogleCodeProjectsService : CachedService<GoogleCodeProjects>
    {
        protected override GoogleCodeProjects GetFromService(string id)
        {
            return new GoogleCodeProjects(new OpenSourceService().GetProjectsByUsernameXml(ProjectHost.GoogleCode.ToString(), id));
        }
    }
}
