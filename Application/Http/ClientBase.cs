using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;

namespace Application.Http
{
    public class ClientBase
    {
        private static HttpClient client = new HttpClient();
        private ClientBase() {}

        public static ClientBase Client { get; } = new ClientBase();

        public async Task<Stream> GetAsync(Uri uri, Dictionary<string, string> headers = null, Dictionary<string, string> auth = null)
        {
            Stream stream;
            this.SetHeader(headers);

            var response = await client.GetAsync(uri);

            if (!response.IsSuccessStatusCode)
                stream = null;
            
            stream = await response.Content.ReadAsStreamAsync();

            return stream;
        }

        private void SetAuth(Dictionary<string, string> auth)
        {
            if (auth == null)
                return;
            
            // foreach(var pair in auth)
            // {
            //     client.DefaultRequestHeaders.Authorization.Add(pair.Key, pair.Value);
            // }
        }

        private void SetHeader(Dictionary<string, string> headers)
        {
            if (headers == null)
                return;

            foreach(var pair in headers)
            {
                client.DefaultRequestHeaders.Add(pair.Key, pair.Value);
            }
        }
    }
}