using System;

using System.IO;
using System.Threading;
using System.Threading.Tasks;
using E621_Downloader;
using Reddit_Downloader;


namespace Furry_Downloader
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("I'm Going to add something Clever here~");
            Console.WriteLine("Make your Choice");
            Console.WriteLine("1: E621");
            Console.WriteLine("2: e926 (aka safe for work E621)");
            Console.WriteLine("3: Reddit");
            Console.WriteLine("4: All");
            //Console.WriteLine("5: e621 stream (checks the website based on tags and downloads the latest)");
            //Console.WriteLine("4: rule34"); API is fucked
            bool retry = true;
            while (retry == true) {
                string Choice = Console.ReadLine();

                switch (Choice)
                {
                    case "1":
                        await E621();
                        retry = false;
                        break;
                    case "2":
                        await E621(false);
                        retry = false;
                        break;
                    case "3":
                        Reddit_Dl.reddit();
                        retry = false;
                        break;
                    case "4":
                        All_Run();
                        break;
                    case "5":
                        await E621(false);
                        break;
                    case "6":
                        Rule34.Rule34DL.Rule34();
                        
                        break;
                    default:
                        Console.WriteLine("This isn't a choice please try again");
                        break;



                } }

            Console.ReadKey();
            
            
        }

        private static void All_Run()
        {
           
            Thread e621 = new Thread(async () => await E621());
            Thread e926 = new Thread(async () => await E621(false));
            Thread reddit = new Thread(new ThreadStart(Reddit_Dl.reddit));
            e621.Start();
            e926.Start();
            reddit.Start();
            
        }





        private static async Task E621(bool e621 = true)
        {
            if (File.Exists(@".\config.txt"))
            {

                
                (string apikey, string user) apikey = msc.Stuff(@".\config.txt");
                if (e621 == true) { await E621_DL.E621(apikey.apikey, apikey.user);
                    Console.ReadKey();
                }

                else
                {
                    await E621_DL.E621(apikey.apikey, apikey.user, "e926");

                }
                Console.ReadKey();
            }
            else
            {

                using (StreamWriter sw = File.AppendText(@".\config.txt"))
                {
                    Console.WriteLine("You are going to need to use your own API and username");
                    Console.WriteLine("https://e621.net/wiki_pages/2425 follow the instuction here under Logging in");
                    Console.WriteLine("Then all you will have to do is fill out the Config file and should be all set");
                    sw.WriteLine("Apikey =");
                    sw.WriteLine("username =");
                    sw.Close();
                    Console.ReadKey();
                }
                Checkfortagfile(@".\tags.txt");

            }
        }

        private static void Checkfortagfile(string tagfile)
        {
            if (File.Exists(tagfile) == false)
            {

                using (StreamWriter sw = File.AppendText(tagfile))
                {

                    Console.WriteLine("Tag file has been made with starting tag list");

                    //Adding generic tags
                    sw.WriteLine("Gay");
                    sw.WriteLine("straight");
                    sw.WriteLine("straight,-gay");

                    sw.Close();
                }

            }
        
        }
    }
}
