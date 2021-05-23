using E621_Class_libary;
using System.Threading.Tasks;

namespace E621_Downloader
{
    public class E621_DL
    {
        public static async Task E621(string apikey, string user, string choice ="e621")
        {

            var tagfile = @".\tags.txt";
            Api Api = new Api(apikey, user);

            switch (choice) {
                case "e621":
                    await e621_Functions.E621Async(tagfile, Api);
                    break;
                case "e926":
                    await E926.E926_function(tagfile,Api);
                    break;
                case "e621stream":
                    break;

            } }


    }
        }
    


