using System.Net.Mail;

namespace AdamDotCom.Common.Website
{
    public class MailerMessage
    {
        public string ToAddress { get; set; }
        public string ToName { get; set; }
        public string FromAddress { get; set; }
        public string FromName { get; set; }
        public string Body { get; set; }
        public string Subject { get; set; }
    }

    public class Mailer
    {
        private readonly string smtpServerName;

        public Mailer()
        {
            smtpServerName = "relay-hosting.secureserver.net";
        }

        public Mailer(string smtpServerName)
        {
            this.smtpServerName = smtpServerName;
        }

        public bool Send(MailerMessage mailerMessage)
        {
            try
            {
                var fromAddress = new MailAddress(mailerMessage.ToAddress, mailerMessage.ToName);

                var toAddress = new MailAddress(mailerMessage.FromAddress, mailerMessage.FromName);

                var mailMessage = new MailMessage(fromAddress, toAddress)
                                      {
                                          Subject = mailerMessage.Subject,
                                          Body = mailerMessage.Body
                                      };

                var client = new SmtpClient(smtpServerName);

                client.Send(mailMessage);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}