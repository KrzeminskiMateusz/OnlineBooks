using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBooksApi.Models
{
    public class Book
    {
        public int Id { get; set; }
#nullable enable

        [StringLength(100, MinimumLength = 1)]
        public string? Title { get; set; }

        [StringLength(2000, MinimumLength = 1)]
        public string? Description { get; set; }

        public byte[]? Cover { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        public DateTime PublcationDate { get; set; }

        public int? NumberOfPages { get; set; }

        public int? AuthorId { get; set; }

        public Author? Author { get; set; }

        public IEnumerable<BookCategoryAssigment>? BookCategoryAssigments { get; set; }

        public IEnumerable<ShelfBookAssigment>? Shelves { get; set; }

#nullable disable
    }
}

// Dodać coś takiego jak saga czy seria książek 
