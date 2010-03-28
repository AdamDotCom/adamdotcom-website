using System.Collections.Generic;
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

            var urls = new List<string>();
            var match = new Regex(@"href=([""']+)(?<Url>(([^""'])+))").Match(htmlText);
            while(match.Success)
            {
                urls.Add(match.Groups["Url"].Captures[0].Value);
                match = match.NextMatch();
            }

            var urlPlaceholder = "-url-";
            htmlText = Regex.Replace(htmlText, @"<a.*?>", urlPlaceholder);
            htmlText = Regex.Replace(htmlText, @"<.*?>", string.Empty);

            int location = 0;
            foreach (var url in urls)
            {   
                location = htmlText.IndexOf(urlPlaceholder, location);
                if(location == -1)
                {
                    break;
                }
                htmlText = htmlText.Remove(location, urlPlaceholder.Length);
                htmlText = htmlText.Insert(location, string.Format(" ({0}) ", url));
            }

            return htmlText;
        }
    }
}