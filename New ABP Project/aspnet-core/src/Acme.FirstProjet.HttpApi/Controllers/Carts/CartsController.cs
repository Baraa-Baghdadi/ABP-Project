using Acme.Basket.Baskets;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;

namespace Acme.FirstProjet.Controllers.Carts
{
    [RemoteService]
    [Area("app")]
    [Route("api/app/Carts")]
    public class CartsController : AbpController, ICartAppService
    {
        private readonly ICartAppService _cartAppService;
        public CartsController(ICartAppService cartAppService)
        {

            _cartAppService = cartAppService;

        }
        [HttpPost]
        [Route("AddToCart")]
        public async Task<bool> AddToCartAsync(string id, Guid productId)
        {
            return await _cartAppService.AddToCartAsync(id,productId);
        }

        [HttpGet("GetAllCart")]
        public async Task<List<CartDto>> GetAllCartAsync()
        {
            return await _cartAppService.GetAllCartAsync();
        }

        [HttpGet("GetAllItem")]
        public async Task<List<ItemDto>> GetAllItems()
        {
            return await _cartAppService.GetAllItems();
        }

        [HttpGet("GetAllProduct")]
        public async Task<List<ProductDto>> GetAllProductAsync()
        {
            return await _cartAppService.GetAllProductAsync();
        }

        [HttpGet("GetCartById")]
        public async Task<CartDto> GetCartAsync(string id)
        {
            return await _cartAppService.GetCartAsync(id);
        }
    }
}
