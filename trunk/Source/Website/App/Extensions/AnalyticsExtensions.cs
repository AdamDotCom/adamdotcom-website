using System.Text;
using System.Web.Mvc;

namespace AdamDotCom.Website.App.Extensions
{
    public static class AnalyticsExtensions
    {
        public static string AnalyticsTag(this HtmlHelper htmlHelper)
        {
            var tagBuilder = new StringBuilder();

            tagBuilder.Append("<script type=\"text/javascript\">");
            tagBuilder.Append("var gaJsHost = ((\"https:\" == document.location.protocol) ? \"https://ssl.\" : \"http://www.\");");
            tagBuilder.Append("document.write(unescape(\"%3Cscript src='\" + gaJsHost + \"google-analytics.com/ga.js' type='text/javascript'%3E%3C/script%3E\"));");
            tagBuilder.Append("</script>");
            tagBuilder.Append("<script type=\"text/javascript\">");
            tagBuilder.Append("var pageTracker = _gat._getTracker(\"UA-3536292-1\");");
            tagBuilder.Append("pageTracker._initData();");
            tagBuilder.Append("pageTracker._trackPageview();");
            tagBuilder.Append("</script>");

            return tagBuilder.ToString();
        }
    }
}