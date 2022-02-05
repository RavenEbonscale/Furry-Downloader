using E621_Wrapper;
using Misc_functions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E621_Downloader
{
    public  static class E621Dl
    {
        public static void Furry_dl(string tags,string apikey, string user, bool sfw = false)
        {

            if (sfw == false)
            {
                Api e621 = new Api(apikey, user, "Raven Ebonscale E621 downloader");
                @".\e621".Creation();
                

                    Console.WriteLine($"============Starting Download For {tags}=================");

                    $@".\e621\{tags.Replace(":","")}".Creation();

                    List<E621json> e621Jsons = e621.Get_Posts(tags.Replace(":", "%3A"), 10); ;
                    int count = e621Jsons.Count * e621Jsons[0].posts.Length;
                    Console.WriteLine($"There are {count}~ Currently Downloading");
                    Console.WriteLine($"Be patient this might take some time");
                    foreach (E621json e621Json in e621Jsons)
                    {


                        Parallel.ForEach(e621Json.posts, post =>
                        {
                            post.file.url.Downloadasync(post.file.md5, post.file.ext, @".\e621", tags.Slashfix());

                        });
                       

                    }
                    Console.WriteLine($"=========Finished donwloading {tags}===========\n");


                








            }

            else
            {
                Api e926 = new Api(apikey, user, "Raven Ebonscale E926 downloader");
                string folder = @".\e926";
                folder.Creation();

                
                    List<E621json> e926Jsons = e926.Get_Posts_Sfw(tags, 5);
                    $@".\e926\{tags.Replace(":", "")}".Creation();
                    foreach (E621json e926Json in e926Jsons)
                    {
                        Parallel.ForEach(e926Json.posts, post =>
                        {
                            post.file.url.Downloadasync(post.file.md5, post.file.ext, @".\e926", tags.Slashfix());

                        });

                    }


                }


            }



        }

    }

