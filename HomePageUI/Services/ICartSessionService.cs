using EntitiesLayer.Concrete;

namespace HomePageUI.Services
{
    public interface ICartSessionService
    {
        Cart GetCart();
        void SetCart(Cart cart);
    }
}
