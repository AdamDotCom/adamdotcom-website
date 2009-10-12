using System;
using System.IO;
using System.Web;
using System.Xml.Serialization;

namespace AdamDotCom.Website.App.Extensions
{
    public static class DataExtensions
    {
        private static string dataDirectory;
        private static int stalenessInDays;

        public static int StalenessInDays
        {
            set { stalenessInDays = value; }
        }

        static DataExtensions()
        {
            if (HttpContext.Current != null)
            {
                dataDirectory = HttpContext.Current.Server.MapPath("~/Data");
            }
            else
            {
                dataDirectory = @"C:\Projects\adamdotcom-website\Source\Website\Data";
            }
            stalenessInDays = 2;
        }

        public static string LocalPathAndFile(string file)
        {
            return string.Format("{0}\\{1}", dataDirectory, file);
        }

        public static string LocalPathAndFile(Object obj)
        {
            var fullNameSplit = obj.GetType().FullName.Split('.');
            var name = fullNameSplit[fullNameSplit.Length-1] ?? obj.GetType().FullName;
            return LocalPathAndFile(string.Format("{0}.xml", name));
        }

        public static bool IsStale(Object obj)
        {
            return File.GetLastWriteTime(LocalPathAndFile(obj)) < DateTime.Now.AddDays(-1 * stalenessInDays);
        }

        public static bool Save(Object obj)
        {
            return Save(obj, LocalPathAndFile(obj));
        }

        public static bool Save(Object obj, string pathAndFile)
        {
            if (obj == null) throw new ArgumentNullException("obj");            
            var serializer = new XmlSerializer(obj.GetType());
            try
            {
                var writer = new StreamWriter(pathAndFile);
                serializer.Serialize(writer, obj);
                writer.Close();
            }
            catch
            {
                return false;
            }
            return true;
        }
        public static object Load(Object obj)
        {
            return Load(obj, LocalPathAndFile(obj));
        }

        public static object Load(Object obj, string pathAndFile)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            var serializer = new XmlSerializer(obj.GetType());
            try
            {
                var reader = new StreamReader(pathAndFile);
                obj = serializer.Deserialize(reader);
                reader.Close();
            }
            catch
            {
                return null;
            }
            return obj;
        }
    }
}