using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using BookCave.Models;
using BookCave.Data.EntityModels;
using Microsoft.AspNetCore.Diagnostics;
using BookCave.Services;
using Microsoft.AspNetCore.Http;

namespace BookCave.Controllers
{
    public class HomeController : Controller
    {
        private readonly BookService _bookService;
        private readonly CookieService _cookieService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HomeController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _bookService = new BookService();
            _cookieService  = new CookieService(_httpContextAccessor);
        }

        public IActionResult Index()
        {
            var books = _bookService.Recommended();
            //_cookieService.InitializeCookie();
            //_cookieService.AddToCartCookie(2, "2323");
            //_cookieService.RemoveFromCartCookie(2323);
            _cookieService.InitializeCookie();

            return View(books);
        }

        public IActionResult Error()
        {
            
            return View("Error");
        }

        public IActionResult Error404()
        {
          return View("PageNotFound");
        }
    }
}
