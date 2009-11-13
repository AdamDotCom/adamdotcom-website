using AdamDotCom.Amazon.Service.Proxy;
using AdamDotCom.Common.Website;
using AdamDotCom.Website.App.Models;

namespace AdamDotCom.Website.App.Services
{
    public class HaveReadListService : CachedService<HaveReadList>
    {
        protected override HaveReadList GetFromService(string id)
        {
            return new HaveReadList(new AmazonService().WishlistByListIdXml(id));
        }
    }
}