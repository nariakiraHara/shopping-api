using System;

namespace Application.Service.Amazon
{
    public class AmazonShoppingListRequest
    {
        private string searchParam;
        public string SearchParam { get => searchParam; }
        public AmazonShoppingListRequest(string searchParam)
        {
            this.searchParam = searchParam;
        }
    }
}