using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBooksApi.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string Title { get; set; }

        [Required]
        [StringLength(1500, MinimumLength = 1)]
        public string Description { get; set; }

#nullable enable
        public byte[]? Cover { get; set; }

        public int? AuthorId { get; set; }

        public Author? Author { get; set; }

        public IEnumerable<BookCategoryAssigment>? BookCategoryAssigments { get; set; }

        public IEnumerable<ShelfBookAssigment>? Shelves { get; set; }

#nullable disable
    }
}

// Dodać coś takiego jak saga czy seria książek 
