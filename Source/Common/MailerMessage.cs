using System.Text.RegularExpressions;

namespace AdamDotCom.Common.Website
{
    public class MailerMessage
    {
        private string _body;
        
        public string ToAddress { get; set; }
        public string ToName { get; set; }
        public string FromAddress { get; set; }
        public string FromName { get; set; }
        public string Body
        {
            get { return StripHtml(_body); }
            set { _body = value; }
        }

        public string Subject { get; set; }

        //ToDo: simplified validation, look into extending this to include when the from address etc... are missing
        public bool IsValid()
        {
            if (!string.IsNullOrEmpty(FromAddress) && !string.IsNullOrEmpty(Body))
            {
                if (FromAddress.Contains("@") && FromAddress.Contains("."))
                {
                    return true;
                }
            }
            return false;
        }

        private static string StripHtml(string htmlText)
        {
            if (string.IsNullOrEmpty(htmlText))
            {
                return string.Empty;
            }
            htmlText = htmlText.Replace("<br>", "\n");
            htmlText = htmlText.Replace("&nbsp;", " ");
            htmlText = Regex.Replace(htmlText, @"<.*?>", string.Empty);
            return htmlText;
        }
    }
}