namespace AdamDotCom.Website.App
{
    public static class MyWebPresence
    {
        private static string AccountHandle1 { get { return "AdamDotCom"; } }
        private static string AccountHandle2 { get { return "Kahtava"; } }
        public static string EmailAccount { get { return "adam@kahtava.com"; } }
        public static string FullName { get { return "Adam Kahtava"; } }
        public static string SiteName { get { return "Adam.Kahtava.com / AdamDotCom"; } }

        public static string EmailLink { get { return string.Format("<a href=\"mailto:{0}?subject=Hey Adam, I was on your site and...\">{0}</a>", EmailAccount); } }
        public static string GitHubLink { get { return string.Format("<a href=\"http://github.com/{0}\">my GitHub repository</a>", AccountHandle1); } }
        public static string TwitterLink { get { return string.Format("<a href=\"http://twitter.com/{0}\">{0}</a>", AccountHandle1); } }
        public static string FacebookLink { get { return string.Format("<a href=\"http://www.facebook.com/{0}\">{0}</a>", AccountHandle2); } }
        public static string DeliciousLink { get { return string.Format("<a href=\"http://delicious.com/{0}\">{0}</a>", AccountHandle2); } }
        public static string GoogleCodeLink { get { return string.Format("<a href=\"http://code.google.com/u/adam.kahtava.com/\">{0}</a>", "my source code on Google Code"); } }
        public static string FriendfeedLink { get { return string.Format("<a href=\"http://friendfeed.com/{0}\">{0}</a>", AccountHandle1); } }
        public static string FlickrLink { get { return string.Format("<a href=\"http://www.flickr.com/photos/{0}/\">{0}</a>", AccountHandle2); } }
        public static string LinkedInLink { get { return string.Format("<a href=\"http://www.linkedin.com/pub/adam-kahtava/3/405/466\">{0}</a>", "my LinkedIn profile"); } }
        public static string AmazonLink { get { return string.Format("<a href=\"http://www.amazon.com/gp/pdp/profile/A2JM0EQJELFL69\">{0}</a>", "my profile on Amazon"); } }
        public static string StackoverflowLink { get { return string.Format("<a href=\"http://stackoverflow.com/users/1778/adam-kahtava\">{0}</a>", "my profile on Stackoverflow"); } }
        public static string PublicLink { get { return string.Format("<a href=\"http://www.google.com/calendar/embed?src=kahtava.com_3b7tc69opbskf5cqgjflihhqpk@group.calendar.google.com\">{0}</a>", "my calendar of local events"); } }
        public static string SkypeLink { get { return string.Format("<a href=\"callto://Adam.Kahtava.com\">{0}</a>", "call me on Skype"); } }
    }
}