using Acme.Basket.Baskets;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Acme.Basket.Baskets
{
    public interface ICartAppService: IApplicationService
    {
        Task<List<CartDto>> GetAllCartAsync();
        Task<List<ProductDto>> GetAllProductAsync();
        Task<List<ItemDto>> GetAllItems();
        Task<CartDto> GetCartAsync(string id);
        Task<bool> AddToCartAsync(string id, Guid productId);
    }
}
