using Newtonsoft.Json;
using System;
using System.Net;

namespace CatMash.Core.Json
{
    public class JsonSerializer
    {
        public static T DeserializeJson<T>(string url) where T : new()
        {
            using (WebClient webClient = new WebClient())
            {
                string data = String.Empty;
                try
                {
                    data = webClient.DownloadString(url);
                }
                catch (Exception e)
                {
                    throw;
                }
                return !String.IsNullOrEmpty(data) ? JsonConvert.DeserializeObject<T>(data) : new T();
            }
        }
    }
}
