using System;
using System.Collections.Generic;

using Application.Model.Amazon;
using Application.Http.Amazon;

namespace Application.Service.Amazon
{
    public class AmazonShoppingListService : IService<AmazonShoppingListRequest, AmazonShoppingList>
    {
        private const string AMAZON_DOMAIN = "amazon.co.jp";
        IAmazonClient amazonClient = new AmazonClient();
        public AmazonShoppingList execute(AmazonShoppingListRequest request)
        {
            amazonClient.GetItemList(AMAZON_DOMAIN);
        }
    }
}