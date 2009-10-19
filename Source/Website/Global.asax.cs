using System.Web.Mvc;
using System.Web.Routing;
using AdamDotCom.Common.Website;

namespace AdamDotCom.Website
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("Resume", "Resume", new { controller = "Resume", action = "Index", id = "Adam-Kahtava" });
            routes.MapRoute("Reviews", "Reviews", new { controller = "Amazon", action = "Reviews", id = "A2JM0EQJELFL69" });
            routes.MapRoute("ToRead", "ToRead", new { controller = "Amazon", action = "ToRead", id = "3JU6ASKNUS7B8" });
            routes.MapRoute("HaveRead", "HaveRead", new { controller = "Amazon", action = "HaveRead", id = "1XZDXVXHE3946" });

            routes.MapRoute("Resume-SEO", "resume/curriculum-vitae/software-developer", new { controller = "Resume", action = "Index", id = "Adam-Kahtava" });
            routes.MapRoute("Reviews-SEO", "reviews/technical-books", new { controller = "Amazon", action = "Reviews", id = "A2JM0EQJELFL69" });
            routes.MapRoute("ReadingLists-SEO", "reading-list/recommended-reading-and-wishlist", new { controller = "Amazon", action = "Reviews", id = "A2JM0EQJELFL69" });

            routes.MapRoute(
                "Default",                                              // Route name
                "{controller}/{action}/{id}",                           // URL with parameters
                new { controller = "Home", action = "Index", id = "" }  // Parameter defaults
                );
        }

        protected void Application_Start()
        {
            RegisterRoutes(RouteTable.Routes);
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new ViewEngine());
        }
    }
}