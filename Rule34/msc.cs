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
    }
}
