using System;

namespace Application.Service.Rakuten
{
    public class RakutenShoppingListRequest
    {
        public RakutenShoppingListRequest(string searchParam)
        {
            this.searchParam = searchParam;
        }

        private string searchParam;
        public string SearchParam { get => searchParam; }
    }
}