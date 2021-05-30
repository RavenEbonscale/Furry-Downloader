using E621_Class_libary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace E621_Downloader
{
    public static class Helper
    {
        //seperates Urls into Urls,MD5 might expand this to tags,discriptions size ect.
        public static List<(string url, string md5, int file_size, string[] tags, string extention)> Parsejson(this E621json e621)
        {
            List<(string, string, int, string[], string)> urllist = new List<(string, string, int, string[], string)>();

            foreach (E621json.Post post in e621.posts)
            {
                if (post.file.url != null)
                    urllist.Add((post.file.url, post.file.md5, post.file.size, post.tags.general, post.file.ext));
            }

            return urllist;
        }

        //Desearlize the files into
        public static async Task<E621json> Deserializetion(this string url, HttpClient client)
        {
            // Desealize the json file and put it into the e621 class
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, url);
            HttpResponseMessage responseMessage = await client.SendAsync(requestMessage);
            Console.WriteLine(responseMessage);
            byte[] response = await responseMessage.Content.ReadAsByteArrayAsync();
            //Has to be turned into an io stream so it can be used as an async
            MemoryStream stream = new MemoryStream(response);
            E621json e621 = await JsonSerializer.DeserializeAsync<E621json>(stream);
            return e621;
        }

        //Fixes / problem
        public static string slashfix(this string folderstring)
        {
            if (folderstring != "m/m")
            {
                return folderstring;
            }
            return folderstring = "MaleMale";
        }
        public static async         Task
       downloadasync(this string url,string md5,string extenstion,string path,string tag)
        {
            using (WebClient wc = new WebClient())
            {
                wc.DownloadFile(url, $@"{path}\{tag}\{md5}.{extenstion}");
            }

        }

    }
}