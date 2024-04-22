using Acme.FirstProjet.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Acme.FirstProjet.Carts
{
    public class EfCoreItemRepository : EfCoreRepository<FirstProjetDbContext, Item, Guid>, IItemRepository
    {
        public EfCoreItemRepository(IDbContextProvider<FirstProjetDbContext>
        dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<Item> GetAsync(Guid id)
        {
            var query = (await GetQueryableAsync()).Include("Product").Where(p => p.Id == id);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<List<Item>> GetListAsync()
        {
            var query = (await GetQueryableAsync()).Include("Product");
            return await query.ToListAsync();
        }
    }
}
