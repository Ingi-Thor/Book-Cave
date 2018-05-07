using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BookCave.Services;

namespace BookCave.Controllers
{
    [Authorize(Roles = "Admin, Customer")]
    public class BookController : Controller
    {
        private BookService _bs;

        public IActionResult Index(int? id)
        {
          if(id == null){
            return View("Not found");
          }
          var book = (from b in FakeDatabase.Books
                       where b.Id == id
                       select b).SingleOrDefault();
          if(book == null)
          {
            return View("Not found");
          }
          return View(book);
        }
    }
}