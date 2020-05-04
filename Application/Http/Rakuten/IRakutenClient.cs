using System;
using System.Linq;
using System.IO;
using System.Threading.Tasks;

namespace Application.Http.Rakuten
{
    public interface IRakutenClient
    {
        public Task<Stream> GetItemList(string url);
    }
}