using System;
using System.Linq;

namespace Application.Model.Rakuten
{
    public class RakutenShopping
    {
        public string ProductName { get; set; } = string.Empty;
        public string ProductUrl { get; set; } = string.Empty;
        public string ProductImageUrl { get; set; } = string.Empty;
        public int ProductPrice { get; set; } = 0;
    }
}