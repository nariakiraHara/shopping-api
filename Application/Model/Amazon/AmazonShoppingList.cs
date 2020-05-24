using System;
using System.Collections.Generic;

namespace Application.Model.Amazon
{
    public class AmazonShoppingList
    {
            public int Count { get; set; } = 0;
            public List<AmazonShopping> Items { get; set; } = new List<AmazonShopping>();
    }
}