using System.Web.Mvc;
using AdamDotCom.Common.Website;
using AdamDotCom.Website.App.Services;

namespace AdamDotCom.Website.App.Controllers
{
    [HandleError]
    public class AmazonController : Controller
    {
        [OutputCache(Duration = 172800, VaryByParam = "None")]
        public ActionResult Reviews(string id)
        {
            ViewData.Add(new ReviewListService().Find(id));

            return View();
        }

        [OutputCache(Duration = 172800, VaryByParam = "None")]
        public ActionResult ReadingLists(string haveReadListId, string toReadListId)
        {
            ViewData.Add(new HaveReadListService().Find(haveReadListId));
            ViewData.Add(new ToReadListService().Find(toReadListId));

            return View();
        }
    }
}