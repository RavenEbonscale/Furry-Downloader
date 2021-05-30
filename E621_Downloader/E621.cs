using E621_Class_libary;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E621_Downloader
{
    public class E621_DL
    {
        public static async Task E621(string apikey, string user, string choice ="e621")
        {

            var tagfile = @".\tags.txt";
            Console.WriteLine(apikey + user);
            Api Api = new Api(apikey, user, "Furry_downloader (by Purple_Drago on e621)");
            List<string> tags = msc.Readtagfile(tagfile);

            switch (choice) {
                case "e621":
                    await e621_Functions.E621Async(tagfile, Api);
                    break;
                case "e926":
                    await E926.E926_function(tagfile,Api);
                    break;
                case "e621stream":
                    e621stream.Listn(tags,Api);
                    break;

            } }


    }
        }
    


