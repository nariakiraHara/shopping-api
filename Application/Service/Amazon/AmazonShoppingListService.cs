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
            model.Items = items.QuerySelector(".s-main-slot.s-result-list.s-search-results.sg-row > div > div > span > div > div > div")
                .QuerySelectorAll(".a-section.a-spacing-medium")
                .Select( x =>
                {
                    return new AmazonShopping()
                    {
                        ProductName = x.QuerySelector(".rush-component > a > div > img").GetAttribute("alt"),
                        ProductImageUrl = x.QuerySelector(".rush-component > a > div > img").GetAttribute("src"),
                        ProductUrl = x.QuerySelector(".rush-component > a > div > img").GetAttribute("href"),
                        ProductPrice = Utility.ReplaceMoneyFomat(x.QuerySelector("div > .a-row.a-size-base.a-color-base > div > a > span > span > span.a-price-whole")
                                        .TextContent).ToInt() ?? 0
                    };
                }).ToList();
            
            return model;
        }
    }
}