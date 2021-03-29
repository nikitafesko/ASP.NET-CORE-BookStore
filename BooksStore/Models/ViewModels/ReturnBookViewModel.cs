using System;
using System.ComponentModel.DataAnnotations;
using BookStore.Models.Classes;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BookStore.Models.ViewModels
{
    public class ReturnBookViewModel
    {
        public Order ReturnOrder { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int BookCountForReturn { get; set; }
    }
}