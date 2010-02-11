using System.Collections.Generic;
using AdamDotCom.OpenSource.Service.Proxy;

namespace AdamDotCom.Website.App.Models
{
    public class GoogleCodeProjects: Projects
    {
        public GoogleCodeProjects(IEnumerable<Project> projects) : base(projects)
        {
        }
    }
}
