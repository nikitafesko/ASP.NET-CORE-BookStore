using System.Collections.Generic;
using BookStore.Models.Classes;

namespace BookStore.Models.ViewModels
{
    public class BookListViewModel
    {
        public IEnumerable<Book> Books { get; set; }

        public PagingInfo PagingInfo { get; set; }

        public string CurrentCategory { get; set; }

        public string SortType { get; set; }

        public string SearchText { get; set; }
    }
}