using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpDemo
{
    public static class HandleContent
    {
        public static T GetContent<T>(RestResponse restResponse)
        {
            return JsonConvert.DeserializeObject<T>(restResponse.Content);
        }

        public static string SetContent(dynamic content)
        {
            return JsonConvert.SerializeObject(content, Formatting.Indented);
        }

        public static T GetContentFile<T>(string file)
        {
            return JsonConvert.DeserializeObject<T>(File.ReadAllText(file));
        }
    }
}
