using System.Collections.Generic;
using AdamDotCom.Amazon.Service.Proxy;

namespace AdamDotCom.Website.App.Models
{
    public class ToReadList : Wishlist
    {
        public ToReadList()
        {
            
        }
            
        public ToReadList(IEnumerable<Product> wishlist) : base(wishlist)
        {
        }

    }
}