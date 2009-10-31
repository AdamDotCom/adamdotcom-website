using System.Web.Mvc;
using System.Web.Routing;
using AdamDotCom.Common.Website;

namespace AdamDotCom.Website
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapRoute("Resume", "Resume", new { controller = "Resume", action = "Index", id = "Adam-Kahtava" });
            routes.MapRoute("Reviews", "Reviews", new { controller = "Amazon", action = "Reviews", id = "A2JM0EQJELFL69" });
            routes.MapRoute("ReadingLists", "ReadingLists", new
                                                           {
                                                               controller = "Amazon",
                                                               action = "ReadingLists",
                                                               haveReadListId = "3JU6ASKNUS7B8",
                                                               toReadListId = "1XZDXVXHE3946"
                                                           });

            routes.MapRoute("Resume-SEO", "resume/curriculum-vitae/software-developer", new { controller = "Resume", action = "Index", id = "Adam-Kahtava" });
            routes.MapRoute("Reviews-SEO", "book-reviews", new { controller = "Amazon", action = "Reviews", id = "A2JM0EQJELFL69" });
            routes.MapRoute("ReadingLists-SEO", "reading-lists/recommended-and-wishlist",
                            new
                                {
                                    controller = "Amazon",
                                    action = "ReadingLists",
                                    haveReadListId = "3JU6ASKNUS7B8",
                                    toReadListId = "1XZDXVXHE3946"
                                });
            routes.MapRoute("ContactMe-SEO", "contact-me", new {controller = "Contact", action = "Index"});

            routes.Add("Default", new RouteExtensions("{controller}/{action}/{id}",
                                  new RouteValueDictionary(
                                      new { controller = "Resume", action = "Index", id = "Adam-Kahtava" }) // Parameter defaults
                                  , new MvcRouteHandler()));
        }

        protected void Application_Start()
        {
            RegisterRoutes(RouteTable.Routes);
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new ViewEngine());
        }
    }
}