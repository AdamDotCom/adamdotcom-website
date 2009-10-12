using AdamDotCom.Resume.Service.Proxy;

namespace AdamDotCom.Website.App.Extensions
{
    using Resume = Resume.Service.Proxy.Resume;

    public static class ResumeExtensions
    {
        public static Resume FromService(this Resume resume, string firstAndLastname)
        {
            return new ResumeService().ResumeXml(firstAndLastname);
        }

        public static Resume FromLocal(this Resume resume)
        {
            return DataExtensions.Load(resume) as Resume;
        }

        public static void SaveLocal(this Resume resume)
        {
            DataExtensions.Save(resume);
        }

        public static bool IsStale(this Resume resume)
        {
            return DataExtensions.IsStale(resume);
        }
    }
}
