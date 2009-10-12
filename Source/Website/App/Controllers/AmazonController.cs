using System.Web.Mvc;
using AdamDotCom.Website.App.Extensions;
using AdamDotCom.Common.Website;
using AdamDotCom.Website.App.Models;
using AdamDotCom.Amazon.Service.Proxy;

namespace AdamDotCom.Website.App.Controllers
{ 
    [HandleError]
    public class AmazonController : Controller
    {
        internal delegate Reviews FireAndForget(string customerId);
        internal delegate T FireAndForget<T>(string listId);

        public ActionResult Index()
        {
            return Reviews(null);
        }

        public ActionResult Reviews(string customerId)
        {
            customerId = "A2JM0EQJELFL69";

            var reviews = new Reviews().FromLocal();

            if (reviews == null)
            {
                UpdateReviewsService(customerId);
            }
            else if (reviews.IsStale())
            {
                FireAndForget fireAndForget = UpdateReviewsService;
                fireAndForget.BeginInvoke(customerId, null, null);
            }

            ViewData.Add(reviews);

            return View();
        }

        public ActionResult HaveRead(string listId)
        {
            listId = "1XZDXVXHE3946";

            var list = new HaveReadList().FromLocal();

            if (list == null)
            {
                UpdateHaveReadListService(listId);
            }
            else if (list.IsStale())
            {
                FireAndForget<HaveReadList> fireAndForget = UpdateHaveReadListService;
                fireAndForget.BeginInvoke(listId, null, null);
            }

            ViewData.Add(list);

            return View();
        }

        public ActionResult ToRead(string listId)
        {
            listId = "3JU6ASKNUS7B8";

            var list = new ToReadList().FromLocal();

            if (list == null)
            {
                UpdateToReadListService(listId);
            }
            else if (list.IsStale())
            {
                FireAndForget<ToReadList> fireAndForget = UpdateToReadListService;
                fireAndForget.BeginInvoke(listId, null, null);
            }

            ViewData.Add(list);

            return View();
        }

        internal static ToReadList UpdateToReadListService(string listId)
        {
            var list = new ToReadList(new Wishlist().FromService(listId));
            list.SaveLocal();
            return list;
        }

        internal static HaveReadList UpdateHaveReadListService(string listId)
        {
            var list = new HaveReadList(new Wishlist().FromService(listId));
            list.SaveLocal();
            return list;
        }

        internal static Reviews UpdateReviewsService(string customerId)
        {
            var reviews = new Reviews().FromService(customerId);
            reviews.SaveLocal();
            return reviews;
        }
    }
}