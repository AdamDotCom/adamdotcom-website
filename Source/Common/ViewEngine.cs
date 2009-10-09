using System.Web.Mvc;

namespace Common
{
    public class ViewEngine : WebFormViewEngine
    {
        public ViewEngine()
        {
            MasterLocationFormats = new[]
                                        {
                                            "~/App/Views/{1}/{0}.master",
                                            "~/App/Views/Shared/{0}.master"
                                        };
            ViewLocationFormats = new[]
                                      {
                                          "~/App/Views/{1}/{0}.aspx",
                                          "~/App/Views/{1}/{0}.ascx",
                                          "~/App/Views/{0}.aspx",
                                          "~/App/Views/{0}.ascx",
                                          "~/App/Views/Shared/{0}.aspx",
                                          "~/App/Views/Shared/{0}.ascx"
                                      };
            PartialViewLocationFormats = ViewLocationFormats;
        }
    }
}
