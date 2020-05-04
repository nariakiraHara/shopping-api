using System;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using AngleSharp.Html.Parser;

namespace Application.Http.Rakuten
{
    public class RakutenClient : IRakutenClient
    {
        public async Task<Stream> GetItemList(string url)
        {
            var client = ClientBase.GetInstance;
            return await client.GetAsync(url).ConfigureAwait(false);
        }
    }
}