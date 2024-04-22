using Acme.Basket.Baskets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Acme.FirstProjet.Carts
{
    [RemoteService(IsEnabled = false)]
    public class CartAppService : ApplicationService, ICartAppService
    {
        private readonly IRepository<Product, Guid> _productRepository;
        private readonly ICartRepository _cartRepository;
        private readonly IItemRepository _itemRepository;

        public CartAppService(IRepository<Product, Guid> productRepository, ICartRepository cartRepository, IItemRepository itemRepository)
        {
            _productRepository = productRepository;
            _itemRepository = itemRepository;
            _cartRepository = cartRepository;

        }

        public async Task<List<CartDto>> GetAllCartAsync()
        {
            var allBasket = await _cartRepository.GetListAsync();
            return ObjectMapper.Map<List<Cart>, List<CartDto>>(allBasket);
        }


        public async Task<CartDto> GetCartAsync(string id)
        {
            var requiredCart = await _cartRepository.GetAsync(id);
            if (requiredCart == null) throw new Exception("No Cart with this id");
            return ObjectMapper.Map<Cart, CartDto>(requiredCart);
        }


        public async Task<bool> AddToCartAsync(string id, Guid productId)
        {
            var cart = await _cartRepository.GetAsync(id);
            if (cart is null)
            {
                cart = new Cart() { Id = id };
                await _cartRepository.InsertAsync(cart);
            }
            var cartItem = cart.Items.SingleOrDefault(item => item.ProductId == productId);
            if (cartItem is null)
            {
                cartItem = new Item() { CartId = id, Quantity = 1, ProductId = productId };
                cart.Items.Add(cartItem);
            }
            else
            {
                cartItem.Quantity++;
            }
            await _cartRepository.UpdateAsync(cart, true);
            return true;
        }


        public async Task<List<ProductDto>> GetAllProductAsync()
        {
            var allProduct = await _productRepository.GetListAsync();

            return ObjectMapper.Map<List<Product>, List<ProductDto>>(allProduct);
        }

        public async Task<List<ItemDto>> GetAllItems()
        {
            return ObjectMapper.Map<List<Item>, List<ItemDto>>(await _itemRepository.GetListAsync());
        }
    }
}
