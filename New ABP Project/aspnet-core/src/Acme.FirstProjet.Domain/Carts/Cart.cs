using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace Acme.FirstProjet.Carts
{
    public class Cart : AggregateRoot<string>
    {
        public string? Id { get; set; }
        public List<Item>? Items { get; set; }

        public Cart()
        {
            Items = new List<Item>();
        }
    }
}
