using AdamDotCom.Common.Website;
using AdamDotCom.Whois.Service.Proxy;

namespace AdamDotCom.Website.App.Extensions
{
    public static class MailerExtensions
    {
        public static MailerMessage AppendWhois(this MailerMessage mailerMessage, IWhois whoisService, string ipAddress)
        {
            try
            {
                mailerMessage.Body += string.Format("\n\n----------\n IP Address: {0}", ipAddress);

                var whois = whoisService.WhoisXml(ipAddress);
                if (whois.RegistryData.Registrant != null)
                {
                    mailerMessage.Body += string.Format("\n Organization: {0}\n Country: {1}\n", whois.RegistryData.Registrant.Name, whois.RegistryData.Registrant.Country);
                }
            }
            catch
            {
            }
            return mailerMessage;

        }
   }
}