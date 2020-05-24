using System;
using System.Linq;
using Application.Model.Rakuten;
using Application.Http.Rakuten;
using System.Collections.Generic;
using System.Threading.Tasks;
using AngleSharp.Html.Parser;
using Util;

namespace Application.Service.Rakuten
{
    public class RakutenShoppingListService : IService<RakutenShoppingListRequest, Task<RakutenShoppingList>>
    {
        private const string RAKUTEN_SHOP_URL = "search.rakuten.co.jp/search/mall/";

        IRakutenClient client = new RakutenClient();
        public async Task<RakutenShoppingList> execute(RakutenShoppingListRequest request)
        {
            var model = new RakutenShoppingList();
            var parser = new HtmlParser();
            var items = await parser.ParseDocumentAsync(client.GetItemList($"{RAKUTEN_SHOP_URL}{request.SearchParam}/").Result);
            model.Items = items.QuerySelector(".searchresultitems")
                .QuerySelectorAll(".searchresultitem")
                .Select(item =>
                {
                    Console.WriteLine(item.QuerySelector(".price > .important").TextContent);
                    return new RakutenShopping()
                    {
                        ProductImageUrl = item.QuerySelector(".image > a > img").GetAttribute("src"),
                        ProductUrl = item.QuerySelector(".image > a").GetAttribute("href"),
                        ProductName = item.QuerySelector(".title > h2 > a").TextContent,
                        ProductPrice = Utility.ReplaceMoneyFomat(item.QuerySelector(".price > .important").TextContent).ToInt() ?? 0
                    };
                }).ToList();
            return model;
        }
    }
}