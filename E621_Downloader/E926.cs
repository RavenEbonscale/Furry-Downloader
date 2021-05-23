using E621_Class_libary;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace E621_Downloader
{
    class E926
    {
        public static async Task E926_function(string tagfile, Api api)
        {
            List<string> tags = msc.Readtagfile(tagfile);
            foreach (var tag in tags)
            {
                await Download(tag, 10, api);
            }
        }

        private static async Task Download(string tag, int pages, Api api)
        {
            string Folder = $@".\e926\{tag}";
            Folder.Creation();

            List<(string, string, int, string[], string)> e926json = await E926JasonAsync(tag, pages, api);
            int y = 0;
            int total = e926json.Count;
            Parallel.ForEach(e926json, url =>
            {
                using (WebClient wc = new WebClient())
                {
                    wc.DownloadFile(url.Item1, @$".\{Folder}\{url.Item2}.{url.Item5}");
                    Helper.ProgressBar(y, total);
                }
            }
                );
        }
       
        private static async Task<List<(string, string, int, string[], string)>> E926JasonAsync(string Tag, int pages, Api api)
        {
            HttpClient client = api.e621Client;

            List<(string, string, int, string[], string)> urls = new List<(string, string, int, string[], string)>();

            for (int page = 1; page < pages; page++)
            {
                Console.WriteLine($"Grabing urls for  page {page} for: {Tag}");

                string url = $"https://e621.net/posts.json?page={page}&tags={Tag}";

                E621json e621 = await url.Deserializetion(client);
                urls.AddRange(e621.Parsejson());
            }

            return urls;
        }
    }
}
