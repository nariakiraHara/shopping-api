using System;
using System.Linq;
using System.Collections.Generic;
using AngleSharp.Html.Parser;
using AngleSharp.Html.Dom;

using Application.Model.Amazon;
using Application.Http.Amazon;
using Util;

namespace Application.Service.Amazon
{
    public class AmazonShoppingListService : IService<AmazonShoppingListRequest, AmazonShoppingList>
    {
        private const string AMAZON_DOMAIN = "amazon.co.jp/";
        IAmazonClient amazonClient = new AmazonClient();
        public async AmazonShoppingList execute(AmazonShoppingListRequest request)
        {
            string queryParam = request.SearchParam.NotNullOrEmpty() ? $"s?k={request.SearchParam}" : "";
            var model = new AmazonShoppingList();
            var parser = new HtmlParser();
            var items = await parser.ParseDocumentAsync(amazonClient.GetItemList(AMAZON_DOMAIN + queryParam).Result);
            model = items.QuerySelector(".s-main-slot.s-result-list.s-search-results.sg-row")
                .QuerySelectorAll(".a-section.a-spacing-medium")
                .sel
        }
    }
}