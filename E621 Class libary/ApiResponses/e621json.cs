namespace E621_Wrapper
{
    public class E621json
    {
        public Post[] posts { get; set; }

        public class Post
        {
            public int id { get; set; }

            public string created_at { get; set; }

            public File file { get; set; }
            public Tags tags { get; set; }
            public Preview preview { get; set; }
            public Sample sample { get; set; }
            public string rating { get; set; }
            public string description { get; set; }

            public class File

            {
                public int width { get; set; }
                public int height { get; set; }
                public string ext { get; set; }
                public int size { get; set; }

                public string url { get; set; }

                public string md5 { get; set; }
            }
        }

        public class Tags
        {
            public string[] general { get; set; }
            public string[] species { get; set; }

            public string[] chracter { get; set; }
            public string[] meta { get; set; }
        }
    }

    public class Sample
    {
        public string url { get; set; }
    }

    public class Preview
    {
        public string url { get; set; }
    }
}