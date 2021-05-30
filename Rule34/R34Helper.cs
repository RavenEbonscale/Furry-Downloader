using System;
using System.Collections.Generic;
using System.Xml;
using System.Net.Http;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.Threading.Tasks;
using System.IO;

namespace Rule34
{
    public static class R34Helper
    {
     public static async Task<List<(string urls, string ext)>> Deserializetion(this string url)
        {
            XmlDocument doc = new XmlDocument();
            //XmlSerializer serializer = new XmlSerializer(typeof(Rule34Api));
            HttpClient client = new HttpClient();
            // Desealize the XML file and put it into the e621 class
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, url);
            HttpResponseMessage responseMessage = await client.SendAsync(requestMessage);
            var response = await responseMessage.Content.ReadAsStringAsync();
            //Has to be turned into an io stream so it can be used as an async
            //MemoryStream stream = new MemoryStream(response);

            XElement xelement = XElement.Parse(response);
            IEnumerable<XElement> menus = xelement.Elements();
            List<(string urls, string ext)> lewders = new List<(string urls, string ext)>();
            foreach (XAttribute lewds in menus.Attributes("file_url"))
            {
                string thing = lewds.Value;
                Uri imageurl = new Uri(thing);
                FileInfo fi = new FileInfo(imageurl.AbsolutePath);
                string ext = fi.Extension;
                lewders.Add((thing, ext));
            }
            return lewders;
            }

    }
    }

