using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using AdamDotCom.Resume.Service.Proxy;


namespace AdamDotCom_website.App.Helpers
{
    public static class DataExtensions
    {
        private static string dataDirectory;
        private static int daysUntilStale;

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

//        public static string LocalFile(this Resume resume)
//        {
//                return string.Format("{0}\\{1}", dataDirectory, resume.ResumeFile);
//        }
//
//        public static bool IsLocal(this Resume resume)
//        {
//            return File.GetLastWriteTime(resume.ResumeFile) != DateTime.MinValue;
//        }
//
//        public static bool IsStale(this Resume resume)
//        {
//            return IsStale(resume.ResumeFile);
//        }
//
//        private static bool IsStale(string pathAndFile)
//        {
//            return File.GetLastWriteTime(pathAndFile) < DateTime.Now.AddDays(-1 * daysUntilStale);
//        }
    }
}
