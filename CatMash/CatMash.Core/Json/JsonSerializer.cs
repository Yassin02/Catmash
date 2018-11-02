using Newtonsoft.Json;
using System;
using System.Net;

namespace CatMash.Core.Json
{
    public class JsonSerializer
    {
        /// <summary>
        /// Download a json from a given url and deserialize it into an object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <returns></returns>
        public static T DeserializeJson<T>(string url) where T : new()
        {
            if (String.IsNullOrWhiteSpace(url))
                throw new ArgumentNullException("url");

            using (WebClient webClient = new WebClient())
            {
                string data = String.Empty;
                try
                {
                    data = webClient.DownloadString(url);
                }
                catch (WebException)
                {
                    throw;
                }
                return !String.IsNullOrEmpty(data) ? JsonConvert.DeserializeObject<T>(data) : new T();
            }
        }
    }
}
