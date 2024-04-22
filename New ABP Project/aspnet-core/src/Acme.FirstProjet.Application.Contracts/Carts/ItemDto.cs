using System;
using System.Collections.Generic;
using System.Text;

namespace Acme.Basket.Baskets
{
    public class ItemDto
    {
        public Guid Id { get; set; }
        public string? CartId { get; set; }
        public int Quantity { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public Guid? ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public decimal? ProductPrice { get; set; }

    }
}
