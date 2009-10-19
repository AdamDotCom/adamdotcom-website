using System;
using System.IO;
using System.Web;
using System.Xml.Serialization;

namespace AdamDotCom.Common.Website
{
    public static class LocalDataExtensions
    {
        private static readonly string dataDirectory;
        private static int stalenessInDays;

        public static int StalenessInDays
        {
            set { stalenessInDays = value; }
        }

        static LocalDataExtensions()
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

        private static string LocalPathAndFile(string file)
        {
            return string.Format("{0}\\{1}", dataDirectory, file);
        }

        private static string LocalPathAndFile(Type type)
        {
            if (type == null) throw new ArgumentNullException("type");
            var fullNameSplit = type.FullName.Split('.');
            var name = fullNameSplit[fullNameSplit.Length-1] ?? type.GetType().FullName;
            return LocalPathAndFile(string.Format("{0}.xml", name));
        }

        private static bool IsStale(Type type)
        {
            return File.GetLastWriteTime(LocalPathAndFile(type)) < DateTime.Now.AddDays(-1 * stalenessInDays);
        }

        private static bool Save(Object obj, string pathAndFile)
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

        private static object Load(Object obj, string pathAndFile)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            var serializer = new XmlSerializer((Type) obj);
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

        public static T FindLocal<T>(this T value)
        {
            return (T) Load(typeof(T), LocalPathAndFile(typeof(T)));
        }

        public static bool SaveLocal<T>(this T value)
        {
            return Save(value, LocalPathAndFile(value.GetType()));
        }

        public static bool IsLocalStale<T>(this T value)
        {
            return IsStale(typeof(T));
        }
    }
}