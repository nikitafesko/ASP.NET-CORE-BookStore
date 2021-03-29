using System.ComponentModel.DataAnnotations;

namespace BookStore.Models.Classes
{
    public class Book
    {
        public int BookId { get; set; }

        [Required(ErrorMessage = "Please, enter a book name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please, enter a book author")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Please, enter a book publisher")]
        public string Publisher { get; set; }

        [Required(ErrorMessage = "Please, enter a book year")]
        public string Year { get; set; }

        [Required(ErrorMessage = "Please, enter a book cover type")]
        public string CoverType { get; set; }

        [Required(ErrorMessage = "Please, enter a book pages count")]
        [Range(1, int.MaxValue, ErrorMessage = "Please, enter a positive count")]
        public int PagesCount { get; set; }

        [Required(ErrorMessage = "Please, enter a book language")]
        public string Language { get; set; }

        [Required(ErrorMessage = "Please, enter a book description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please specify a category")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Please, enter a book name")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Please, enter a positive price")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Please, enter a book count")]
        [Range(0, int.MaxValue, ErrorMessage = "Please, enter a positive count")]
        public uint Count { get; set; }
    }
}