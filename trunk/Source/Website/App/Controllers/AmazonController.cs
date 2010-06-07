using System.Web.Mvc;
using AdamDotCom.Amazon.Service.Proxy;
using AdamDotCom.Common.Website;
using AdamDotCom.Website.App.Models;
using AdamDotCom.Website.App.Services;

namespace AdamDotCom.Website.App.Controllers
{
    [HandleError]
    public class AmazonController : Controller
    {
        private IService<HaveReadList> haveReadListService;
        private IService<ToReadList> toReadListService;
        private IService<Reviews> reviewListService;

        public AmazonController(): this(new HaveReadListService(), new ToReadListService(), new ReviewListService()) {}

        public AmazonController(IService<HaveReadList> haveReadListService, IService<ToReadList> toReadListService, IService<Reviews> reviewListService)
        {
            this.haveReadListService = haveReadListService;
            this.toReadListService = toReadListService;
            this.reviewListService = reviewListService;
        }
        
        [OutputCache(Duration = 172800, VaryByParam = "None")]
        public ActionResult Reviews(string id)
        {
            ViewData.Add(reviewListService.Find(id));

            return View();
        }

        [OutputCache(Duration = 172800, VaryByParam = "None")]
        public ActionResult ReadingLists(string haveReadListId, string toReadListId)
        {
            ViewData.Add(haveReadListService.Find(haveReadListId));
            ViewData.Add(toReadListService.Find(toReadListId));

            return View();
        }
    }
}