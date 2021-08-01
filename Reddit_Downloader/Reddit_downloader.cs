using Misc_functions;
using Reddit;
using Reddit.Controllers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Reddit_Downloader
{
    public class Reddit_Dl

    {
        public static void Reddit()
        {
            Console.WriteLine("This might take a while depending on how  many subreddits you added");

            string redditfile = "subredditlist.txt";
            if (!File.Exists(redditfile))
            {
                using (StreamWriter sw = new StreamWriter(redditfile))
                {
                    sw.WriteLine("r/yiff");
                    sw.WriteLine("r/gfur");
                    Console.WriteLine("Example reddit list had been created");
                }
            }

            List<string> subreddits = new List<string> { };
            string[] file = File.ReadAllLines(redditfile);
            foreach (string sr in file) subreddits.Add(sr.Trim().Replace("r/", ""));
            foreach (string sub in subreddits) if (!Directory.Exists($@".\reddit\{sub}")) $@".\reddit\{sub}".Creation();
            RedditClient r = new RedditClient(appId: "", appSecret: "", userAgent: "Raven Ebonscale mega gay bot", refreshToken: "");
            List<(string url, string subreddit)> Urls = GrabPosts(r, subreddits);
            Download(Urls);
        }

        private static void Download(List<(string url, string subreddit)> urls)
        {
            Parallel.ForEach(urls, (url) =>
            {
                using WebClient wc = new WebClient();

                Directory.CreateDirectory(url.subreddit);
                string ext = Path.GetExtension(url.url);
                Console.WriteLine($" Done Downloading: {url.url}");
                wc.DownloadFile(url.url, @$".\reddit\{url.subreddit}\{Miscfun.Generatefilename(ext)}");
            });
        }

        private static List<(string url, string subreddit)> GrabPosts(RedditClient r, List<string> subreddits)
        {
            Regex rx = new Regex(@".*\.(jpg|png|mp4|gif|webm)?$");
            List<(string, string)> Url = new List<(string, string)> { };
            Parallel.ForEach(subreddits, (subreddit) =>
            {
                SubredditPosts subs = r.Subreddit(subreddit).Posts;
                List<Post> Posts = subs.Top;
                foreach (Post post in Posts)
                {
                    string url = post.Listing.URL;
                    if (rx.IsMatch(url))
                    {
                        Url.Add((url, subreddit));
                    }
                }
            });
            return Url;
        }
    }
}