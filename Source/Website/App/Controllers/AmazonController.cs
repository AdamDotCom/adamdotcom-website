using System.Linq;
using System.Web.Mvc;
using AdamDotCom.Website.App.Models;
using AdamDotCom.Amazon.Service.Proxy;
using AdamDotCom.Common.Website;

namespace AdamDotCom.Website.App.Controllers
{ 
    [HandleError]
    public class AmazonController : Controller
    {
        private readonly IRepository repository;
        private readonly IAmazon amazonService;
        private readonly AsynchronousBroker asynchronousBroker;

        public AmazonController():this(new Repository(), new AmazonService())
        {
            asynchronousBroker = new AsynchronousBroker();
        }

        public AmazonController(IRepository repository, IAmazon amazonService)
        {
            asynchronousBroker = new AsynchronousBroker();
            this.repository = repository;
            this.amazonService = amazonService;
        }

        public ActionResult Index()
        {
            return Reviews(null);
        }

        public ActionResult Reviews(string id)
        {
            var reviews = repository.Find<Reviews>();

            if (reviews == null)
            {
                reviews = UpdateReviewsService(id);
            }
            else if (repository.IsStale<Reviews>())
            {
                asynchronousBroker.FireAndForget<Reviews>(UpdateReviewsService, id);
            }

            ViewData.Add(reviews);

            return View();
        }

        public ActionResult ReadingLists(string haveReadListId, string toReadListId)
        {
            HaveRead(haveReadListId);
            ToRead(toReadListId);

            return View();
        }

        public void HaveRead(string id)
        {
            var list = repository.Find<HaveReadList>();

            if (list == null)
            {
                list = UpdateHaveReadListService(id);
            }
            else if (repository.IsStale<HaveReadList>())
            {
                asynchronousBroker.FireAndForget<HaveReadList>(UpdateHaveReadListService, id);
            }

            ViewData.Add(list);
        }

        public void ToRead(string id)
        {
            var list = repository.Find<ToReadList>();

            if (list == null)
            {
                list = UpdateToReadListService(id);
            }
            else if (repository.IsStale<ToReadList>())
            {
                asynchronousBroker.FireAndForget<ToReadList>(UpdateToReadListService, id);
            }

            ViewData.Add(list);
        }

        internal ToReadList UpdateToReadListService(string listId)
        {
            var list = new ToReadList(amazonService.WishlistByListIdXml(listId));
            repository.Save(list);
            return list;
        }

        internal HaveReadList UpdateHaveReadListService(string listId)
        {
            var list = new HaveReadList(amazonService.WishlistByListIdXml(listId));
            repository.Save(list);
            return list;
        }

        internal Reviews UpdateReviewsService(string customerId)
        {
            var reviews = amazonService.ReviewsByCustomerIdXml(customerId);
            repository.Save(reviews);
            return reviews;
        }
    }
}