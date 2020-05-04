using System;
using System.Linq;
using Application.Model.Rakuten;
using Application.Http.Rakuten;
using System.Collections.Generic;
using System.Threading.Tasks;
using AngleSharp.Html.Parser;

namespace Application.Service.Rakuten
{
    public class RakutenShoppingListService : IService<RakutenShoppingListRequest, Task<List<RakutenShopping>>>
    {
        private const string RAKUTEN_SHOP_URL = "search.rakuten.co.jp/search/mall/";

        IRakutenClient client = new RakutenClient();
        public async Task<List<RakutenShopping>> execute(RakutenShoppingListRequest request)
        {
            var parser = new HtmlParser();
            var htmlDoc = await parser.ParseDocumentAsync(client.GetItemList($"{RAKUTEN_SHOP_URL}{request.SearchParam}/").Result);
            return null;
        }
    }
}