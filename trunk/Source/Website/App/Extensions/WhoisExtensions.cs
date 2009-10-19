using AdamDotCom.Whois.Service.Proxy;

namespace AdamDotCom.Website.App.Extensions
{
    public static class WhoisExtensions
    {
        public static bool IsFilterMatch(this WhoisEnhancedRecord whois, string value)
        {
            return whois.FilterMatches != null && whois.FilterMatches.Contains(value);
        }

        public static bool IsFriendlyMatch(this WhoisEnhancedRecord whois, string value)
        {
            return whois.FriendlyMatches != null && whois.FriendlyMatches.Contains(value);
        }

        public static bool IsReferrerMatch(this WhoisEnhancedRecord whois, string value)
        {
            return whois.ReferrerMatches != null && whois.ReferrerMatches.Contains(value);
        }
    }
}
