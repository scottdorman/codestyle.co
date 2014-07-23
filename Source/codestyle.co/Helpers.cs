using codestyle.co.Controllers;
using MarkdownSharp;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Xml.Linq;

namespace codestyle.co
{
    public static class Helpers
    {
        private static Markdown markdown = new Markdown();

        private static string EncodeTo64(string toEncode)
        {
            var toEncodeAsBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(toEncode);
            var returnValue = System.Convert.ToBase64String(toEncodeAsBytes);
            return returnValue;
        }

        private static string DecodeFrom64(string encodedData)
        {
            var encodedDataAsBytes = System.Convert.FromBase64String(encodedData);
            var returnValue = System.Text.ASCIIEncoding.ASCII.GetString(encodedDataAsBytes);
            return returnValue;
        }

        private static string GenerateUniqueKey()
        {
            string uniqueKey;

            if (!String.IsNullOrWhiteSpace(HttpContext.Current.Profile.UserName))
            {
                uniqueKey = EncodeTo64(HttpContext.Current.Profile.UserName);
            }
            else
            {
                uniqueKey = Path.GetRandomFileName().Replace(".", "");
            }

            return EncodeTo64(uniqueKey);
        }

        private static string FormatId(string format, params object[] args)
        {
            return String.Format(format, args).Replace("=", "");
        }

        public static string CreateId(string prefix, string name)
        {
            return FormatId("{0}_{1}_{2}", prefix, EncodeTo64(name), GenerateUniqueKey());
        }

        public static string CreateId(string name)
        {
            return FormatId("{0}_{1}", EncodeTo64(name), GenerateUniqueKey());
        }

        public static string CreateSanitizedId(string originalId)
        {
            return CreateSanitizedId(originalId, HtmlHelper.IdAttributeDotReplacement);
        }

        public static string CreateSanitizedId(string originalId, string invalidCharReplacement)
        {
            if (String.IsNullOrEmpty(originalId))
            {
                return null;
            }

            if (invalidCharReplacement == null)
            {
                throw new ArgumentNullException("invalidCharReplacement");
            }

            char firstChar = originalId[0];
            if (!Html401IdUtil.IsLetter(firstChar))
            {
                // the first character must be a letter
                return null;
            }

            StringBuilder sb = new StringBuilder(originalId.Length);
            sb.Append(firstChar);

            for (int i = 1; i < originalId.Length; i++)
            {
                char thisChar = originalId[i];
                if (Html401IdUtil.IsValidIdCharacter(thisChar))
                {
                    sb.Append(thisChar);
                }
                else
                {
                    sb.Append(invalidCharReplacement);
                }
            }

            return sb.ToString();
        }

        public static MvcHtmlString DisplayMarkdown(JToken section, string id)
        {
            var content = String.Empty;
            var path = HostingEnvironment.MapPath(String.Format("~/data/{0}/{1}", id, (string)section["markdown"]));
            if (File.Exists(path))
            {
                content = markdown.Transform(File.ReadAllText(path));
            }

            return new MvcHtmlString(content);
        }

        public static MvcHtmlString DisplaySection(JToken section, string id)
        {
            var notes = (string)section["notes"];
            var links = (section["links"] != null ? section["links"] : Enumerable.Empty<JToken>());
            var shouldDisplayInfoPanel = !String.IsNullOrWhiteSpace(notes) || links.Any();

            var content = String.Empty;
            var path = HostingEnvironment.MapPath(String.Format("~/data/{0}/{1}", id, (string)section["markdown"]));
            if (File.Exists(path))
            {
                content = markdown.Transform(File.ReadAllText(path));
            }

            XElement infoPanel = null;
            if (shouldDisplayInfoPanel)
            {
                var panelBody = new XElement("div", new XAttribute("class", "panel-body"));
                if (!String.IsNullOrWhiteSpace(notes))
                {
                    panelBody.Add(new XElement("fieldset",
                        new XElement("legend",
                            new XElement("small", "Remarks")),
                        new XElement("p", notes)));
                }

                if (links.Any())
                {
                    panelBody.Add(new XElement("fieldset",
                        new XElement("legend",
                            new XElement("small", "See also")),
                        new XElement("ul", links.Select(link => new XElement("li",
                            new XElement("a", new XAttribute("href", (string)link["url"]), new XAttribute("target", "_blank"), (string)link["title"]))))));
                }

                infoPanel = new XElement("div", new XAttribute("class", "panel panel-info"),
                    new XElement("div", new XAttribute("class", "panel-heading"),
                        new XElement("div", new XAttribute("class", "panel-title"),
                            new XElement("span", new XAttribute("class", "fa fa-info-circle"), ""),
                            " Additional information")),
                        panelBody);
            }

            return new MvcHtmlString(String.Join(" ", content, infoPanel == null ? String.Empty : infoPanel.ToString()));
        }

        public static MvcHtmlString DisplayGuideline(JToken token, string id)
        {
            var notes = (string)token["notes"];
            var links = (token["links"] != null ? token["links"] : Enumerable.Empty<JToken>());
            var shouldDisplayInfoPanel = !String.IsNullOrWhiteSpace(notes) || links.Any();

            var label = new XElement("sup", new XAttribute("class", "label label-warning"),
        (string)token["status"] == "wd" ? "Draft" : String.Empty);

            var content = String.Empty;
            var path = HostingEnvironment.MapPath(String.Format("~/data/{0}/{1}", id, (string)token["markdown"]));
            if (File.Exists(path))
            {
                content = markdown.Transform(File.ReadAllText(path));
            }

            XElement infoPanel = null;
            if (shouldDisplayInfoPanel)
            {
                var panelBody = new XElement("div", new XAttribute("class", "panel-body"));
                if (!String.IsNullOrWhiteSpace(notes))
                {
                    panelBody.Add(new XElement("fieldset",
                        new XElement("legend",
                            new XElement("small", "Remarks")),
                        new XElement("p", notes)));
                }

                if (links.Any())
                {
                    panelBody.Add(new XElement("fieldset",
                        new XElement("legend",
                            new XElement("small", "See also")),
                        new XElement("ul", links.Select(link => new XElement("li",
                            new XElement("a", new XAttribute("href", (string)link["url"]), new XAttribute("target", "_blank"), (string)link["title"]))))));
                }

                infoPanel = new XElement("div", new XAttribute("class", "panel panel-info"),
                    new XElement("div", new XAttribute("class", "panel-heading"),
                        new XElement("div", new XAttribute("class", "panel-title"),
                            new XElement("span", new XAttribute("class", "fa fa-info-circle"), ""),
                            " Additional information")),
                        panelBody);
            }

            return new MvcHtmlString(String.Join(" ", content, infoPanel == null ? String.Empty : infoPanel.ToString()));
        }
    }

    // Valid IDs are defined in
    // http://www.w3.org/TR/html401/types.html#type-id
    static class Html401IdUtil
    {
        private static bool IsAllowableSpecialCharacter(char c)
        {
            switch (c)
            {
                case '-':
                case '_':
                case ':':
                    // note that we're specifically excluding the '.' character
                    return true;

                default:
                    return false;
            }
        }

        private static bool IsDigit(char c)
        {
            return ('0' <= c && c <= '9');
        }

        public static bool IsLetter(char c)
        {
            return (('A' <= c && c <= 'Z') || ('a' <= c && c <= 'z'));
        }

        public static bool IsValidIdCharacter(char c)
        {
            return (IsLetter(c) || IsDigit(c) || IsAllowableSpecialCharacter(c));
        }
    }

}