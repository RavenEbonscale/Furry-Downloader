using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace E621_Wrapper
{
    internal static class Helper
    {
        internal static async Task<MemoryStream> Deserializetion(this string url, HttpClient client, string type = "post")
        {
            // Desealize the json file and put it into the e621 class
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, url);

                HttpResponseMessage responseMessage = client.Send(requestMessage);
                byte[] response = await responseMessage.Content.ReadAsByteArrayAsync();
                //Has to be turned into an io stream so it can be used as an async
                 //Console.WriteLine((int)responseMessage.StatusCode);
                MemoryStream stream = new MemoryStream(response);
                return stream;

        }

    }
}