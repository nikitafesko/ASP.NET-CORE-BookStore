using System.Linq;
using BookStore.Models.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Components
{
    [ViewComponent]
    public class NavigationMenu : ViewComponent
    {
        private readonly IBookRepository repository;

        public NavigationMenu(IBookRepository repository)
        {
            this.repository = repository;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(repository.Books
                .Select(book => book.Category)
                .Distinct()
                .OrderBy(book => book));
        }
    }
}