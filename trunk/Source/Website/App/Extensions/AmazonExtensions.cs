using AdamDotCom.Amazon.Service.Proxy;

namespace AdamDotCom.Website.App.Extensions
{
    public static class AmazonExtensions
    {
        public static Reviews FromService(this Reviews reviews, string customerId)
        {
            return new AmazonService().ReviewsByCustomerIdXml((customerId));
        }

        public static Reviews FromLocal(this Reviews reviews)
        {
            return DataExtensions.Load(reviews) as Reviews;
        }

        public static void SaveLocal(this Reviews reviews)
        {
            DataExtensions.Save(reviews);
        }

        public static bool IsStale(this Reviews reviews)
        {
            return DataExtensions.IsStale(reviews);
        }

        public static Wishlist FromService(this Wishlist wishlist, string listId)
        {
            return new AmazonService().WishlistByListIdXml(listId);
        }

        public static T FromLocal<T>(this T wishlist)
        {
            return (T)DataExtensions.Load(wishlist);
        }

        public static void SaveLocal<T>(this T wishlist)
        {
            DataExtensions.Save(wishlist);
        }

        public static bool IsStale<T>(this T wishlist)
        {
            return DataExtensions.IsStale(wishlist);
        }
    }
}
