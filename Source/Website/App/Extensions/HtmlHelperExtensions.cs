using System.Web.Mvc;

namespace AdamDotCom.Website.App.Extensions
{
    public static class HtmlHelperExtensions
    {
        private const string rootPath = "/public";

        public static string ImagePath(this HtmlHelper htmlHelper, string imageName)
        {
            return string.Format("{0}/images/{1}", rootPath, imageName);
        }

        public static string StylesheetPath(this HtmlHelper htmlHelper, string stylesheetName)
        {
            return string.Format("{0}/stylesheets/{1}", rootPath, stylesheetName);
        }

        public static string JavaScriptPath(this HtmlHelper htmlHelper, string javaScriptName)
        {
            return string.Format("{0}/javascripts/{1}", rootPath, javaScriptName);
        }
    }
}
