using System;
using System.Collections.Generic;
using System.IO;

namespace E621_Downloader
{
    public class msc
    {
        public static List<string> Readtagfile(string tagfile)
        {
            List<string> tags = new List<string>();
            if (File.Exists(tagfile))
            {
                using (StreamReader sr = new StreamReader(tagfile))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string tag = line.Replace(",", "+").Replace(" ", String.Empty).Replace("\\", "\\\\");

                        tags.Add(tag);
                    }
                }
            }
            else
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
            return tags;
        }

        public static (string apikey, string user) Stuff(string config_path)
        {
            List<string> Apiinfor = new List<string>();

            using (StreamReader sr = new StreamReader(config_path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] split = line.Split('=');
                    if (split[1] == null)
                    {
                        continue;
                    }
                    Apiinfor.Add(split[1].Trim());
                }
            }

            string api = Apiinfor[0];
            string user = Apiinfor[1];

            return (api, user);
        }
    }
}