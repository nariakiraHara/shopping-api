using System;
using System.Linq;
using System.IO;

namespace Application.Http.Rakuten
{
    public interface IRakutenClient
    {
        public Stream GetItemList();
    }
}