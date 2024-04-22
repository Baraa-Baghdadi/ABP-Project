using Acme.Basket.Baskets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace Acme.FirstProjet.Carts
{
    public class Item : Entity<Guid>
    {
        public virtual string? CartId { get; set; }
        public int Quantity { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public virtual Guid ProductId { get; set; }
        public Product? Product { get; set; }
    }
}
