using System.Collections.Generic;

namespace AdamDotCom.Common.Website
{
    public interface IMailer
    {
        bool Send(MailerMessage mailerMessage);

        List<string> Errors { get; set; }
    }
}
