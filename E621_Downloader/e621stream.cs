using E621_Class_libary;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace E621_Downloader
{
    internal class e621stream
    {
        public static async void Listn(List<string> tags ,Api api)
        {

            e621listener(tags,api);


        }

        private static void e621listener(List<string> tags,Api api)
        {

                Parallel.ForEach(tags, async tag =>
                {
                    await Dowload(tag,api);
                   
                });
            
        }

        private static async Task Dowload(string tag ,Api api)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            string oldmd5 = " null" ;
            string newmd5;
            while (true)
            {
                HttpClient client = api.e621Client;
                string url = $"https://e621.net/posts.json?tags={tag}";
                E621json e621 = await url.Deserializetion(client);
                List<(string url, string md5, int file_size, string[] tags, string extention)> pasrsed = e621.Parsejson();

                newmd5 = pasrsed[0].md5;

                if (newmd5.Equals(oldmd5) == false)
                {
                    oldmd5 = newmd5;
                     await url.downloadasync(pasrsed[0].md5, pasrsed[0].extention, path,tag);



                }
                else
                {
                    continue;
                }
                Thread.Sleep(5000);

            }




        }
    }
}