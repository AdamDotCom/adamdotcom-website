using AdamDotCom.Amazon.Service.Proxy;

namespace AdamDotCom.Website.App.Extensions
{
    public static class AmazonExtensions
    {
        public static Reviews FromService(this Reviews reviews, string customerId)
        {
            return new AmazonService().ReviewsByCustomerIdXml((customerId));
        }

        public static Wishlist FromService(this Wishlist wishlist, string listId)
        {
            return new AmazonService().WishlistByListIdXml(listId);
        }
    }
}
