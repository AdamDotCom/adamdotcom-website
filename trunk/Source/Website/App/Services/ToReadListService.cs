using AdamDotCom.Amazon.Service.Proxy;
using AdamDotCom.Common.Website;
using AdamDotCom.Website.App.Models;

namespace AdamDotCom.Website.App.Services
{
    public class ToReadListService : CachedService<ToReadList>
    {
        protected override ToReadList GetFromService(string id)
        {
            return new ToReadList(new AmazonService().WishlistByListIdXml(id));
        }
    }
}