using System.Collections.Generic;
using AdamDotCom.OpenSource.Service.Proxy;

namespace AdamDotCom.Website.App.Models
{
    public class GitHubProjects: Projects
    {
        public GitHubProjects(IEnumerable<Project> projects): base(projects)
        {
        }
    }
}
