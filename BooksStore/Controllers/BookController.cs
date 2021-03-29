using System.Linq;
using BookStore.Infrastructure;
using BookStore.Models.Classes;
using BookStore.Models.Repositories.Interfaces;
using BookStore.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository repository;
        //private const int PageSize = 4;

        public BookController(IBookRepository repository)
        {
            this.repository = repository;
        }

        public ViewResult Home(int productPage = 1, string pageSizeString = "5")
        {
            var pageSize = int.Parse(pageSizeString);

            HttpContext.Session.SetString("SortType", string.Empty);
            HttpContext.Session.SetString("SearchText", string.Empty);
            HttpContext.Session.SetInt32("PageSize", 5);

            return View("List", new BookListViewModel
            {
                Books = repository.Books
                    .Skip((productPage - 1) * pageSize)
                    .Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = productPage,
                    ItemsPerPage = pageSize,
                    TotalItems = repository.Books.Count()
                },
                CurrentCategory = string.Empty,
                SortType = string.Empty,
                SearchText = string.Empty
            });
        }

        [HttpGet]
        [HttpPost]
        public ViewResult List(string category, string sortType, [FromForm] string searchText, string pageSizeString , int productPage = 1)
        {
            if (int.TryParse(pageSizeString, out var pageSize))
                HttpContext.Session.SetInt32("PageSize", pageSize);
            else
                pageSize = HttpContext.Session.GetInt32("PageSize") ?? 5;

            searchText ??= HttpContext.Session.GetString("SearchText") ?? string.Empty;
            sortType ??= HttpContext.Session.GetString("SortType") ?? string.Empty;

            if (!string.IsNullOrEmpty(sortType))
                HttpContext.Session.SetString("SortType", sortType);

            if (!string.IsNullOrEmpty(searchText))
                HttpContext.Session.SetString("SearchText", searchText);

            IQueryable<Book> searchedBooks = null;
            if (!string.IsNullOrEmpty(searchText))
            {
                searchedBooks = repository.Books
                    .Where(book => book.Name.Contains(searchText)
                                   || book.Author.Contains(searchText)
                                   || book.Publisher.Contains(searchText)
                                   || book.Year.Contains(searchText));
            }

            return View(new BookListViewModel
            {
                Books = (searchedBooks ?? repository.Books)
                    .Where(book => category == null || book.Category == category)
                    .ParametrizeOrderBy(sortType)
                    .Skip((productPage - 1) * pageSize)
                    .Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = productPage,
                    ItemsPerPage = pageSize,
                    TotalItems = category == null ?
                        (searchedBooks ?? repository.Books).Count() :
                        (searchedBooks ?? repository.Books).Count(book => book.Category == category)
                },
                CurrentCategory = category ?? string.Empty,
                SortType = sortType,
                SearchText = searchText
            });
        }
    }
}