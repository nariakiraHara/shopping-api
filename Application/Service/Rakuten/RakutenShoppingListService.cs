using System;
using System.Linq;
using Application.Model.Rakuten;
using Application.Http.Rakuten;
using System.Collections.Generic;

namespace Application.Service.Rakuten
{
    public class RakutenShoppingListService : IService<RakutenShoppingListRequest, List<RakutenShopping>>
    {
        IRakutenClient client = new RakutenClient();
        public List<RakutenShopping> execute(RakutenShoppingListRequest request)
        {
            var stream = client.GetItemList();
            return null;
        }
    }
}