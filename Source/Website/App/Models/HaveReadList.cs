using System.Collections.Generic;
using AdamDotCom.Amazon.Domain;
using AdamDotCom.Amazon.Service.Proxy;

namespace AdamDotCom.Website.App.Models
{
    public class HaveReadList: Wishlist
    {
        public HaveReadList()
        {
        }

        public HaveReadList(IEnumerable<Product> wishlist) : base(wishlist)
        {
        }
    }
}