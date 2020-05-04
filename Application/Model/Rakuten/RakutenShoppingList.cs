using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Application.Model.Rakuten
{
    public class RakutenShoppingList
    {
        public int Count { get; set; } = 0;
        public List<RakutenShopping> Items { get; set; } = null;
    }
}