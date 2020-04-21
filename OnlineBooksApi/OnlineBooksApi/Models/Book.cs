using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBooksApi.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
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
