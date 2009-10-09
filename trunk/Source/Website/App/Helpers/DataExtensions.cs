using System;
using System.IO;
using System.Web;
using System.Xml.Linq;
using AdamDotCom.Resume.Service.Proxy;

namespace AdamDotCom.Website.App.Helpers
{
    using Resume = Resume.Service.Proxy.Resume;

    public static class DataExtensions
    {
        private static string dataDirectory;
        private static int daysUntilStale;
        private static string resumeFile = "Resume.xml";

        static DataExtensions()
        {
            if (HttpContext.Current != null)
            {
                dataDirectory = HttpContext.Current.Server.MapPath("data");
            }
            else
            {
                dataDirectory = @"C:\Projects\adamdotcom-website\Source\Website\Data";
            }
            daysUntilStale = 2;
        }

        public static string LocalFile(this Resume resume)
        {
            return string.Format("{0}\\{1}", dataDirectory, resumeFile);
        }

        public static Resume FromService(this Resume resume, string firstnameAndLastname)
        {
            var service = new ResumeService();
            return service.ResumeXml(firstnameAndLastname);
        }

        public static bool IsStale(this Resume resume)
        {
            return IsStale(resumeFile);
        }

        public static Resume FromLocal(this Resume resume)
        {
            return new Resume();
        }

        public static void SaveLocal(this Resume resume)
        {
            

        }

        private static bool IsStale(string pathAndFile)
        {
            return File.GetLastWriteTime(pathAndFile) < DateTime.Now.AddDays(-1 * daysUntilStale);
        }
    }
}
