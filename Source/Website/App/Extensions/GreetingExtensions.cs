using System;
using System.Collections.Generic;
using System.Globalization;
using AdamDotCom.Website.App.Models;
using AdamDotCom.Whois.Service.Proxy;

namespace AdamDotCom.Website.App.Extensions
{
    public static class GreetingExtensions
    {
        public static Greeting Translate(this Greeting greeting, WhoisEnhancedRecord whois)
        {
            var msg = "";
            if(whois.IsFriendly)
            {
                msg = string.Format(
                    "Cool! Do you work for {0}? Please feel free to contact me via email at {1}, {2}, or visit {3}. I look forward to talking soon!",
                    whois.FriendlyMatches[0].Capitalize(), MyWebPresence.EmailAccount, MyWebPresence.SkypeAccount, MyWebPresence.LinkedInAccount);
            }
            else if (whois.IsFilterMatch)
            {
                if (whois.IsFilterMatch("calgary") || whois.IsFilterMatch("alberta"))
                {
                    msg = string.Format(
                        "Howdy there! Looks like we both live in Alberta. You might be interested in {0} or you could always send me an email ({1})",
                        MyWebPresence.PublicCalendar, MyWebPresence.EmailAccount);
                }
            }
            else if (whois.IsReferrerMatch)
            {
                if (whois.IsReferrerMatch("twitter"))
                {
                    msg = string.Format(
                        "{0} Are we Twitter buddies? If not, be sure to add me ({1}) as a contact! Heck, here's my Facebook ({2}) and my FriendFeed ({3}) details too. See you in the Twittersphere. :)",
                        Prefix(), MyWebPresence.TwitterAccount, MyWebPresence.FacebookAccount, MyWebPresence.FriendfeedAccount);
                }
                else if (whois.IsReferrerMatch("github"))
                {
                    msg = string.Format(
                        "{0} Isn't Git just the bees knees? Since you're visiting from Git you're probably also interested in {1}. {2}",
                        Prefix(), MyWebPresence.GoogleCodeAccount, Postfix());
                }
                else if (whois.IsReferrerMatch("linkedin") || whois.IsReferrerMatch("monster"))
                {
                    msg = string.Format(
                        "Hello! Thanks for visiting my site. Feel free to contact me via email at {0} or {1}. I look forward to talking with you soon!",
                        MyWebPresence.EmailAccount, MyWebPresence.SkypeAccount);
                }
                else if (whois.IsReferrerMatch("delicious"))
                {
                    msg = string.Format(
                        "Man, you gotta love the Delicious bookmarking service. Are we contacts yet? If not be sure to add me ({0}). Oh, and if you're using Twitter add me ({1}) there too. {2}",
                        MyWebPresence.DeliciousAccount, MyWebPresence.TwitterAccount, Postfix());
                }
                else if (whois.IsReferrerMatch("friendfeed"))
                {
                    msg = string.Format(
                        "{0} You might also be interested in visiting {1}. {2}",
                        Prefix(), MyWebPresence.LinkedInAccount, Postfix());
                }
                else if (whois.IsReferrerMatch("facebook"))
                {
                    msg = string.Format(
                        "{0} Not much to see around here, just my geeky ramblings. If you're using Twitter be sure to add me ({1}). {2}",
                        Prefix(), MyWebPresence.TwitterAccount, Postfix());
                }
                else if (whois.IsReferrerMatch("code.google"))
                {
                    msg = string.Format(
                        "{0} Feel free to contact me ({1}} I'm always looking for feedback on my code. Oh yeah, while you're here take a look at {2}.",
                        Prefix(), MyWebPresence.EmailAccount, Postfix());
                }
                else if (whois.IsReferrerMatch("mail.google"))
                {
                    msg = string.Format(
                        "Thanks for looking me up. Why not {0} or send me ({1}) an email. :)",
                        MyWebPresence.SkypeAccount, MyWebPresence.EmailAccount);
                }
                else if (whois.IsReferrerMatch("stackoverflow") || whois.IsReferrerMatch("odetocode") || whois.IsReferrerMatch("asp.net"))
                {
                    msg = string.Format(
                        "{0} Be sure take a peek at {1} or {2}. Drop me {3} a line in the Twittersphere. {4}",
                        Prefix(), MyWebPresence.GoogleCodeAccount, MyWebPresence.GitHubAccount, MyWebPresence.TwitterAccount, Postfix());
                }
            }
            else
            {
                msg = string.Format("{0} {1}", Prefix(), Postfix());
            }
            return new Greeting { Message = msg };
        }

        public static string Prefix()
        {
            string[] greetingStart = {
                                         "Hey!", 
                                         "Welcome to my site. :)", 
                                         "Hello...", 
                                         "What's cooking?",
                                         "Toto, I've a feeling we're not in Kansas any more. Welcome to my site!",
                                         "Dooood!!",
                                         "How in the world did you end up here?",
                                         "So you got here? Now what! :)",
                                         "Huzzah! Huzzah! Huzzah!", 
                                         "Giddyup!",
                                         "Vargas!", 
                                         "Helloio!",
                                         "It's great to have you here!"
                                     };

            return greetingStart[RandomNumber(greetingStart)];
        }

        public static string Postfix()
        {
            string[] greetingEnd = {
                                       "Why don't you pop in again.", 
                                       "See you again.",
                                       "Hope to see you around here more often.", 
                                       "Thanks for stopping by! :)",
                                       "You should stop by here more often.",
                                       "Why not bookmark this site? Wait a second, who uses bookmarks anymore? :)",
                                       "Here-here, visit again! :)",
                                       "Enjoy the site!",
                                       "Cheers!",
                                       "Y'all come back now! :)"
                                   };
            return greetingEnd[RandomNumber(greetingEnd)];
        }

        public static int RandomNumber(ICollection<string> collection)
        {
            var maxlength = collection.Count;
            var rand = new Random();
            return rand.Next(0, maxlength);
        }

        public static string Capitalize(this string value)
        {
            if (value == null)
            {
                return null;
            }
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value);
        }
    }
}