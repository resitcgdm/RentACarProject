using BusinessLayer.Abstract;
using HomePageUI.Models;
using HomePageUI.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HomePageUI.Controllers
{
    public class CartController : Controller
    {
        private ICartSessionService _cartSessionService;
        private ICartService _cartService;
        private ICarService _carService;
        public CartController(ICartSessionService cartSessionService, ICartService cartService, ICarService productService)
        {
            _cartSessionService = cartSessionService;
            _cartService = cartService;
            _carService = productService;
        }
        public IActionResult AddToCart(int carId)
        {


            var productToBeAdded = _carService.GetById(carId);
            var cart = _cartSessionService.GetCart();
            _cartService.AddToCart(cart, productToBeAdded);
            _cartSessionService.SetCart(cart);
            //TempData.Add("message", String.Format("{0} was succesfully added to the cart!", productToBeAdded.ProductName)); 
            return RedirectToAction("ListCart","Cart");





        }
        public IActionResult ListCart()
        {
            var cart = _cartSessionService.GetCart();
            CartSummaryViewModel cartSummaryViewModel = new CartSummaryViewModel
            {
                Cart = cart
            };
            return View(cartSummaryViewModel);
        }
        public IActionResult DeleteFromCart(int carId)
        {
            var cart = _cartSessionService.GetCart();
            _cartService.RemoveFromCart(cart, carId);
            _cartSessionService.SetCart(cart);
            TempData.Add("message", String.Format("Your product was succesfully removed from cart!"));
            return RedirectToAction("ListCart");
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
