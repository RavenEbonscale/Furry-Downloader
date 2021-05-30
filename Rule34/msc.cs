using System;
using System.Collections.Generic;
using System.IO;


namespace Rule34
{
    class msc
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
                        string tag = line.Replace(",", "+");

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

                    sw.Close();
                }
            }
            return tags;
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
