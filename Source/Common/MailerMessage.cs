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

        //ToDo: simplified validation, look into extending this to include when the from address etc... are missing
        public bool IsValid()
        {
            if (!string.IsNullOrEmpty(FromAddress) && !string.IsNullOrEmpty(Body))
            {
                return true;
            }
            return false;
        }
    }
}
