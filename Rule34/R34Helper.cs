using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Net.Http;
using System.Xml.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;

namespace Rule34
{
    public static class R34Helper
    {
        public static async void Deserializetion(this string url)
        {
            XmlDocument doc = new XmlDocument();
            XmlSerializer serializer = new XmlSerializer(typeof(Rule34Api));
            HttpClient client = new HttpClient();
            // Desealize the XML file and put it into the e621 class
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, url);
            HttpResponseMessage responseMessage = await client.SendAsync(requestMessage);
            var response = await responseMessage.Content.ReadAsStringAsync();
            //Has to be turned into an io stream so it can be used as an async
            //MemoryStream stream = new MemoryStream(response);
            
            XElement xelement = XElement.Parse(response);
            IEnumerable<XElement> menus = xelement.Elements();
            List<string> subMenuList = new List<string>();
            foreach (var menu in menus)
            {

                    foreach (var submenu in menu.Elements())
                    {
                    Console.WriteLine(submenu);
                    }
                }
            }





            //serializer.Deserialize(stream);







        }
    }
}
