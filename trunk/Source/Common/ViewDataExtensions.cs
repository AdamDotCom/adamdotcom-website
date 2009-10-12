using System;
using System.Collections.Generic;
using System.Web.Mvc;

//Taken from MVCContrib: http://mvccontrib.googlecode.com/svn/trunk/src/MVCContrib/ViewDataExtensions.cs
namespace AdamDotCom.Common.Website
{
    public static class ViewDataExtensions
    {
        /// <summary>
        /// Adds an object using the type as the dictionary key
        /// </summary>
        public static IDictionary<string, object> Add<T>(this IDictionary<string, object> dictionary, T anObject)
        {
            var type = typeof(T);
            if (dictionary.ContainsKey(getKey(type)))
            {
                var message = string.Format("You can only add one default object for type '{0}'.", type);
                throw new ArgumentException(message);
            }

            dictionary.Add(getKey(type), anObject);
            return dictionary;
        }

        public static IDictionary<string, object> Add<T>(this IDictionary<string, object> dictionary, string key, T value)
        {
            dictionary.Add(key, value);
            return dictionary;
        }

        public static T Get<T>(this IDictionary<string, object> dictionary)
        {
            return dictionary.Get<T>(getKey(typeof(T)));
        }

        public static T GetOrDefault<T>(this IDictionary<string, object> dictionary, string key, T defaultValue)
        {
            if (dictionary.ContainsKey(key))
                return (T)dictionary[key];

            return defaultValue;
        }

        public static object Get(this IDictionary<string, object> dictionary, Type type)
        {
            if (!dictionary.ContainsKey(getKey(type)))
            {
                string message = string.Format("No object exists that is of type '{0}'.", type);
                throw new ArgumentException(message);
            }

            return dictionary[getKey(type)];
        }

        private static string getKey(Type type)
        {
            return type.FullName;
        }

        public static bool Contains<T>(this IDictionary<string, object> dictionary)
        {
            return dictionary.ContainsKey(getKey(typeof(T)));
        }

        public static bool Contains(this IDictionary<string, object> dictionary, Type keyType)
        {
            return dictionary.ContainsKey(getKey(keyType));
        }

        public static T Get<T>(this IDictionary<string, object> dictionary, string key)
        {
            if (!dictionary.ContainsKey(key))
            {
                var message = string.Format("No object exists with key '{0}'.", key);
                throw new ArgumentException(message);
            }

            return (T)dictionary[key];
        }

        public static int GetCount(this IDictionary<string, object> dictionary, Type type)
        {
            var count = 0;
            foreach (var value in dictionary.Values)
            {
                if (type.Equals(value.GetType()))
                {
                    count++;
                }
            }

            return count;
        }

        //ViewData extensions

        public static T Get<T>(this ViewDataDictionary dictionary)
        {
            return dictionary.Get<T>(getKey(typeof(T)));
        }

        public static T GetOrDefault<T>(this ViewDataDictionary dictionary, string key, T defaultValue)
        {
            if (dictionary.ContainsKey(key))
                return (T)dictionary[key];

            return defaultValue;
        }

        public static object Get(this ViewDataDictionary dictionary, Type type)
        {
            if (!dictionary.ContainsKey(getKey(type)))
            {
                var message = string.Format("No object exists that is of type '{0}'.", type);
                throw new ArgumentException(message);
            }

            return dictionary[getKey(type)];
        }

        public static bool Contains<T>(this ViewDataDictionary dictionary)
        {
            return dictionary.ContainsKey(getKey(typeof(T)));
        }

        public static bool Contains(this ViewDataDictionary dictionary, Type keyType)
        {
            return dictionary.ContainsKey(getKey(keyType));
        }

        public static bool Contains(this ViewDataDictionary dictionary, string key)
        {
            return dictionary.ContainsKey(key);
        }

        public static T Get<T>(this ViewDataDictionary dictionary, string key)
        {
            if (!dictionary.ContainsKey(key))
            {
                var message = string.Format("No object exists with key '{0}'.", key);
                throw new ArgumentException(message);
            }

            return (T)dictionary[key];
        }
    }
}
