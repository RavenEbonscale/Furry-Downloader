using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace E621_Wrapper
{
   public class e926_api
    { 
                public class E926_Api
        {
            private string ApiKey { get; }

            private string username { get; }

            private string useragent { get; }

            public E926_Api(string ApiKey, string username, string useragent)
            {
                this.ApiKey = ApiKey;
                this.username = username;
                this.useragent = useragent;
            }

            internal HttpClient e926Client
            {
                get
                {
                    HttpClient client = new HttpClient();
                    client.DefaultRequestHeaders.Add("api-key", ApiKey);
                    client.DefaultRequestHeaders.Add("api-key", username);
                    client.DefaultRequestHeaders.Add("user-agent", useragent);
                    return client;
                }
            }

            public List<E621json> Get_Posts(string tags, int pages)
            {
                List<E621json> e621posts = new List<E621json>();
                Parallel.For(1, pages, async page =>
                {
                    using (MemoryStream e621 = await $"https://e926.net/posts.json?page={page}&tags={tags}".Deserializetion(e926Client))
                    {
                        E621json posts = await JsonSerializer.DeserializeAsync<E621json>(e621);
                        e621posts.Add(posts);
                    }
                });
                return e621posts;
            }

            public async Task<List<E621pools>> Get_Pool(string pool)
            {
                List<E621pools> pools = new();

                using (MemoryStream e621 = await $"https://e926.net/pools.json?search[name_matches]={pool}".Deserializetion(e926Client))
                {
                    var _pool = await JsonSerializer.DeserializeAsync<List<E621pools>>(e621);
                    pools.AddRange(_pool);
                }

                return pools;
            }

            public async Task<Singlepost> Get_Id(int id)
            {
                MemoryStream e926 = await $"https://e926.net/posts/{id}.json".Deserializetion(e926Client);
                //Console.WriteLine(Encoding.ASCII.GetString(e926.ToArray()));
                var post = await JsonSerializer.DeserializeAsync<Singlepost>(e926);



                return post;
            }
            public async Task<E621json> Get_Favs()
            {

                using MemoryStream e926 = await $"https://e926.net/favorites.json".Deserializetion(e926Client);
                E621json posts = await JsonSerializer.DeserializeAsync<E621json>(e926);

                return posts;
            }


        }
    }
}
