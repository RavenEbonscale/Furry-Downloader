using System;
using System.IO;
using System.Xml.Serialization;
using System.Net.Http;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Threading;

namespace Rule34
{
    public class Rule34DL
    {
        public static async Task Rule34Async()
        {
            string tagfile = $@".\rule34.txt";
            List<string> Tags = msc.Readtagfile(tagfile);
            foreach(string tag in Tags)
            {
                string url = @$"https://rule34.xxx/index.php?page=dapi&s=post&q=index&tags={tag}";
                List<(string urls, string ext)> info = await url.Deserializetion();
                int y = 0;
                int total = info.Count;
                Parallel.ForEach(info, lewd =>
                {
                    using (WebClient wc = new WebClient())
                    {
                        string filename = R34Helper.Generatefilename(lewd.ext);
                        Console.WriteLine(filename);
                        wc.DownloadFile(lewd.urls,filename);
                        msc.ProgressBar(y, total);
                        Interlocked.Increment(ref y);
                    }
                });
            }


        }


    }
}
