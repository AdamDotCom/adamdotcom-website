using AdamDotCom.Amazon.Service.Proxy;
using AdamDotCom.Common.Website;

namespace AdamDotCom.Website.App.Services
{
    public class ReviewListService : CachedService<Reviews>
    {
        protected override Reviews GetFromService(string id)
        {
            return new AmazonService().ReviewsByCustomerIdXml(id);
        }
    }
}