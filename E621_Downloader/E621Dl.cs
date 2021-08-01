using E621_Wrapper;
using Misc_functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static E621_Wrapper.e926_api;

namespace E621_Downloader
{
    public  static class E621Dl
    {
        public static void Furry_dl(string apikey, string user, bool sfw = false)
        {

            if (sfw == false)
            {
                Api e621 = new Api(apikey, user, "Raven Ebonscale E621 downloader");
                string folder = @".\e621";
                folder.Creation();
                var tags = Msc.Readtagfile(@".\e621\tags.txt");
                foreach (string tag in tags)
                {
                    List<E621json> e621Jsons = e621.Get_Posts(tag, 5);

                    foreach (E621json e621Json in e621Jsons)
                    {
                        Parallel.ForEach(e621Json.posts, post =>
                        {
                            post.file.url.Downloadasync(post.file.md5, post.file.ext, @".\e621", tag.Slashfix());

                        });

                    }


                }








            }

            else
            {
                E926_Api e621 = new E926_Api(apikey, user, "Raven Ebonscale E621 downloader");
                string folder = @".\e926";
                folder.Creation();
                var tags = Msc.Readtagfile(@".\e926\tags.txt");
                foreach (string tag in tags)
                {
                    List<E621json> e926Jsons = e621.Get_Posts(tag, 5);

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
