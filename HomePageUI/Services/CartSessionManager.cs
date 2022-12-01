using EntitiesLayer.Concrete;
using HomePageUI.Extensions;
using Microsoft.AspNetCore.Http;

namespace HomePageUI.Services
{
    public class CartSessionManager:ICartSessionService
    {
        private IHttpContextAccessor _httpContextAccessor;
        public CartSessionManager(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        //HttpContext sadece controllerda kullanıbilir oldugu icin burada constructor ile
        //IHttpContextAccessor yapısını dep injec. yapmamız gerek
        public Cart GetCart()
        {
            Cart cartToCheck = _httpContextAccessor.HttpContext.Session.GetObject<Cart>("cart");
            if (cartToCheck == null)
            {
                _httpContextAccessor.HttpContext.Session.SetObject("cart", new Cart());
                cartToCheck = _httpContextAccessor.HttpContext.Session.GetObject<Cart>("cart");
            }
            return cartToCheck;
        }

        public void SetCart(Cart cart)
        {
            _httpContextAccessor.HttpContext.Session.SetObject("cart", cart);
        }
    }
}
