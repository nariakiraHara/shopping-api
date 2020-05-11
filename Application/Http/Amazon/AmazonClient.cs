using System;
using System.IO;
using System.Threading.Tasks;

namespace Application.Http.Amazon
{
    public class AmazonClient : IAmazonClient
    {
        public async Task<Stream> GetItemList(string url)
        {
            ClientBase client = ClientBase.GetInstance;
            return await client.GetAsync(url);
        }
    }
}