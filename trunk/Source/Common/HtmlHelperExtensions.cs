using System.Text;
using System.Web.Mvc;

namespace AdamDotCom.Common.Website
{
    public static class HtmlHelperExtensions
    {
        private const string javaScriptPath = "javascripts";
        private const string rootAssetPath = "public";
        private const string styleSheetPath = "stylesheets";

        public static string ImagePath(this HtmlHelper htmlHelper, string imageName)
        {
            return string.Format("{0}/images/{1}", rootAssetPath, imageName);
        }

        //Some extensions to mimic the Rails way
        //<%= javascript_include_tag :defaults %>
        public static string JavaScriptIncludeTag(this HtmlHelper htmlHelper, string scriptName)
        {
            return JavaScriptIncludeTag(scriptName);
        }

        public static string JavaScriptIncludeTag(this HtmlHelper htmlHelper, params string[] scriptNames)
        {
            var tagBuilder = new StringBuilder();
            foreach (string script in scriptNames)
            {
                tagBuilder.Append(JavaScriptIncludeTag(script));
            }
            return tagBuilder.ToString();
        }

        private static string JavaScriptIncludeTag(string scriptName)
        {
            return string.Format("<script src=\"/{0}/{1}/{2}.js\" type=\"text/javascript\"></script>", rootAssetPath, javaScriptPath, scriptName);
        }

        //Some extensions to mimic the Rails way
        //<%= stylesheet_link_tag "depot" , :media => "all" %>
        public static string StylesheetLinkTag(this HtmlHelper htmlHelper, string stylesheetName)
        {
            return StylesheetLinkTag(htmlHelper, stylesheetName, null);
        }

        public static string StylesheetLinkTag(this HtmlHelper htmlHelper, string stylesheetName, string mediaType)
        {
            return StylesheetLinkTag(stylesheetName, mediaType);
        }

//        public static string StylesheetLinkTag(this HtmlHelper htmlHelper, params string[] stylesheets)
//        {
//            return StylesheetLinkTag(htmlHelper, stylesheets, null);
//        }

        public static string StylesheetLinkTag(this HtmlHelper htmlHelper, params string[] stylesheets)
        {
            string mediaType = "all";
            var tagBuilder = new StringBuilder();
            foreach (string stylesheet in stylesheets)
            {
                tagBuilder.Append(StylesheetLinkTag(stylesheet, mediaType));
            }
            return tagBuilder.ToString();
        }

        private static string StylesheetLinkTag(string stylesheetName, string mediaType)
        {
            return string.Format("<link href=\"/{0}/{1}/{2}.css\" rel=\"stylesheet\" type=\"text/css\" media=\"{3}\" />", rootAssetPath, styleSheetPath, stylesheetName, string.IsNullOrEmpty(mediaType) ? "all" : mediaType);
        }
    }
}