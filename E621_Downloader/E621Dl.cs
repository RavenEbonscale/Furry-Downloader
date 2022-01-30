using E621_Wrapper;
using Misc_functions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E621_Downloader
{
    public  static class E621Dl
    {
        public static void Furry_dl(string apikey, string user, bool sfw = false)
        {

            if (sfw == false)
            {
                Api e621 = new Api(apikey, user, "Raven Ebonscale E621 downloader");
                @".\e621".Creation();
                
                var tags = Msc.Readtagfile(@".\e621\tags.txt");
                foreach (string tag in tags)
                {
                    Console.WriteLine($"============Starting Download For {tag}=================");

                    $@".\e621\{tag.Replace(":","")}".Creation();

                    List<E621json> e621Jsons = e621.Get_Posts(tag.Replace(":", "%3A"), 10); ;
                    int count = e621Jsons.Count * e621Jsons[0].posts.Length;
                    Console.WriteLine($"There are {count}~ Currently Downloading");
                    Console.WriteLine($"Be patient this might take some time");
                    foreach (E621json e621Json in e621Jsons)
                    {


                        Parallel.ForEach(e621Json.posts, post =>
                        {
                            post.file.url.Downloadasync(post.file.md5, post.file.ext, @".\e621", tag.Slashfix());

                        });
                       

                    }
                    Console.WriteLine($"=========Finished donwloading {tag}===========\n");


                }








            }

            else
            {
                Api e926 = new Api(apikey, user, "Raven Ebonscale E926 downloader");
                string folder = @".\e926";
                folder.Creation();
                var tags = Msc.Readtagfile(@".\e926\tags.txt");
                foreach (string tag in tags)
                {
                    List<E621json> e926Jsons = e926.Get_Posts_Sfw(tag, 5);
                    $@".\e926\{tag.Replace(":", "")}".Creation();
                    foreach (E621json e926Json in e926Jsons)
                    {
                        Parallel.ForEach(e926Json.posts, post =>
                        {
                            post.file.url.Downloadasync(post.file.md5, post.file.ext, @".\e926", tag.Slashfix());

                        });

                    }


                }


            }



        }

    }
}
