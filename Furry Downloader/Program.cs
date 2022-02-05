using E621_Downloader;
using Reddit_DownloaderLocal;
using Rule34;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;


namespace Furry_Downloader
{
    class Program
    {
        static async Task Main()
        {
        begening:
            Console.WriteLine("\nI'm Going to add something Clever here~");
            Console.WriteLine("Make your Choice");
            Console.WriteLine("1: E621");
            Console.WriteLine("2: e926 (aka safe for work E621)");
            Console.WriteLine("3: Reddit");
            Console.WriteLine("4: Rule34");
            Console.WriteLine("5: All");
            Console.WriteLine("end:stops the program");

            bool retry = true;

            while (retry == true) {
                string Choice = Console.ReadLine().ToLower();

                switch (Choice)
                {
                    case "1":
                    case "e621":
                        Console.WriteLine("Please Input your tags");
                        string tags = Console.ReadLine().ToLower();
                        await E621();

                        goto begening;

                    case "2":
                    case "e926":
                        await E621(false);
                        retry = false;
                        break;
                    case "3":
                    case "reddit":
                        Reddit_Dl.Reddit();
                        goto begening;

                    case "5":
                    case "all":
                        All_Run();
                        goto begening;

                    case "6":
                        await E621(false);
                        break;
                    case "rule34":
                    case "4":
                        await Rule34DL.Rule34Async();
                        goto begening;
                    case "7":
                       await MachineLearning();
                        break;
                    case "end":
                        goto end;


                    default:
                        Console.WriteLine("This isn't a choice please try again");
                        break;



                } }
        end:
            Console.ReadKey();


        }

        private static void All_Run()
        {

            Thread e621 = new Thread(async () => await E621());
            Thread e926 = new Thread(async () => await E621(false));
            Thread reddit = new Thread(new ThreadStart(Reddit_Dl.Reddit));

            e621.Start();
            e926.Start();
            reddit.Start();


        }

        private static async Task E621(bool e621 = true,string tags= null)
        {



                (string apikey, string user) apikey = Msc.Stuff(@".\config.txt");
                if (e621 == true) { E621Dl.Furry_dl(tags,apikey.apikey, apikey.user);


                    Console.ReadKey();
                }

                else
                {
                    E621Dl.Furry_dl(tags,apikey.apikey, apikey.user, true);

                }
                Console.ReadKey();
            }
         

            
        

        private static async Task MachineLearning()
        {
            if (File.Exists(@".\config.txt"))
            {


                (string apikey, string user) apikey = Msc.Stuff(@".\config.txt");
            }

            else
            {

                using (StreamWriter sw = File.AppendText(@".\config.txt"))
                {
                    Console.WriteLine("You are going to need to use your own API and username");
                    Console.WriteLine("https://e621.net/wiki_pages/2425 follow the instruction here under Logging in");
                    Console.WriteLine("Then all you will have to do is fill out the Config file and should be all set");
                    sw.WriteLine("Apikey =");
                    sw.WriteLine("username =");
                    sw.Close();
                    Console.ReadKey();
                }
                Checkfortagfile(@".\tags.txt");

            }
             
}

       
    }
}
