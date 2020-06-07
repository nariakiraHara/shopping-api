using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using AngleSharp.Html.Parser;
using AngleSharp.Html.Dom;

using Application.Model.Amazon;
using Application.Http.Amazon;
using Util;

namespace Application.Service.Amazon
{
    public class AmazonShoppingListService : IService<AmazonShoppingListRequest, Task<AmazonShoppingList>>
    {
        private const string AMAZON_DOMAIN = "amazon.co.jp/";
        IAmazonClient amazonClient = new AmazonClient();
        public async Task<AmazonShoppingList> execute(AmazonShoppingListRequest request)
        {
            string queryParam = request.SearchParam.NotNullOrEmpty() ? $"s?k={request.SearchParam}" : "";
            var model = new AmazonShoppingList();
            var parser = new HtmlParser();
            var items = await parser.ParseDocumentAsync(amazonClient.GetItemList(AMAZON_DOMAIN + queryParam).Result);
            model.Items = items.QuerySelectorAll(".s-main-slot.s-result-list.s-search-results.sg-row > div")
                .Select( x => {
                    var selectItem = x.QuerySelector("div > span > div > div > div");
                    return new AmazonShopping()
                    {
                        ProductName = selectItem?.QuerySelector(".rush-component > a > div > img").GetAttribute("alt"),
                        ProductImageUrl = selectItem?.QuerySelector(".rush-component > a > div > img").GetAttribute("src"),
                        ProductUrl = selectItem?.QuerySelector(".rush-component > a > div > img").GetAttribute("href"),
                        ProductPrice = Utility.ReplaceMoneyFomat(selectItem?.QuerySelector("div > .a-row.a-size-base.a-color-base > div > a > span > span > span.a-price-whole")
                                        .TextContent).ToInt() ?? 0
                    };
                }).ToList();
            
            var hoge = items.QuerySelectorAll(".s-main-slot.s-result-list.s-search-results.sg-row > div");
            
            return model;
        }
    }
}