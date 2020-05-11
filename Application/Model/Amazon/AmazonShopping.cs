using System;

namespace Application.Model.Amazon
{
    public class AmazonShopping
    {
        public string ProductName { get; set; } = string.Empty;
        public string ProductUrl { get; set; } = string.Empty;
        public string ProductImageUrl { get; set; } = string.Empty;
        public int ProductPrice { get; set; } = 0;
    }
}