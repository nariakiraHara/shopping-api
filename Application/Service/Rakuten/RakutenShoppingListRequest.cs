using System;

namespace Application.Service.Rakuten
{
    public class RakutenShoppingListRequest
    {
        public RakutenShoppingListRequest(int id)
        {
            this.id = id;
        }

        private int id;
        public int ID { get { return id; }}
    }
}