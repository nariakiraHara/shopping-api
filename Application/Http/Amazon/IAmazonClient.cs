using System.Threading.Tasks;
using System.IO;

namespace Application.Http.Amazon
{
    public interface IAmazonClient
    {
        public Task<Stream> GetItemList(string url);
    }
}