using System;
using System.Linq;
using System.IO;

namespace Application.Http.Rakuten
{
    public class RakutenClient : IRakutenClient
    {
        public Stream GetItemList()
        {
            var client = ClientBase.Client;
            return null;
        }
    }
}