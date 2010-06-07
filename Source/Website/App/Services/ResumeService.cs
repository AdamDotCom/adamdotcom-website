using AdamDotCom.Common.Website;
using AdamDotCom.Website.App.Extensions;

namespace AdamDotCom.Website.App.Services
{
    using Resume = Resume.Service.Proxy.Resume;

    public class ResumeService: CachedService<Resume>
    {
        protected override Resume GetFromService(string id)
        {
            return new AdamDotCom.Resume.Service.Proxy.ResumeService().ResumeXml(id).Enrich();
        }
    }
}