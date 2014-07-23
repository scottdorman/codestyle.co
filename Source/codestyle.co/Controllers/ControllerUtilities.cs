using MarkdownSharp;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace codestyle.co.Controllers
{
    public static class ControllerUtilities
    {
        public static IEnumerable<JToken> GetTableOfContents()
        {
            JArray contents = new JArray();
            var path = HostingEnvironment.MapPath("~/data/");
            if (Directory.Exists(path))
            {
                foreach (var file in Directory.GetFiles(path, "*.json", SearchOption.AllDirectories))
                {
                    var contentJson = JObject.Parse(File.ReadAllText(file));
                    contents.Add(JObject.FromObject(new
                    {
                        title = contentJson["title"],
                        id = Directory.GetParent(file).Name,
                        icon = contentJson["icon"]
                    }));
                }
            }

            return contents.OrderBy(c => (string)c["title"]);
        }

        public static JObject GetContents(string language)
        {
            JObject json = null;
            var path = HostingEnvironment.MapPath(String.Format("~/data/{0}/contents.json", language));
            if (File.Exists(path))
            {
                json = JObject.Parse(File.ReadAllText(path));
            }

            return json;
        }

        private static void Test()
        {
            var m = new Markdown();
            //m.Transform(
        }
    }
}