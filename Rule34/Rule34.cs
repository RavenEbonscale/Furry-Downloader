using Misc_functions;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Rule34
{
    public class Rule34DL
    {
        public static async Task Rule34Async()
        {
            string tagfile = $@".\rule34.txt";
            List<string> Tags = Miscfun.Readtagfile(tagfile);
            foreach (string tag in Tags)
            {
                string Folder = $@".\rule34\{tag}";
                Folder.Creation();
                string url = @$"https://rule34.xxx/index.php?page=dapi&s=post&q=index&tags={tag}";
                List<(string urls, string ext)> info = await url.Deserializetion();
                int y = 1;
                int total = info.Count;
                Parallel.ForEach(info, lewd =>
                {
                    using (WebClient wc = new WebClient())
                    {
                        string filename = Miscfun.Generatefilename(lewd.ext);
                        //Console.WriteLine(filename);
                        wc.DownloadFile(lewd.urls, $@".\rule34\{tag}\{filename}");
                        Miscfun.ProgressBar(y, total);
                        Interlocked.Increment(ref y);
                        Thread.Sleep(100);
                    }
                });
            }
        }
    }
}