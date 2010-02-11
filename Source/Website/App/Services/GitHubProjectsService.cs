using AdamDotCom.Common.Website;
using AdamDotCom.OpenSource.Service.Proxy;
using AdamDotCom.Website.App.Models;

namespace AdamDotCom.Website.App.Services
{
    public class GitHubProjectsService : CachedService<GitHubProjects>
    {
        protected override GitHubProjects GetFromService(string id)
        {
            return new GitHubProjects(new OpenSourceService().GetProjectsByUsernameXml(ProjectHost.GitHub.ToString(), id));
        }
    }
}
