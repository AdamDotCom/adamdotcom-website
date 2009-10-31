using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AdamDotCom.Common.Website
{
    public class RouteExtensions: Route
    {
        public RouteExtensions(string url, IRouteHandler routeHandler) : base(url, routeHandler)
        {
        }

        public RouteExtensions(string url, RouteValueDictionary defaults, IRouteHandler routeHandler) : base(url, defaults, routeHandler)
        {
        }

        public RouteExtensions(string url, RouteValueDictionary defaults, RouteValueDictionary constraints, IRouteHandler routeHandler) : base(url, defaults, constraints, routeHandler)
        {
        }

        public RouteExtensions(string url, RouteValueDictionary defaults, RouteValueDictionary constraints, RouteValueDictionary dataTokens, IRouteHandler routeHandler) : base(url, defaults, constraints, dataTokens, routeHandler)
        {
        }

        public override VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary values)
        {
            //Lowercase routes
            //Referenced from: http://odetocode.com/Blogs/scott/archive/2009/10/01/lower-case-urls-and-asp-net-mvc.aspx
            var virtualPathData = base.GetVirtualPath(requestContext, values);

            if(virtualPathData != null)
            {
                virtualPathData.VirtualPath = virtualPathData.VirtualPath.ToLowerInvariant();
            }

            return virtualPathData;
        }

        public override RouteData GetRouteData(HttpContextBase httpContext)
        {
            //Dealing with sub domains
            /*
             * This feels a little hacky, my site serves different content when in the root (kahtava.com) than in my sub domain (adam.kahtava.com)
             * since I'm retrofitting my site to use MVC I'll leave the structure as is
             */
            //ToDo: move this into a IIS or ISAPI redirect
            var host = httpContext.Request.Url.Host;

            if (host.ToLowerInvariant().Equals("www.kahtava.com") || host.ToLowerInvariant().Equals("kahtava.com"))
            {
                httpContext.Server.Transfer("index.html");
                return null;
            }

            return base.GetRouteData(httpContext);
        }
    }
}