using System.Net;


namespace E621_Downloader
{
    public static class Helper
    {
       
        //Fixes / problem
        public static string Slashfix(this string folderstring)
        {
            if (folderstring != "m/m")
            {
                return folderstring;
            }
            return "MaleMale";
        }

        public static void
       Downloadasync(this string url, string md5, string extenstion, string path, string tag)
        {
            if (url != null)
            {
                
                

                using (WebClient wc = new WebClient())
                {
                    wc.DownloadFile(url, $@"{path}\{tag}\{md5}.{extenstion}");
                }
            }
        }
    }
}