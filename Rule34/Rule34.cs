using System;
using System.IO;
using System.Xml.Serialization;
using System.Net.Http;
using System.Collections.Generic;

namespace Rule34
{
    public class Rule34DL
    {
        public static void Rule34()
        {
            string tagfile = $@".\rule34.txt";
            List<string> Tags = msc.Readtagfile(tagfile);
            foreach(string tag in Tags)
            {
                string url = @$"https://rule34.xxx/index.php?page=dapi&s=post&q=index&tags={tag}";
                url.Deserializetion();
            }


        }

    }
}
