using AdamDotCom.Common.Website;
using AdamDotCom.OpenSource.Service.Proxy;

namespace AdamDotCom.Website.App.Services
{
    public class ProjectsService : CachedService<Projects>
    {
        protected override Projects GetFromService(string id)
        {
            return new Projects(new OpenSourceService().GetProjectsByProjectHostAndUsernameXml(id, "remove:adamdotcom,duplicate-items,-,empty-items"));
        }
    }
}
