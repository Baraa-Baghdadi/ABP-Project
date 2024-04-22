using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace Dawaa24Neo.SharedDomains
{
    public class City : Entity<int>
    {
        public string Name { get; set; }


        private City(string name) {
            Name = name;
        }

        public static City Create(string name) {
            return new City(name);
        }

    }
}
