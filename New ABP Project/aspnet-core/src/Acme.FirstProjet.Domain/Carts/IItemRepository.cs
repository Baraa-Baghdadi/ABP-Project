using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Acme.FirstProjet.Carts
{
    public interface IItemRepository : IRepository<Item,Guid>
    {
        Task<Item> GetAsync(Guid id);
        Task<List<Item>> GetListAsync();
    }
}
