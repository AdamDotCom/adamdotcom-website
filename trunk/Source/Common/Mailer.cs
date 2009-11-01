using System.Collections.Generic;
using System.Net.Mail;

namespace AdamDotCom.Common.Website
{
    public class Mailer
    {
        private readonly string smtpServerName;

        public Mailer() : this("relay-hosting.secureserver.net") {}

        public Mailer(string smtpServerName)
        {
            this.smtpServerName = smtpServerName;
            Errors = new List<string>();
        }

        //ToDo: extend errors into errorcodes based on enums
        public List<string> Errors;

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

                var client = new SmtpClient(smtpServerName)
                                 {
                                     UseDefaultCredentials = true,
                                     DeliveryMethod = SmtpDeliveryMethod.Network
                                 };

                client.Send(mailMessage);

                return true;
            }
            catch (SmtpException ex)
            {
                if(ex.StatusCode == SmtpStatusCode.TransactionFailed)
                {
                    if(ex.Message.ToLowerInvariant().Contains("spam"))
                    {
                        Errors.Add("content marked as spam");
                    }
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}