using System;
using System.Collections.Generic;
using System.Linq;
using BookCave.Models.ViewModels;
using BookCave.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookCave.Controllers
{
    public class CheckOutController : Controller
    {
        private readonly CheckoutService _checkoutService;
        private readonly CookieService _cookieService;
        private readonly IHttpContextAccessor _httpContextAccessor;  

        public CheckOutController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _checkoutService = new CheckoutService(httpContextAccessor);
            _cookieService = new CookieService(_httpContextAccessor);
        }

        [HttpPost]
        public void AddToCart([FromQuery]int qty, int id)
        {
            _cookieService.AddToCartCookie(qty, id);
        }

        [HttpPost]
        public void RemoveFromCart([FromQuery] int id)
        {
            _cookieService.RemoveFromCartCookie(id);
        }

        
        public IActionResult Index()
        {
            var cartArr = _cookieService.GetCart();
            var bookList = _checkoutService.GetItemsInCart(cartArr);
            var order = _checkoutService.GetCartViewModel(bookList);
            return View(order);
        }

        public IActionResult Shipping()
        {
          return View();
        }

        public IActionResult Billing()
        {
          return View();
        }

        public IActionResult Card()
        {
          return View();
        }

        public IActionResult Review()
        {
          return View();
        }

        public IActionResult Confirm()
        {
          return View();
        }
    }
}