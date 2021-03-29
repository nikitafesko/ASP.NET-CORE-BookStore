using System.Linq;
using BookStore.Models.Classes;
using BookStore.Models.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private readonly IBookRepository repository;

        public AdminController(IBookRepository repository)
        {
            this.repository = repository;
        }
        public ViewResult Index() =>
            View(repository.Books);

        public ViewResult Edit(int productId) =>
            View(repository.Books.FirstOrDefault(book => book.BookId == productId));

        [HttpPost]
        public IActionResult Edit(Book book)
        {
            if (!ModelState.IsValid) return View(book);

            repository.SaveBook(book);
            TempData["message"] = $"{book.Name} has been saved";
            return RedirectToAction("Index");
        }

        public ViewResult Create() =>
            View("Edit", new Book());

        [HttpPost]
        public IActionResult Delete(int productId)
        {
            var deletedBook = repository.DeleteBook(productId);
            if (deletedBook != null)
                TempData["message"] = $"{deletedBook.Name} was deleted";

            return RedirectToAction("Index");
        }
    }
}