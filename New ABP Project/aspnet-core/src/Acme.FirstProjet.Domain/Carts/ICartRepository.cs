using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Acme.FirstProjet.Carts
{
    public interface ICartRepository : IRepository<Cart,string>
    {
        Task<Cart> GetAsync(string id);
        Task<List<Cart>> GetListAsync();
    }
}
