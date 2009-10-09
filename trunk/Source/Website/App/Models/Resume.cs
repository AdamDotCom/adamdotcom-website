using System.Xml.Linq;
using AdamDotCom_website.App.Helpers;

namespace AdamDotCom_website.App.Models
{
    public class Resume: XDocument
    {
        public string ResumeFile = "Resume.xml";

        public Resume()
        {
            if (this.IsLocal() && !this.IsStale())
            {
                Load(this.LocalFile());
            }
            else
            {
                XDocument.Load("http://adam.kahtava.com/services/resume/linkedin/adam-kahtava.xml");
                Save(this.LocalFile());    
            }
        }
    }
}
