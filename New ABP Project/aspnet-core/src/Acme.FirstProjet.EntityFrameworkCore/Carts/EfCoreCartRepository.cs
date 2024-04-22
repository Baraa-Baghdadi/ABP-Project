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
    public class EfCoreCartRepository : EfCoreRepository<FirstProjetDbContext, Cart, string>, ICartRepository
    {

        public EfCoreCartRepository(IDbContextProvider<FirstProjetDbContext>
        dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<Cart> GetAsync(string id)
        {
            var query = (await GetQueryableAsync()).Where(p => p.Id == id).Include(p => p.Items).ThenInclude(p => p.Product).FirstOrDefaultAsync();
            return await query;
        }

        public async Task<List<Cart>> GetListAsync()
        {
            var query = (await GetQueryableAsync()).Include(p => p.Items).ThenInclude(p => p.Product).ToListAsync();
            return await query;
        }
    }
}
