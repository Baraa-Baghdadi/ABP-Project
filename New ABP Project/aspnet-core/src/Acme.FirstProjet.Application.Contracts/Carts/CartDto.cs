using System;
using System.Collections.Generic;
using System.Text;

namespace Acme.Basket.Baskets
{
    public class CartDto
    {
        public string? Id { get; set; }
        public List<ItemDto>? Items { get; set; }
    }
}
