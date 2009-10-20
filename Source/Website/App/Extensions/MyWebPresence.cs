namespace AdamDotCom.Website.App.Extensions
{
    public static class MyWebPresence
    {
        private static string AccountHandle1 { get { return "AdamDotCom"; } }
        private static string AccountHandle2 { get { return "Kahtava"; } }

        public static string EmailAccount { get { return "<a href=\"mailto:adam@kahtava.com?subject=Hey Adam, I was on your site and...\">adam@kahtava.com</a>"; } }
        public static string GitHubAccount { get { return string.Format("<a href=\"http://github.com/{0}\">my GitHub repository</a>", AccountHandle1); } }
        public static string TwitterAccount { get { return string.Format("<a href=\"http://twitter.com/{0}\">{0}</a>", AccountHandle1); } }
        public static string FacebookAccount { get { return string.Format("<a href=\"http://www.facebook.com/{0}\">{0}</a>", AccountHandle2); } }
        public static string DeliciousAccount { get { return string.Format("<a href=\"http://delicious.com/{0}\">{0}</a>", AccountHandle2); } }
        public static string GoogleCodeAccount { get { return string.Format("<a href=\"http://code.google.com/u/adam.kahtava.com/\">{0}</a>", "my source code on Google Code"); } }
        public static string FriendfeedAccount { get { return string.Format("<a href=\"http://friendfeed.com/{0}\">{0}</a>", AccountHandle1); } }
        public static string FlickrAccount { get { return string.Format("<a href=\"http://www.flickr.com/photos/{0}/\">{0}</a>", AccountHandle2); } }
        public static string LinkedInAccount { get { return string.Format("<a href=\"http://www.linkedin.com/pub/adam-kahtava/3/405/466\">{0}</a>", "my LinkedIn profile"); } }
        public static string AmazonAccount { get { return string.Format("<a href=\"http://www.amazon.com/gp/pdp/profile/A2JM0EQJELFL69\">{0}</a>", "my profile on Amazon"); } }
        public static string StackoverflowAccount { get { return string.Format("<a href=\"http://stackoverflow.com/users/1778/adam-kahtava\">{0}</a>", "my profile on Stackoverflow"); } }
        public static string PublicCalendar { get { return string.Format("<a href=\"http://www.google.com/calendar/embed?src=kahtava.com_3b7tc69opbskf5cqgjflihhqpk@group.calendar.google.com\">{0}</a>", "my calendar of local events"); } }
        public static string SkypeAccount { get { return string.Format("<a href=\"callto://Adam.Kahtava.com\">{0}</a>", "call me on Skype"); } }
    }
}
