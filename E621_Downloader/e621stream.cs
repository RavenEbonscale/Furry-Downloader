using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace E621_Downloader
{
    class e621stream
    {
      

        public static async void  Listn(string tagfile)
        {
            List<Task> e621listner = new List<Task>();

            List<string> tags = msc.Readtagfile(tagfile);
            foreach (var tag in tags)
            {
                Console.WriteLine($"Starting download for {tag} OWO");

               Console.WriteLine($"Ending  download for {tag} OWO");
            }
            await Task.WhenAll(e621listner);


        }


    }
}
