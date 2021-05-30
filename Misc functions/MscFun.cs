using System;
using System.Collections.Generic;
using System.IO;

namespace Misc_functions
{
    public static class Miscfun
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

        public static void Creation(this string Folder)
        {
            if (!Directory.Exists(Folder))
            {
                Console.WriteLine("File path Created Owo");
                Directory.CreateDirectory(Folder);
            }
        }

        public static string Generatefilename(string ext)
        {
            Random r = new Random();
            int len = r.Next(1, 50);
            string[] alphabet = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
            string filename = "";
            int l = 0;
            while (l < len)
            {
                filename += alphabet[r.Next(alphabet.Length)];
                l++;
            }
            return filename + ext;

        }

        public static void ProgressBar(int progress, int total)
        {
            //draw empty progress bar
            Console.CursorLeft = 0;
            Console.Write("["); //start
            Console.CursorLeft = 32;
            Console.Write("]"); //end
            Console.CursorLeft = 1;
            float onechunk = 30.0f / total;

            //draw filled part
            int position = 1;
            for (int i = 0; i < onechunk * progress; i++)
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.CursorLeft = position++;
                Console.Write(" ");
            }

            //draw unfilled part
            for (int i = position; i <= 31; i++)
            {
                Console.BackgroundColor = ConsoleColor.DarkMagenta;
                Console.CursorLeft = position++;
                Console.Write(" ");
            }

            //draw totals
            Console.CursorLeft = 35;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(progress.ToString() + " of " + total.ToString() + "    "); //blanks at the end remove any excess
        }



    }
}
